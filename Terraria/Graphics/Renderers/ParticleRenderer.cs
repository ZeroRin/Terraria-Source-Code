﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Renderers.ParticleRenderer
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Terraria.Graphics.Renderers
{
  public class ParticleRenderer
  {
    public ParticleRendererSettings Settings;
    public List<IParticle> Particles = new List<IParticle>();

    public ParticleRenderer() => this.Settings = new ParticleRendererSettings();

    public void Add(IParticle particle) => this.Particles.Add(particle);

    public void Update()
    {
      for (int index = 0; index < this.Particles.Count; ++index)
      {
        if (this.Particles[index].ShouldBeRemovedFromRenderer)
        {
          if (this.Particles[index] is IPooledParticle particle)
            particle.RestInPool();
          this.Particles.RemoveAt(index);
          --index;
        }
        else
          this.Particles[index].Update(ref this.Settings);
      }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
      for (int index = 0; index < this.Particles.Count; ++index)
      {
        if (!this.Particles[index].ShouldBeRemovedFromRenderer)
          this.Particles[index].Draw(ref this.Settings, spriteBatch);
      }
    }
  }
}
