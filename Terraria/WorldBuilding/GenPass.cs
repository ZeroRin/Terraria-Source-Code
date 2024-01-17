// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenPass
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
