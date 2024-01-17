﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.SandstormSky
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent.Events;
using Terraria.Graphics.Effects;
using Terraria.Utilities;

namespace Terraria.GameContent.Skies
{
  public class SandstormSky : CustomSky
  {
    private UnifiedRandom _random = new UnifiedRandom();
    private bool _isActive;
    private bool _isLeaving;
    private float _opacity;

    public override void OnLoad()
    {
    }

    public override void Update(GameTime gameTime)
    {
      if (Main.gamePaused || !Main.hasFocus)
        return;
      if (this._isLeaving)
      {
        this._opacity -= (float) gameTime.ElapsedGameTime.TotalSeconds;
        if ((double) this._opacity >= 0.0)
          return;
        this._isActive = false;
        this._opacity = 0.0f;
      }
      else
      {
        this._opacity += (float) gameTime.ElapsedGameTime.TotalSeconds;
        if ((double) this._opacity <= 1.0)
          return;
        this._opacity = 1f;
      }
    }

    public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
    {
      if ((double) minDepth >= 1.0 && (double) maxDepth != 3.4028234663852886E+38)
        return;
      float num = Math.Min(1f, Sandstorm.Severity * 1.5f);
      Color color = new Color(new Vector4(0.85f, 0.66f, 0.33f, 1f) * 0.8f * Main.ColorOfTheSkies.ToVector4()) * this._opacity * num;
      spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), color);
    }

    public override void Activate(Vector2 position, params object[] args)
    {
      this._isActive = true;
      this._isLeaving = false;
    }

    public override void Deactivate(params object[] args) => this._isLeaving = true;

    public override void Reset()
    {
      this._opacity = 0.0f;
      this._isActive = false;
    }

    public override bool IsActive() => this._isActive;
  }
}
