// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Ambience.AmbientSkyDrawCache
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
