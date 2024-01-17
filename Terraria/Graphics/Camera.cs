// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Camera
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
