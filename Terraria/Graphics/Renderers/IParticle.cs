// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Renderers.IParticle
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Renderers
{
  public interface IParticle
  {
    bool ShouldBeRemovedFromRenderer { get; }

    void Update(ref ParticleRendererSettings settings);

    void Draw(ref ParticleRendererSettings settings, SpriteBatch spritebatch);
  }
}
