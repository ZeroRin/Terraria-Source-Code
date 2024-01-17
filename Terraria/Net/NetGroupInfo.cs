﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Net.NetGroupInfo
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Collections.Generic;

namespace Terraria.Net
{
  public class NetGroupInfo
  {
    private readonly string[] _separatorBetweenInfos = new string[1]
    {
      ", "
    };
    private readonly string[] _separatorBetweenIdAndInfo = new string[1]
    {
      ":"
    };
    private List<NetGroupInfo.INetGroupInfoProvider> _infoProviders;

    public NetGroupInfo()
    {
      this._infoProviders = new List<NetGroupInfo.INetGroupInfoProvider>();
      this._infoProviders.Add((NetGroupInfo.INetGroupInfoProvider) new NetGroupInfo.IPAddressInfoProvider());
      this._infoProviders.Add((NetGroupInfo.INetGroupInfoProvider) new NetGroupInfo.SteamLobbyInfoProvider());
    }

    public string ComposeInfo()
    {
      List<string> stringList = new List<string>();
      foreach (NetGroupInfo.INetGroupInfoProvider infoProvider in this._infoProviders)
      {
        if (infoProvider.HasValidInfo)
        {
          string safeInfo = this.ConvertToSafeInfo(((int) infoProvider.Id).ToString() + this._separatorBetweenIdAndInfo[0] + infoProvider.ProvideInfoNeededToJoin());
          stringList.Add(safeInfo);
        }
      }
      return string.Join(this._separatorBetweenInfos[0], stringList.ToArray());
    }

    public Dictionary<NetGroupInfo.InfoProviderId, string> DecomposeInfo(string info)
    {
      Dictionary<NetGroupInfo.InfoProviderId, string> dictionary = new Dictionary<NetGroupInfo.InfoProviderId, string>();
      foreach (string text in info.Split(this._separatorBetweenInfos, StringSplitOptions.RemoveEmptyEntries))
      {
        string[] strArray = this.ConvertFromSafeInfo(text).Split(this._separatorBetweenIdAndInfo, StringSplitOptions.RemoveEmptyEntries);
        int result;
        if (strArray.Length == 2 && int.TryParse(strArray[0], out result))
          dictionary[(NetGroupInfo.InfoProviderId) result] = strArray[1];
      }
      return dictionary;
    }

    private string ConvertToSafeInfo(string text) => Uri.EscapeDataString(text);

    private string ConvertFromSafeInfo(string text) => Uri.UnescapeDataString(text);

    public enum InfoProviderId
    {
      IPAddress,
      Steam,
    }

    private interface INetGroupInfoProvider
    {
      NetGroupInfo.InfoProviderId Id { get; }

      bool HasValidInfo { get; }

      string ProvideInfoNeededToJoin();
    }

    private class IPAddressInfoProvider : NetGroupInfo.INetGroupInfoProvider
    {
      public NetGroupInfo.InfoProviderId Id => NetGroupInfo.InfoProviderId.IPAddress;

      public bool HasValidInfo => false;

      public string ProvideInfoNeededToJoin() => "";
    }

    private class SteamLobbyInfoProvider : NetGroupInfo.INetGroupInfoProvider
    {
      public NetGroupInfo.InfoProviderId Id => NetGroupInfo.InfoProviderId.Steam;

      public bool HasValidInfo => Main.LobbyId > 0UL;

      public string ProvideInfoNeededToJoin() => Main.LobbyId.ToString();
    }
  }
}
