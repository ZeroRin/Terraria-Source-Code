// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetCreativeUnlocksPlayerReportModule
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.IO;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetCreativeUnlocksPlayerReportModule : NetModule
  {
    private const byte _requestItemSacrificeId = 0;

    public static NetPacket SerializeSacrificeRequest(int itemId, int amount)
    {
      NetPacket packet = NetModule.CreatePacket<NetCreativeUnlocksPlayerReportModule>(5);
      packet.Writer.Write((byte) 0);
      packet.Writer.Write((ushort) itemId);
      packet.Writer.Write((ushort) amount);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      if (reader.ReadByte() == (byte) 0)
      {
        int num1 = (int) reader.ReadUInt16();
        int num2 = (int) reader.ReadUInt16();
      }
      return true;
    }
  }
}
