// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetCreativePowerPermissionsModule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.IO;
using Terraria.GameContent.Creative;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetCreativePowerPermissionsModule : NetModule
  {
    private const byte _setPermissionLevelId = 0;

    public static NetPacket SerializeCurrentPowerPermissionLevel(ushort powerId, int level)
    {
      NetPacket packet = NetModule.CreatePacket<NetCreativePowerPermissionsModule>(4);
      packet.Writer.Write((byte) 0);
      packet.Writer.Write(powerId);
      packet.Writer.Write((byte) level);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      if (reader.ReadByte() == (byte) 0)
      {
        ushort id = reader.ReadUInt16();
        int num = (int) reader.ReadByte();
        ICreativePower power;
        if (Main.netMode == 2 || !CreativePowerManager.Instance.TryGetPower(id, out power))
          return false;
        power.CurrentPermissionLevel = (PowerPermissionLevel) num;
      }
      return true;
    }
  }
}
