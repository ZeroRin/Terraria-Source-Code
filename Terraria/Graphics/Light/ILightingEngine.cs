// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Light.ILightingEngine
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
