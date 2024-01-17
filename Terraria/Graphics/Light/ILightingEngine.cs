// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Light.ILightingEngine
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.Graphics.Light
{
  public interface ILightingEngine
  {
    void Rebuild();

    void AddLight(int x, int y, Vector3 color);

    void ProcessArea(Rectangle area);

    Vector3 GetColor(int x, int y);

    void Clear();
  }
}
