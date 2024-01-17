﻿// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenPass
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using Terraria.IO;

namespace Terraria.WorldBuilding
{
  public abstract class GenPass : GenBase
  {
    public string Name;
    public float Weight;
    private Action<GenPass> _onComplete;
    private Action<GenPass> _onBegin;

    public GenPass(string name, float loadWeight)
    {
      this.Name = name;
      this.Weight = loadWeight;
    }

    protected abstract void ApplyPass(GenerationProgress progress, GameConfiguration configuration);

    public void Apply(GenerationProgress progress, GameConfiguration configuration)
    {
      if (this._onBegin != null)
        this._onBegin(this);
      this.ApplyPass(progress, configuration);
      if (this._onComplete == null)
        return;
      this._onComplete(this);
    }

    public GenPass OnBegin(Action<GenPass> beginAction)
    {
      this._onBegin = beginAction;
      return this;
    }

    public GenPass OnComplete(Action<GenPass> completionAction)
    {
      this._onComplete = completionAction;
      return this;
    }
  }
}
