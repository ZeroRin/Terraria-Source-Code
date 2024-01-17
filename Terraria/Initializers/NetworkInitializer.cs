// Decompiled with JetBrains decompiler
// Type: Terraria.Initializers.NetworkInitializer
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.GameContent.NetModules;
using Terraria.Net;

namespace Terraria.Initializers
{
  public static class NetworkInitializer
  {
    public static void Load()
    {
      NetManager.Instance.Register<NetLiquidModule>();
      NetManager.Instance.Register<NetTextModule>();
      NetManager.Instance.Register<NetPingModule>();
      NetManager.Instance.Register<NetAmbienceModule>();
      NetManager.Instance.Register<NetBestiaryModule>();
      NetManager.Instance.Register<NetCreativeUnlocksModule>();
      NetManager.Instance.Register<NetCreativePowersModule>();
      NetManager.Instance.Register<NetCreativeUnlocksPlayerReportModule>();
      NetManager.Instance.Register<NetTeleportPylonModule>();
      NetManager.Instance.Register<NetParticlesModule>();
      NetManager.Instance.Register<NetCreativePowerPermissionsModule>();
    }
  }
}
