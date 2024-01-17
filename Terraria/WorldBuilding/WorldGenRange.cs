// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.WorldGenRange
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Terraria.Utilities;

namespace Terraria.WorldBuilding
{
  public class WorldGenRange
  {
    public static readonly WorldGenRange Empty = new WorldGenRange(0, 0);
    [JsonProperty("Min")]
    public readonly int Minimum;
    [JsonProperty("Max")]
    public readonly int Maximum;
    [JsonProperty]
    [JsonConverter(typeof (StringEnumConverter))]
    public readonly WorldGenRange.ScalingMode ScaleWith;

    public int ScaledMinimum => this.ScaleValue(this.Minimum);

    public int ScaledMaximum => this.ScaleValue(this.Maximum);

    public WorldGenRange(int minimum, int maximum)
    {
      this.Minimum = minimum;
      this.Maximum = maximum;
    }

    public int GetRandom(UnifiedRandom random) => random.Next(this.ScaledMinimum, this.ScaledMaximum + 1);

    private int ScaleValue(int value)
    {
      float num = 1f;
      switch (this.ScaleWith)
      {
        case WorldGenRange.ScalingMode.None:
          num = 1f;
          break;
        case WorldGenRange.ScalingMode.WorldArea:
          num = (float) (Main.maxTilesX * Main.maxTilesY) / 5040000f;
          break;
        case WorldGenRange.ScalingMode.WorldWidth:
          num = (float) Main.maxTilesX / 4200f;
          break;
      }
      return (int) ((double) num * (double) value);
    }

    public enum ScalingMode
    {
      None,
      WorldArea,
      WorldWidth,
    }
  }
}
