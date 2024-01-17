// Decompiled with JetBrains decompiler
// Type: Terraria.Physics.BallCollisionEvent
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.Physics
{
  public struct BallCollisionEvent
  {
    public readonly Vector2 Normal;
    public readonly Vector2 ImpactPoint;
    public readonly Tile Tile;
    public readonly Entity Entity;
    public readonly float TimeScale;

    public BallCollisionEvent(
      float timeScale,
      Vector2 normal,
      Vector2 impactPoint,
      Tile tile,
      Entity entity)
    {
      this.Normal = normal;
      this.ImpactPoint = impactPoint;
      this.Tile = tile;
      this.Entity = entity;
      this.TimeScale = timeScale;
    }
  }
}
