﻿// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.TileDrawSorter
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Collections.Generic;

namespace Terraria.DataStructures
{
  public class TileDrawSorter
  {
    public TileDrawSorter.TileTexPoint[] tilesToDraw;
    private int _holderLength;
    private int _currentCacheIndex;
    private TileDrawSorter.CustomComparer _tileComparer = new TileDrawSorter.CustomComparer();

    public TileDrawSorter()
    {
      this._currentCacheIndex = 0;
      this._holderLength = 9000;
      this.tilesToDraw = new TileDrawSorter.TileTexPoint[this._holderLength];
    }

    public void reset() => this._currentCacheIndex = 0;

    public void Cache(int x, int y, int type)
    {
      int index = this._currentCacheIndex++;
      this.tilesToDraw[index].X = x;
      this.tilesToDraw[index].Y = y;
      this.tilesToDraw[index].TileType = type;
      if (this._currentCacheIndex != this._holderLength)
        return;
      this.IncreaseArraySize();
    }

    private void IncreaseArraySize()
    {
      this._holderLength *= 2;
      Array.Resize<TileDrawSorter.TileTexPoint>(ref this.tilesToDraw, this._holderLength);
    }

    public void Sort() => Array.Sort<TileDrawSorter.TileTexPoint>(this.tilesToDraw, 0, this._currentCacheIndex, (IComparer<TileDrawSorter.TileTexPoint>) this._tileComparer);

    public int GetAmountToDraw() => this._currentCacheIndex;

    public struct TileTexPoint
    {
      public int X;
      public int Y;
      public int TileType;

      public override string ToString() => string.Format("X:{0}, Y:{1}, Type:{2}", (object) this.X, (object) this.Y, (object) this.TileType);
    }

    public class CustomComparer : Comparer<TileDrawSorter.TileTexPoint>
    {
      public override int Compare(TileDrawSorter.TileTexPoint x, TileDrawSorter.TileTexPoint y) => x.TileType.CompareTo(y.TileType);
    }
  }
}
