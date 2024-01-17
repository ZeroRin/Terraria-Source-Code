﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Shaders.ShaderData
// Assembly: Terraria, Version=1.4.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F541F3E5-89DE-4E5D-868F-1B56DAAB46B2
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Shaders
{
  public class ShaderData
  {
    private readonly Ref<Effect> _shader;
    private string _passName;
    private EffectPass _effectPass;

    public Effect Shader => this._shader != null ? this._shader.Value : (Effect) null;

    public ShaderData(Ref<Effect> shader, string passName)
    {
      this._passName = passName;
      this._shader = shader;
    }

    public void SwapProgram(string passName)
    {
      this._passName = passName;
      if (passName == null)
        return;
      this._effectPass = this.Shader.CurrentTechnique.Passes[passName];
    }

    public virtual void Apply()
    {
      if (this._shader != null && this.Shader != null && this._passName != null)
        this._effectPass = this.Shader.CurrentTechnique.Passes[this._passName];
      this._effectPass.Apply();
    }
  }
}
