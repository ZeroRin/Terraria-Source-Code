// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetPingModule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
