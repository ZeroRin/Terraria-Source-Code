﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetBestiaryModule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.IO;
using Terraria.ID;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetBestiaryModule : NetModule
  {
    public static NetPacket SerializeKillCount(int npcNetId, int killcount)
    {
      NetPacket packet = NetModule.CreatePacket<NetBestiaryModule>(5);
      packet.Writer.Write((byte) 0);
      packet.Writer.Write((short) npcNetId);
      packet.Writer.Write((ushort) killcount);
      return packet;
    }

    public static NetPacket SerializeSight(int npcNetId)
    {
      NetPacket packet = NetModule.CreatePacket<NetBestiaryModule>(3);
      packet.Writer.Write((byte) 1);
      packet.Writer.Write((short) npcNetId);
      return packet;
    }

    public static NetPacket SerializeChat(int npcNetId)
    {
      NetPacket packet = NetModule.CreatePacket<NetBestiaryModule>(3);
      packet.Writer.Write((byte) 2);
      packet.Writer.Write((short) npcNetId);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      switch (reader.ReadByte())
      {
        case 0:
          short key1 = reader.ReadInt16();
          string bestiaryCreditId1 = ContentSamples.NpcsByNetId[(int) key1].GetBestiaryCreditId();
          ushort killCount = reader.ReadUInt16();
          Main.BestiaryTracker.Kills.SetKillCountDirectly(bestiaryCreditId1, (int) killCount);
          break;
        case 1:
          short key2 = reader.ReadInt16();
          string bestiaryCreditId2 = ContentSamples.NpcsByNetId[(int) key2].GetBestiaryCreditId();
          Main.BestiaryTracker.Sights.SetWasSeenDirectly(bestiaryCreditId2);
          break;
        case 2:
          short key3 = reader.ReadInt16();
          string bestiaryCreditId3 = ContentSamples.NpcsByNetId[(int) key3].GetBestiaryCreditId();
          Main.BestiaryTracker.Chats.SetWasChatWithDirectly(bestiaryCreditId3);
          break;
      }
      return true;
    }

    private enum BestiaryUnlockType : byte
    {
      Kill,
      Sight,
      Chat,
    }
  }
}
