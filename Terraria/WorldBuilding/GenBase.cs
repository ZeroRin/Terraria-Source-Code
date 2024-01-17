// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenBase
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
