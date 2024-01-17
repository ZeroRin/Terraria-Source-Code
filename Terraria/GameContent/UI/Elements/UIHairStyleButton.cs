﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIHairStyleButton
// Assembly: Terraria, Version=1.4.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F541F3E5-89DE-4E5D-868F-1B56DAAB46B2
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Audio;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIHairStyleButton : UIImageButton
  {
    private readonly Player _player;
    public readonly int HairStyleId;
    private readonly Asset<Texture2D> _selectedBorderTexture;
    private readonly Asset<Texture2D> _hoveredBorderTexture;
    private bool _hovered;
    private bool _soundedHover;

    public UIHairStyleButton(Player player, int hairStyleId)
      : base(Main.Assets.Request<Texture2D>("Images/UI/CharCreation/CategoryPanel", (AssetRequestMode) 1))
    {
      this._player = player;
      this.HairStyleId = hairStyleId;
      this.Width = StyleDimension.FromPixels(44f);
      this.Height = StyleDimension.FromPixels(44f);
      this._selectedBorderTexture = Main.Assets.Request<Texture2D>("Images/UI/CharCreation/CategoryPanelHighlight", (AssetRequestMode) 1);
      this._hoveredBorderTexture = Main.Assets.Request<Texture2D>("Images/UI/CharCreation/CategoryPanelBorder", (AssetRequestMode) 1);
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      if (this._hovered)
      {
        if (!this._soundedHover)
          SoundEngine.PlaySound(12);
        this._soundedHover = true;
      }
      else
        this._soundedHover = false;
      Vector2 vector2 = new Vector2(-5f, -5f);
      base.DrawSelf(spriteBatch);
      if (this._player.hair == this.HairStyleId)
        spriteBatch.Draw(this._selectedBorderTexture.Value, this.GetDimensions().Center() - this._selectedBorderTexture.Size() / 2f, Color.White);
      if (this._hovered)
        spriteBatch.Draw(this._hoveredBorderTexture.Value, this.GetDimensions().Center() - this._hoveredBorderTexture.Size() / 2f, Color.White);
      int hair = this._player.hair;
      this._player.hair = this.HairStyleId;
      Main.PlayerRenderer.DrawPlayerHead(Main.Camera, this._player, this.GetDimensions().Center() + vector2);
      this._player.hair = hair;
    }

    public override void MouseDown(UIMouseEvent evt)
    {
      this._player.hair = this.HairStyleId;
      SoundEngine.PlaySound(12);
      base.MouseDown(evt);
    }

    public override void MouseOver(UIMouseEvent evt)
    {
      base.MouseOver(evt);
      this._hovered = true;
    }

    public override void MouseOut(UIMouseEvent evt)
    {
      base.MouseOut(evt);
      this._hovered = false;
    }
  }
}
