// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Effects.GameEffect
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.Graphics.Effects
{
  public abstract class GameEffect
  {
    public float Opacity;
    protected bool _isLoaded;
    protected EffectPriority _priority;

    public bool IsLoaded => this._isLoaded;

    public EffectPriority Priority => this._priority;

    public void Load()
    {
      if (this._isLoaded)
        return;
      this._isLoaded = true;
      this.OnLoad();
    }

    public virtual void OnLoad()
    {
    }

    public abstract bool IsVisible();

    public abstract void Activate(Vector2 position, params object[] args);

    public abstract void Deactivate(params object[] args);
  }
}
