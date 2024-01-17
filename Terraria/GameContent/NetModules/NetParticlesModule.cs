// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetParticlesModule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.IO;
using Terraria.GameContent.Drawing;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetParticlesModule : NetModule
  {
    public static NetPacket Serialize(
      ParticleOrchestraType particleType,
      ParticleOrchestraSettings settings)
    {
      NetPacket packet = NetModule.CreatePacket<NetParticlesModule>(22);
      packet.Writer.Write((byte) particleType);
      settings.Serialize(packet.Writer);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      ParticleOrchestraType particleOrchestraType = (ParticleOrchestraType) reader.ReadByte();
      ParticleOrchestraSettings settings = new ParticleOrchestraSettings();
      settings.DeserializeFrom(reader);
      if (Main.netMode == 2)
        NetManager.Instance.Broadcast(NetParticlesModule.Serialize(particleOrchestraType, settings), userId);
      else
        ParticleOrchestrator.SpawnParticlesDirect(particleOrchestraType, settings);
      return true;
    }
  }
}
