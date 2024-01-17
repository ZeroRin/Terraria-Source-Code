// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.LiquidPlacementModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.Enums;

namespace Terraria.Modules
{
  public class LiquidPlacementModule
  {
    public LiquidPlacement water;
    public LiquidPlacement lava;

    public LiquidPlacementModule(LiquidPlacementModule copyFrom = null)
    {
      if (copyFrom == null)
      {
        this.water = LiquidPlacement.Allowed;
        this.lava = LiquidPlacement.Allowed;
      }
      else
      {
        this.water = copyFrom.water;
        this.lava = copyFrom.lava;
      }
    }
  }
}
