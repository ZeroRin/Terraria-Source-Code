﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.BigProgressBar.CommonBossBigProgressBar
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.GameContent.UI.BigProgressBar
{
  public class CommonBossBigProgressBar : IBigProgressBar
  {
    private BigProgressBarCache _cache;
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
      this._cache.SetLife((float) npc.life, (float) npc.lifeMax);
      this._headIndex = headTextureIndex;
      return true;
    }

    public void Draw(ref BigProgressBarInfo info, SpriteBatch spriteBatch)
    {
      Texture2D texture2D = TextureAssets.NpcHeadBoss[this._headIndex].Value;
      Rectangle barIconFrame = texture2D.Frame();
      BigProgressBarHelper.DrawFancyBar(spriteBatch, this._cache.LifeCurrent, this._cache.LifeMax, texture2D, barIconFrame);
    }
  }
}
