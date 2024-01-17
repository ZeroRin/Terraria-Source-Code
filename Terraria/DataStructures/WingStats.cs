// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.WingStats
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.DataStructures
{
  public struct WingStats
  {
    public static readonly WingStats Default;
    public int FlyTime;
    public float AccRunSpeedOverride;
    public float AccRunAccelerationMult;
    public bool HasDownHoverStats;
    public float DownHoverSpeedOverride;
    public float DownHoverAccelerationMult;

    public WingStats(
      int flyTime = 100,
      float flySpeedOverride = -1f,
      float accelerationMultiplier = 1f,
      bool hasHoldDownHoverFeatures = false,
      float hoverFlySpeedOverride = -1f,
      float hoverAccelerationMultiplier = 1f)
    {
      this.FlyTime = flyTime;
      this.AccRunSpeedOverride = flySpeedOverride;
      this.AccRunAccelerationMult = accelerationMultiplier;
      this.HasDownHoverStats = hasHoldDownHoverFeatures;
      this.DownHoverSpeedOverride = hoverFlySpeedOverride;
      this.DownHoverAccelerationMult = hoverAccelerationMultiplier;
    }

    public WingStats WithSpeedBoost(float multiplier) => new WingStats(this.FlyTime, this.AccRunSpeedOverride * multiplier, this.AccRunAccelerationMult, this.HasDownHoverStats, this.DownHoverSpeedOverride * multiplier, this.DownHoverAccelerationMult);
  }
}
