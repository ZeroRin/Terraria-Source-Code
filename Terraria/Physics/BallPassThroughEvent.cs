// Decompiled with JetBrains decompiler
// Type: Terraria.Physics.BallPassThroughEvent
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
