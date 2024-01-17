﻿// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.TileDataType
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
