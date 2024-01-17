// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.AProjectileSource_Tile
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.DataStructures
{
  public abstract class AProjectileSource_Tile : IProjectileSource
  {
    public readonly Point TileCoords;

    public AProjectileSource_Tile(int tileCoordsX, int tileCoordsY) => this.TileCoords = new Point(tileCoordsX, tileCoordsY);
  }
}
