// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.NameTagHandler
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.UI.Chat;

namespace Terraria.GameContent.UI.Chat
{
  public class NameTagHandler : ITagHandler
  {
    TextSnippet ITagHandler.Parse(string text, Color baseColor, string options) => new TextSnippet("<" + text.Replace("\\[", "[").Replace("\\]", "]") + ">", baseColor);

    public static string GenerateTag(string name) => "[n:" + name.Replace("[", "\\[").Replace("]", "\\]") + "]";
  }
}
