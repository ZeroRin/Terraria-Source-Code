// Decompiled with JetBrains decompiler
// Type: Terraria.Map.MapIconOverlay
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
