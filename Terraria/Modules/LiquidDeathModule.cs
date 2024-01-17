// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.LiquidDeathModule
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Modules
{
  public class LiquidDeathModule
  {
    public bool water;
    public bool lava;

    public LiquidDeathModule(LiquidDeathModule copyFrom = null)
    {
      if (copyFrom == null)
      {
        this.water = false;
        this.lava = false;
      }
      else
      {
        this.water = copyFrom.water;
        this.lava = copyFrom.lava;
      }
    }
  }
}
