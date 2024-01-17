// Decompiled with JetBrains decompiler
// Type: Terraria.Utilities.IntRange
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Newtonsoft.Json;

namespace Terraria.Utilities
{
  public struct IntRange
  {
    [JsonProperty("Min")]
    public readonly int Minimum;
    [JsonProperty("Max")]
    public readonly int Maximum;

    public IntRange(int minimum, int maximum)
    {
      this.Minimum = minimum;
      this.Maximum = maximum;
    }

    public static IntRange operator *(IntRange range, float scale) => new IntRange((int) ((double) range.Minimum * (double) scale), (int) ((double) range.Maximum * (double) scale));

    public static IntRange operator *(float scale, IntRange range) => range * scale;

    public static IntRange operator /(IntRange range, float scale) => new IntRange((int) ((double) range.Minimum / (double) scale), (int) ((double) range.Maximum / (double) scale));

    public static IntRange operator /(float scale, IntRange range) => range / scale;
  }
}
