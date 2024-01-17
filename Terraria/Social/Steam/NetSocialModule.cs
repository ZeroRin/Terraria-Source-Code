﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.NetSocialModule
// Assembly: Terraria, Version=1.4.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F541F3E5-89DE-4E5D-868F-1B56DAAB46B2
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Steamworks;
using System;
using System.Collections.Concurrent;
using System.IO;
using Terraria.Net;

namespace Terraria.Social.Steam
{
  public abstract class NetSocialModule : Terraria.Social.Base.NetSocialModule
  {
    protected const int ServerReadChannel = 1;
    protected const int ClientReadChannel = 2;
    protected const int LobbyMessageJoin = 1;
    protected const ushort GamePort = 27005;
    protected const ushort SteamPort = 27006;
    protected const ushort QueryPort = 27007;
    protected static readonly byte[] _handshake = new byte[10]
    {
      (byte) 10,
      (byte) 0,
      (byte) 93,
      (byte) 114,
      (byte) 101,
      (byte) 108,
      (byte) 111,
      (byte) 103,
      (byte) 105,
      (byte) 99
    };
    protected SteamP2PReader _reader;
    protected SteamP2PWriter _writer;
    protected Lobby _lobby = new Lobby();
    protected ConcurrentDictionary<CSteamID, NetSocialModule.ConnectionState> _connectionStateMap = new ConcurrentDictionary<CSteamID, NetSocialModule.ConnectionState>();
    protected object _steamLock = new object();
    private Callback<LobbyChatMsg_t> _lobbyChatMessage;

    protected NetSocialModule(int readChannel, int writeChannel)
    {
      this._reader = new SteamP2PReader(readChannel);
      this._writer = new SteamP2PWriter(writeChannel);
    }

    public override void Initialize()
    {
      CoreSocialModule.OnTick += new Action(this._reader.ReadTick);
      CoreSocialModule.OnTick += new Action(this._writer.SendAll);
      NetSocialModule netSocialModule = this;
      // ISSUE: virtual method pointer
      this._lobbyChatMessage = Callback<LobbyChatMsg_t>.Create(new Callback<LobbyChatMsg_t>.DispatchDelegate((object) netSocialModule, __vmethodptr(netSocialModule, OnLobbyChatMessage)));
    }

    public override void Shutdown() => this._lobby.Leave();

    public override bool IsConnected(RemoteAddress address)
    {
      if (address == null)
        return false;
      CSteamID steamId = this.RemoteAddressToSteamId(address);
      if (!this._connectionStateMap.ContainsKey(steamId) || this._connectionStateMap[steamId] != NetSocialModule.ConnectionState.Connected)
        return false;
      if (this.GetSessionState(steamId).m_bConnectionActive == (byte) 1)
        return true;
      this.Close(address);
      return false;
    }

    protected virtual void OnLobbyChatMessage(LobbyChatMsg_t result)
    {
      if ((long) result.m_ulSteamIDLobby != (long) this._lobby.Id.m_SteamID || result.m_eChatEntryType != (byte) 1 || (long) result.m_ulSteamIDUser != (long) this._lobby.Owner.m_SteamID)
        return;
      byte[] message = this._lobby.GetMessage((int) result.m_iChatID);
      if (message.Length == 0)
        return;
      using (MemoryStream input = new MemoryStream(message))
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) input))
        {
          if (binaryReader.ReadByte() != (byte) 1)
            return;
          while ((long) message.Length - input.Position >= 8L)
          {
            CSteamID userId;
            // ISSUE: explicit constructor call
            ((CSteamID) ref userId).\u002Ector(binaryReader.ReadUInt64());
            if (CSteamID.op_Inequality(userId, SteamUser.GetSteamID()))
              this._lobby.SetPlayedWith(userId);
          }
        }
      }
    }

    protected P2PSessionState_t GetSessionState(CSteamID userId)
    {
      P2PSessionState_t sessionState;
      SteamNetworking.GetP2PSessionState(userId, ref sessionState);
      return sessionState;
    }

    protected CSteamID RemoteAddressToSteamId(RemoteAddress address) => ((SteamAddress) address).SteamId;

    public override bool Send(RemoteAddress address, byte[] data, int length)
    {
      this._writer.QueueSend(this.RemoteAddressToSteamId(address), data, length);
      return true;
    }

    public override int Receive(RemoteAddress address, byte[] data, int offset, int length) => address == null ? 0 : this._reader.Receive(this.RemoteAddressToSteamId(address), data, offset, length);

    public override bool IsDataAvailable(RemoteAddress address) => this._reader.IsDataAvailable(this.RemoteAddressToSteamId(address));

    public enum ConnectionState
    {
      Inactive,
      Authenticating,
      Connected,
    }

    protected delegate void AsyncHandshake(CSteamID client);
  }
}
