﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetPingModule
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System.IO;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetPingModule : NetModule
  {
    public static NetPacket Serialize(Vector2 position)
    {
      NetPacket packet = NetModule.CreatePacket<NetPingModule>(8);
      packet.Writer.WriteVector2(position);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      Vector2 position = reader.ReadVector2();
      Main.Pings.Add(position);
      return true;
    }
  }
}
