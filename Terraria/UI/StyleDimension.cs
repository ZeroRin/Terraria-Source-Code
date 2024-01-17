// Decompiled with JetBrains decompiler
// Type: Terraria.UI.StyleDimension
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.UI
{
  public struct StyleDimension
  {
    public static StyleDimension Fill = new StyleDimension(0.0f, 1f);
    public static StyleDimension Empty = new StyleDimension(0.0f, 0.0f);
    public float Pixels;
    public float Precent;

    public StyleDimension(float pixels, float precent)
    {
      this.Pixels = pixels;
      this.Precent = precent;
    }

    public void Set(float pixels, float precent)
    {
      this.Pixels = pixels;
      this.Precent = precent;
    }

    public float GetValue(float containerSize) => this.Pixels + this.Precent * containerSize;

    public static StyleDimension FromPixels(float pixels) => new StyleDimension(pixels, 0.0f);

    public static StyleDimension FromPercent(float percent) => new StyleDimension(0.0f, percent);

    public static StyleDimension FromPixelsAndPercent(float pixels, float percent) => new StyleDimension(pixels, percent);
  }
}
