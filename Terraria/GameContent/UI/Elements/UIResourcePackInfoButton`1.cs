﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIResourcePackInfoButton`1
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.IO;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIResourcePackInfoButton<T> : UITextPanel<T>
  {
    private readonly Asset<Texture2D> _BasePanelTexture;
    private readonly Asset<Texture2D> _hoveredBorderTexture;
    private ResourcePack _resourcePack;

    public ResourcePack ResourcePack
    {
      get => this._resourcePack;
      set => this._resourcePack = value;
    }

    public UIResourcePackInfoButton(T text, float textScale = 1f, bool large = false)
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
        int num1 = 10;
        int num2 = 10;
        Utils.DrawSplicedPanel(spriteBatch, this._BasePanelTexture.Value, (int) dimensions.X, (int) dimensions.Y, (int) dimensions.Width, (int) dimensions.Height, num1, num1, num2, num2, Color.Lerp(Color.Black, this._color, 0.8f) * 0.5f);
        if (this.IsMouseHovering)
          Utils.DrawSplicedPanel(spriteBatch, this._hoveredBorderTexture.Value, (int) dimensions.X, (int) dimensions.Y, (int) dimensions.Width, (int) dimensions.Height, num1, num1, num2, num2, Color.White);
      }
      this.DrawText(spriteBatch);
    }
  }
}
