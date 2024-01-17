// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetAmbienceModule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.IO;
using Terraria.GameContent.Ambience;
using Terraria.GameContent.Skies;
using Terraria.Graphics.Effects;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetAmbienceModule : NetModule
  {
    public static NetPacket SerializeSkyEntitySpawn(Player player, SkyEntityType type)
    {
      int num = Main.rand.Next();
      NetPacket packet = NetModule.CreatePacket<NetAmbienceModule>(6);
      packet.Writer.Write((byte) player.whoAmI);
      packet.Writer.Write(num);
      packet.Writer.Write((byte) type);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      byte playerId = reader.ReadByte();
      int seed = reader.ReadInt32();
      SkyEntityType type = (SkyEntityType) reader.ReadByte();
      Main.QueueMainThreadAction((Action) (() => ((AmbientSky) SkyManager.Instance["Ambience"]).Spawn(Main.player[(int) playerId], type, seed)));
      return true;
    }
  }
}
