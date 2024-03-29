﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Camera
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics
{
  public class Camera
  {
    public Vector2 UnscaledPosition => Main.screenPosition;

    public Vector2 UnscaledSize => new Vector2((float) Main.screenWidth, (float) Main.screenHeight);

    public Vector2 ScaledPosition => this.UnscaledPosition + this.GameViewMatrix.Translation;

    public Vector2 ScaledSize => this.UnscaledSize - this.GameViewMatrix.Translation * 2f;

    public RasterizerState Rasterizer => Main.Rasterizer;

    public SamplerState Sampler => Main.DefaultSamplerState;

    public SpriteViewMatrix GameViewMatrix => Main.GameViewMatrix;

    public SpriteBatch SpriteBatch => Main.spriteBatch;

    public Vector2 Center => this.UnscaledPosition + this.UnscaledSize * 0.5f;
  }
}
