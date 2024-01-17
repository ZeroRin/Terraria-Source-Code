// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetCreativePowersModule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
