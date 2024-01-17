// Decompiled with JetBrains decompiler
// Type: Terraria.Modules.TileObjectDrawModule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Modules
{
  public class TileObjectDrawModule
  {
    public int xOffset;
    public int yOffset;
    public bool flipHorizontal;
    public bool flipVertical;
    public int stepDown;

    public TileObjectDrawModule(TileObjectDrawModule copyFrom = null)
    {
      if (copyFrom == null)
      {
        this.xOffset = 0;
        this.yOffset = 0;
        this.flipHorizontal = false;
        this.flipVertical = false;
        this.stepDown = 0;
      }
      else
      {
        this.xOffset = copyFrom.xOffset;
        this.yOffset = copyFrom.yOffset;
        this.flipHorizontal = copyFrom.flipHorizontal;
        this.flipVertical = copyFrom.flipVertical;
        this.stepDown = copyFrom.stepDown;
      }
    }
  }
}
