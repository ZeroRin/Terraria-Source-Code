// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.TileDataType
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;

namespace Terraria.DataStructures
{
  [Flags]
  public enum TileDataType
  {
    Tile = 1,
    TilePaint = 2,
    Wall = 4,
    WallPaint = 8,
    Liquid = 16, // 0x00000010
    Wiring = 32, // 0x00000020
    Actuator = 64, // 0x00000040
    Slope = 128, // 0x00000080
    All = Slope | Actuator | Wiring | Liquid | WallPaint | Wall | TilePaint | Tile, // 0x000000FF
  }
}
