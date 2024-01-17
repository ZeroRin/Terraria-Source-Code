// Decompiled with JetBrains decompiler
// Type: Terraria.World
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria
{
  public class World
  {
    public Tile[,] Tiles => Main.tile;

    public int TileColumns => Main.maxTilesX;

    public int TileRows => Main.maxTilesY;

    public Player[] Players => Main.player;
  }
}
