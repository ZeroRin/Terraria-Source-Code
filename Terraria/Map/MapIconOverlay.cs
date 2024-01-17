// Decompiled with JetBrains decompiler
// Type: Terraria.Map.MapIconOverlay
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Terraria.Map
{
  public class MapIconOverlay
  {
    private readonly List<IMapLayer> _layers = new List<IMapLayer>();

    public MapIconOverlay AddLayer(IMapLayer layer)
    {
      this._layers.Add(layer);
      return this;
    }

    public void Draw(
      Vector2 mapPosition,
      Vector2 mapOffset,
      Rectangle? clippingRect,
      float mapScale,
      float drawScale,
      ref string text)
    {
      MapOverlayDrawContext context = new MapOverlayDrawContext(mapPosition, mapOffset, clippingRect, mapScale, drawScale);
      foreach (IMapLayer layer in this._layers)
        layer.Draw(ref context, ref text);
    }
  }
}
