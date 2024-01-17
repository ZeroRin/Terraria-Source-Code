// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Ambience.AmbientSkyDrawCache
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.GameContent.Ambience
{
  public class AmbientSkyDrawCache
  {
    public static AmbientSkyDrawCache Instance = new AmbientSkyDrawCache();
    public AmbientSkyDrawCache.UnderworldCache[] Underworld = new AmbientSkyDrawCache.UnderworldCache[5];
    public AmbientSkyDrawCache.OceanLineCache OceanLineInfo;

    public void SetUnderworldInfo(int drawIndex, float scale) => this.Underworld[drawIndex] = new AmbientSkyDrawCache.UnderworldCache()
    {
      Scale = scale
    };

    public void SetOceanLineInfo(float yScreenPosition, float oceanOpacity) => this.OceanLineInfo = new AmbientSkyDrawCache.OceanLineCache()
    {
      YScreenPosition = yScreenPosition,
      OceanOpacity = oceanOpacity
    };

    public struct UnderworldCache
    {
      public float Scale;
    }

    public struct OceanLineCache
    {
      public float YScreenPosition;
      public float OceanOpacity;
    }
  }
}
