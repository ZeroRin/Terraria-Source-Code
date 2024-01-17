﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.BigProgressBar.DeerclopsBigProgressBar
// Assembly: Terraria, Version=1.4.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F541F3E5-89DE-4E5D-868F-1B56DAAB46B2
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.GameContent.UI.BigProgressBar
{
  public class DeerclopsBigProgressBar : IBigProgressBar
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
      switch ((int) npc.ai[0])
      {
        case 6:
        case 7:
        case 8:
          Rectangle rectangle = new Rectangle((int) Main.screenPosition.X, (int) Main.screenPosition.Y, Main.screenWidth, Main.screenHeight);
          rectangle.Inflate(5000, 5000);
          if (!npc.Hitbox.Intersects(rectangle))
            return false;
          break;
      }
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