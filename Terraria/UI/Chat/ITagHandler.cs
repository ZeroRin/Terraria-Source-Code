﻿// Decompiled with JetBrains decompiler
// Type: Terraria.UI.Chat.ITagHandler
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.UI.Chat
{
  public interface ITagHandler
  {
    TextSnippet Parse(string text, Color baseColor = default (Color), string options = null);
  }
}
