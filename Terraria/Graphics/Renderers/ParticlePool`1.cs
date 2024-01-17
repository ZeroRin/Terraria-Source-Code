﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Renderers.ParticlePool`1
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.Graphics.Renderers
{
  public class ParticlePool<T> where T : IPooledParticle
  {
    private ParticlePool<T>.ParticleInstantiator _instantiator;
    private List<T> _particles;

    public ParticlePool(int initialPoolSize, ParticlePool<T>.ParticleInstantiator instantiator)
    {
      this._particles = new List<T>(initialPoolSize);
      this._instantiator = instantiator;
    }

    public T RequestParticle()
    {
      int count = this._particles.Count;
      for (int index = 0; index < count; ++index)
      {
        T particle = this._particles[index];
        if (particle.IsRestingInPool)
        {
          particle = this._particles[index];
          particle.FetchFromPool();
          return this._particles[index];
        }
      }
      T obj = this._instantiator();
      this._particles.Add(obj);
      obj.FetchFromPool();
      return obj;
    }

    public delegate T ParticleInstantiator() where T : IPooledParticle;
  }
}
