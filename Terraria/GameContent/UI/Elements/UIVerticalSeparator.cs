﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIVerticalSeparator
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIVerticalSeparator : UIElement
  {
    private Asset<Texture2D> _texture;
    public Color Color;
    public int EdgeWidth;

    public UIVerticalSeparator()
    {
      this.Color = Color.White;
      this._texture = Main.Assets.Request<Texture2D>("Images/UI/OnePixel", (AssetRequestMode) 1);
      this.Width.Set((float) this._texture.Width(), 0.0f);
      this.Height.Set((float) this._texture.Height(), 0.0f);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      CalculatedStyle dimensions = this.GetDimensions();
      spriteBatch.Draw(this._texture.Value, dimensions.ToRectangle(), this.Color);
    }

    public override bool ContainsPoint(Vector2 point) => false;
  }
}