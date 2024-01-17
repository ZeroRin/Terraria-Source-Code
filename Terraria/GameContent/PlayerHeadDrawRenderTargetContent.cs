﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.PlayerHeadDrawRenderTargetContent
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace Terraria.GameContent
{
  public class PlayerHeadDrawRenderTargetContent : AnOutlinedDrawRenderTargetContent
  {
    private Player _player;
    private readonly List<DrawData> _drawData = new List<DrawData>();
    private readonly List<int> _dust = new List<int>();
    private readonly List<int> _gore = new List<int>();

    public void UsePlayer(Player player) => this._player = player;

    internal override void DrawTheContent(SpriteBatch spriteBatch)
    {
      if (this._player == null || this._player.ShouldNotDraw)
        return;
      this._drawData.Clear();
      this._dust.Clear();
      this._gore.Clear();
      PlayerDrawHeadSet drawinfo = new PlayerDrawHeadSet();
      drawinfo.BoringSetup(this._player, this._drawData, this._dust, this._gore, (float) (this.width / 2), (float) (this.height / 2), 1f, 1f);
      PlayerDrawHeadLayers.DrawPlayer_00_BackHelmet(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_01_FaceSkin(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_02_DrawArmorWithFullHair(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_03_HelmetHair(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_04_HatsWithFullHair(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_05_TallHats(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_06_NormalHats(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_07_JustHair(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_08_FaceAcc(ref drawinfo);
      PlayerDrawHeadLayers.DrawPlayer_RenderAllLayers(ref drawinfo);
    }
  }
}
