// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Effects.Overlay
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Effects
{
  public abstract class Overlay : GameEffect
  {
    public OverlayMode Mode = OverlayMode.Inactive;
    private RenderLayers _layer = RenderLayers.All;

    public RenderLayers Layer => this._layer;

    public Overlay(EffectPriority priority, RenderLayers layer)
    {
      this._priority = priority;
      this._layer = layer;
    }

    public abstract void Draw(SpriteBatch spriteBatch);

    public abstract void Update(GameTime gameTime);
  }
}
