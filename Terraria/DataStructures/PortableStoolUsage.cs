// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.PortableStoolUsage
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
