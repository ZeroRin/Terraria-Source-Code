﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.AchievementTagHandler
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.Achievements;
using Terraria.UI;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
  public class AchievementTagHandler : ITagHandler
  {
    TextSnippet ITagHandler.Parse(string text, Color baseColor, string options)
    {
      Achievement achievement = Main.Achievements.GetAchievement(text);
      return achievement == null ? new TextSnippet(text) : (TextSnippet) new AchievementTagHandler.AchievementSnippet(achievement);
    }

    public static string GenerateTag(Achievement achievement) => "[a:" + achievement.Name + "]";

    private class AchievementSnippet : TextSnippet
    {
      private Achievement _achievement;

      public AchievementSnippet(Achievement achievement)
        : base(achievement.FriendlyName.Value, Color.LightBlue)
      {
        this.CheckForHover = true;
        this._achievement = achievement;
      }

      public override void OnClick()
      {
        IngameOptions.Close();
        IngameFancyUI.OpenAchievementsAndGoto(this._achievement);
      }
    }
  }
}
