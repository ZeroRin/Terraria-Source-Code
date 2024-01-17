﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetTeleportPylonModule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.IO;
using Terraria.DataStructures;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetTeleportPylonModule : NetModule
  {
    public static NetPacket SerializePylonWasAddedOrRemoved(
      TeleportPylonInfo info,
      NetTeleportPylonModule.SubPacketType packetType)
    {
      NetPacket packet = NetModule.CreatePacket<NetTeleportPylonModule>(6);
      packet.Writer.Write((byte) packetType);
      packet.Writer.Write(info.PositionInTiles.X);
      packet.Writer.Write(info.PositionInTiles.Y);
      packet.Writer.Write((byte) info.TypeOfPylon);
      return packet;
    }

    public static NetPacket SerializeUseRequest(TeleportPylonInfo info)
    {
      NetPacket packet = NetModule.CreatePacket<NetTeleportPylonModule>(6);
      packet.Writer.Write((byte) 2);
      packet.Writer.Write(info.PositionInTiles.X);
      packet.Writer.Write(info.PositionInTiles.Y);
      packet.Writer.Write((byte) info.TypeOfPylon);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      switch (reader.ReadByte())
      {
        case 0:
          Main.PylonSystem.AddForClient(new TeleportPylonInfo()
          {
            PositionInTiles = new Point16(reader.ReadInt16(), reader.ReadInt16()),
            TypeOfPylon = (TeleportPylonType) reader.ReadByte()
          });
          break;
        case 1:
          Main.PylonSystem.RemoveForClient(new TeleportPylonInfo()
          {
            PositionInTiles = new Point16(reader.ReadInt16(), reader.ReadInt16()),
            TypeOfPylon = (TeleportPylonType) reader.ReadByte()
          });
          break;
        case 2:
          Main.PylonSystem.HandleTeleportRequest(new TeleportPylonInfo()
          {
            PositionInTiles = new Point16(reader.ReadInt16(), reader.ReadInt16()),
            TypeOfPylon = (TeleportPylonType) reader.ReadByte()
          }, userId);
          break;
      }
      return true;
    }

    public enum SubPacketType : byte
    {
      PylonWasAdded,
      PylonWasRemoved,
      PlayerRequestsTeleport,
    }
  }
}
