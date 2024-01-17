// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenBase
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.Utilities;

namespace Terraria.WorldBuilding
{
  public class GenBase
  {
    protected static UnifiedRandom _random => WorldGen.genRand;

    protected static Tile[,] _tiles => Main.tile;

    protected static int _worldWidth => Main.maxTilesX;

    protected static int _worldHeight => Main.maxTilesY;

    public delegate bool CustomPerUnitAction(int x, int y, params object[] args);
  }
}
