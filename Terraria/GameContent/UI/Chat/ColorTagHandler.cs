﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.ColorTagHandler
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Globalization;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
  public class ColorTagHandler : ITagHandler
  {
    TextSnippet ITagHandler.Parse(string text, Color baseColor, string options)
    {
      TextSnippet textSnippet = new TextSnippet(text);
      int result;
      if (!int.TryParse(options, NumberStyles.AllowHexSpecifier, (IFormatProvider) CultureInfo.InvariantCulture, out result))
        return textSnippet;
      textSnippet.Color = new Color(result >> 16 & (int) byte.MaxValue, result >> 8 & (int) byte.MaxValue, result & (int) byte.MaxValue);
      return textSnippet;
    }
  }
}