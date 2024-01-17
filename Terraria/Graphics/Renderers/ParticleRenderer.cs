// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Renderers.ParticleRenderer
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
