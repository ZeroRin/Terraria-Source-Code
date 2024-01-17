// Decompiled with JetBrains decompiler
// Type: Terraria.Utilities.Terraria.Utilities.FloatRange
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Newtonsoft.Json;

namespace Terraria.Utilities.Terraria.Utilities
{
  public struct FloatRange
  {
    [JsonProperty("Min")]
    public readonly float Minimum;
    [JsonProperty("Max")]
    public readonly float Maximum;

    public FloatRange(float minimum, float maximum)
    {
      this.Minimum = minimum;
      this.Maximum = maximum;
    }

    public static FloatRange operator *(FloatRange range, float scale) => new FloatRange(range.Minimum * scale, range.Maximum * scale);

    public static FloatRange operator *(float scale, FloatRange range) => range * scale;

    public static FloatRange operator /(FloatRange range, float scale) => new FloatRange(range.Minimum / scale, range.Maximum / scale);

    public static FloatRange operator /(float scale, FloatRange range) => range / scale;
  }
}
