﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.PlainTagHandler
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
  public class PlainTagHandler : ITagHandler
  {
    TextSnippet ITagHandler.Parse(string text, Color baseColor, string options) => (TextSnippet) new PlainTagHandler.PlainSnippet(text);

    public class PlainSnippet : TextSnippet
    {
      public PlainSnippet(string text = "")
        : base(text)
      {
      }

      public PlainSnippet(string text, Color color, float scale = 1f)
        : base(text, color, scale)
      {
      }

      public override Color GetVisibleColor() => this.Color;
    }
  }
}