﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UISelectableTextPanel`1
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UISelectableTextPanel<T> : UITextPanel<T>
  {
    private readonly Asset<Texture2D> _BasePanelTexture;
    private readonly Asset<Texture2D> _hoveredBorderTexture;
    private Func<UISelectableTextPanel<T>, bool> _isSelected;

    public Func<UISelectableTextPanel<T>, bool> IsSelected
    {
      get => this._isSelected;
      set => this._isSelected = value;
    }

    public UISelectableTextPanel(T text, float textScale = 1f, bool large = false)
      : base(text, textScale, large)
    {
      this._BasePanelTexture = Main.Assets.Request<Texture2D>("Images/UI/CharCreation/PanelGrayscale", (AssetRequestMode) 1);
      this._hoveredBorderTexture = Main.Assets.Request<Texture2D>("Images/UI/CharCreation/CategoryPanelBorder", (AssetRequestMode) 1);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      if (this._drawPanel)
      {
        CalculatedStyle dimensions = this.GetDimensions();
        int num1 = 4;
        int num2 = 10;
        int num3 = 10;
        Utils.DrawSplicedPanel(spriteBatch, this._BasePanelTexture.Value, (int) dimensions.X, (int) dimensions.Y, (int) dimensions.Width, (int) dimensions.Height, num2, num2, num3, num3, Color.Lerp(Color.Black, this._color, 0.8f) * 0.5f);
        if (this.IsSelected != null && this.IsSelected(this))
          Utils.DrawSplicedPanel(spriteBatch, this._BasePanelTexture.Value, (int) dimensions.X + num1, (int) dimensions.Y + num1, (int) dimensions.Width - num1 * 2, (int) dimensions.Height - num1 * 2, num2, num2, num3, num3, Color.Lerp(this._color, Color.White, 0.7f) * 0.5f);
        if (this.IsMouseHovering)
          Utils.DrawSplicedPanel(spriteBatch, this._hoveredBorderTexture.Value, (int) dimensions.X, (int) dimensions.Y, (int) dimensions.Width, (int) dimensions.Height, num2, num2, num3, num3, Color.White);
      }
      this.DrawText(spriteBatch);
    }
  }
}
