﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.ShapeFloodFill
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Generation
{
  public class ShapeFloodFill : GenShape
  {
    private int _maximumActions;

    public ShapeFloodFill(int maximumActions = 100) => this._maximumActions = maximumActions;

    public override bool Perform(Point origin, GenAction action)
    {
      Queue<Point> pointQueue = new Queue<Point>();
      HashSet<Point16> point16Set = new HashSet<Point16>();
      pointQueue.Enqueue(origin);
      int maximumActions = this._maximumActions;
      while (pointQueue.Count > 0 && maximumActions > 0)
      {
        Point point = pointQueue.Dequeue();
        if (!point16Set.Contains(new Point16(point.X, point.Y)) && this.UnitApply(action, origin, point.X, point.Y))
        {
          point16Set.Add(new Point16(point));
          --maximumActions;
          if (point.X + 1 < Main.maxTilesX - 1)
            pointQueue.Enqueue(new Point(point.X + 1, point.Y));
          if (point.X - 1 >= 1)
            pointQueue.Enqueue(new Point(point.X - 1, point.Y));
          if (point.Y + 1 < Main.maxTilesY - 1)
            pointQueue.Enqueue(new Point(point.X, point.Y + 1));
          if (point.Y - 1 >= 1)
            pointQueue.Enqueue(new Point(point.X, point.Y - 1));
        }
      }
      while (pointQueue.Count > 0)
      {
        Point point = pointQueue.Dequeue();
        if (!point16Set.Contains(new Point16(point.X, point.Y)))
        {
          pointQueue.Enqueue(point);
          break;
        }
      }
      return pointQueue.Count == 0;
    }
  }
}
