// Decompiled with JetBrains decompiler
// Type: Terraria.Utilities.Terraria.Utilities.FloatRange
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
