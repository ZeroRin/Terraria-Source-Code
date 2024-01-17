// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.TileObjectStyleModule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Modules
{
  public class TileObjectStyleModule
  {
    public int style;
    public bool horizontal;
    public int styleWrapLimit;
    public int styleMultiplier;
    public int styleLineSkip;
    public int? styleWrapLimitVisualOverride;
    public int? styleLineSkipVisualoverride;

    public TileObjectStyleModule(TileObjectStyleModule copyFrom = null)
    {
      if (copyFrom == null)
      {
        this.style = 0;
        this.horizontal = false;
        this.styleWrapLimit = 0;
        this.styleWrapLimitVisualOverride = new int?();
        this.styleLineSkipVisualoverride = new int?();
        this.styleMultiplier = 1;
        this.styleLineSkip = 1;
      }
      else
      {
        this.style = copyFrom.style;
        this.horizontal = copyFrom.horizontal;
        this.styleWrapLimit = copyFrom.styleWrapLimit;
        this.styleMultiplier = copyFrom.styleMultiplier;
        this.styleLineSkip = copyFrom.styleLineSkip;
        this.styleWrapLimitVisualOverride = copyFrom.styleWrapLimitVisualOverride;
        this.styleLineSkipVisualoverride = copyFrom.styleLineSkipVisualoverride;
      }
    }
  }
}
