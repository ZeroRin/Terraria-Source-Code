﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.BigProgressBar.CommonBossBigProgressBar
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.GameContent.UI.BigProgressBar
{
  public class CommonBossBigProgressBar : IBigProgressBar
  {
    private float _lifePercentToShow;
    private int _headIndex;

    public bool ValidateAndCollectNecessaryInfo(ref BigProgressBarInfo info)
    {
      if (info.npcIndexToAimAt < 0 || info.npcIndexToAimAt > 200)
        return false;
      NPC npc = Main.npc[info.npcIndexToAimAt];
      if (!npc.active)
        return false;
      int headTextureIndex = npc.GetBossHeadTextureIndex();
      if (headTextureIndex == -1)
        return false;
      this._lifePercentToShow = Utils.Clamp<float>((float) npc.life / (float) npc.lifeMax, 0.0f, 1f);
      this._headIndex = headTextureIndex;
      return true;
    }

    public void Draw(ref BigProgressBarInfo info, SpriteBatch spriteBatch)
    {
      Texture2D texture2D = TextureAssets.NpcHeadBoss[this._headIndex].Value;
      Rectangle barIconFrame = texture2D.Frame();
      BigProgressBarHelper.DrawFancyBar(spriteBatch, this._lifePercentToShow, texture2D, barIconFrame);
    }
  }
}
