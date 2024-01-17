﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIKeybindingSimpleListItem
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Elements
{
  public class UIKeybindingSimpleListItem : UIElement
  {
    private Color _color;
    private Func<string> _GetTextFunction;

    public UIKeybindingSimpleListItem(Func<string> getText, Color color)
    {
      this._color = color;
      this._GetTextFunction = getText != null ? getText : (Func<string>) (() => "???");
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      float num1 = 6f;
      base.DrawSelf(spriteBatch);
      CalculatedStyle dimensions = this.GetDimensions();
      float num2 = dimensions.Width + 1f;
      Vector2 vector2 = new Vector2(dimensions.X, dimensions.Y);
      Vector2 baseScale = new Vector2(0.8f);
      Color baseColor = Color.Lerp(this.IsMouseHovering ? Color.White : Color.Silver, Color.White, this.IsMouseHovering ? 0.5f : 0.0f);
      Color color = this.IsMouseHovering ? this._color : this._color.MultiplyRGBA(new Color(180, 180, 180));
      Vector2 position = vector2;
      Utils.DrawSettings2Panel(spriteBatch, position, num2, color);
      position.X += 8f;
      position.Y += 2f + num1;
      string text = this._GetTextFunction();
      Vector2 stringSize = ChatManager.GetStringSize(FontAssets.ItemStack.Value, text, baseScale);
      position.X = (float) ((double) dimensions.X + (double) dimensions.Width / 2.0 - (double) stringSize.X / 2.0);
      ChatManager.DrawColorCodedStringWithShadow(spriteBatch, FontAssets.ItemStack.Value, text, position, baseColor, 0.0f, Vector2.Zero, baseScale, num2);
    }
  }
}
