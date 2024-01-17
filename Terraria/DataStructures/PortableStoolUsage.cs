// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.PortableStoolUsage
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.DataStructures
{
  public struct PortableStoolUsage
  {
    public bool HasAStool;
    public bool IsInUse;
    public int HeightBoost;
    public int VisualYOffset;
    public int MapYOffset;

    public void Reset()
    {
      this.HasAStool = false;
      this.IsInUse = false;
      this.HeightBoost = 0;
      this.VisualYOffset = 0;
      this.MapYOffset = 0;
    }

    public void SetStats(int heightBoost, int visualYOffset, int mapYOffset)
    {
      this.HasAStool = true;
      this.HeightBoost = heightBoost;
      this.VisualYOffset = visualYOffset;
      this.MapYOffset = mapYOffset;
    }
  }
}
