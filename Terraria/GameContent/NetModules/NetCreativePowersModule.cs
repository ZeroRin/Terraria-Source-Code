// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetCreativePowersModule
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.IO;
using Terraria.GameContent.Creative;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetCreativePowersModule : NetModule
  {
    public static NetPacket PreparePacket(ushort powerId, int specificInfoBytesInPacketCount)
    {
      NetPacket packet = NetModule.CreatePacket<NetCreativePowersModule>(specificInfoBytesInPacketCount + 2);
      packet.Writer.Write(powerId);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      ushort id = reader.ReadUInt16();
      ICreativePower power;
      if (!CreativePowerManager.Instance.TryGetPower(id, out power))
        return false;
      power.DeserializeNetMessage(reader, userId);
      return true;
    }
  }
}
