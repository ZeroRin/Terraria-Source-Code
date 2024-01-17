// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.TileObjectCoordinatesModule
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using Terraria.DataStructures;

namespace Terraria.Modules
{
  public class TileObjectCoordinatesModule
  {
    public int width;
    public int[] heights;
    public int padding;
    public Point16 paddingFix;
    public int styleWidth;
    public int styleHeight;
    public bool calculated;
    public int drawStyleOffset;

    public TileObjectCoordinatesModule(TileObjectCoordinatesModule copyFrom = null, int[] drawHeight = null)
    {
      if (copyFrom == null)
      {
        this.width = 0;
        this.padding = 0;
        this.paddingFix = Point16.Zero;
        this.styleWidth = 0;
        this.drawStyleOffset = 0;
        this.styleHeight = 0;
        this.calculated = false;
        this.heights = drawHeight;
      }
      else
      {
        this.width = copyFrom.width;
        this.padding = copyFrom.padding;
        this.paddingFix = copyFrom.paddingFix;
        this.drawStyleOffset = copyFrom.drawStyleOffset;
        this.styleWidth = copyFrom.styleWidth;
        this.styleHeight = copyFrom.styleHeight;
        this.calculated = copyFrom.calculated;
        if (drawHeight == null)
        {
          if (copyFrom.heights == null)
          {
            this.heights = (int[]) null;
          }
          else
          {
            this.heights = new int[copyFrom.heights.Length];
            Array.Copy((Array) copyFrom.heights, (Array) this.heights, this.heights.Length);
          }
        }
        else
          this.heights = drawHeight;
      }
    }
  }
}
