﻿// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenShapeActionPair
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.WorldBuilding
{
  public struct GenShapeActionPair
  {
    public readonly GenShape Shape;
    public readonly GenAction Action;

    public GenShapeActionPair(GenShape shape, GenAction action)
    {
      this.Shape = shape;
      this.Action = action;
    }
  }
}