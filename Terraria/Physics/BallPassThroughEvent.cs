// Decompiled with JetBrains decompiler
// Type: Terraria.Physics.BallPassThroughEvent
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Physics
{
  public struct BallPassThroughEvent
  {
    public readonly Tile Tile;
    public readonly Entity Entity;
    public readonly BallPassThroughType Type;
    public readonly float TimeScale;

    public BallPassThroughEvent(
      float timeScale,
      Tile tile,
      Entity entity,
      BallPassThroughType type)
    {
      this.Tile = tile;
      this.Entity = entity;
      this.Type = type;
      this.TimeScale = timeScale;
    }
  }
}
