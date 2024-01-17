// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Chat.IChatMonitor
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.UI.Chat
{
  public interface IChatMonitor
  {
    void NewText(string newText, byte R = 255, byte G = 255, byte B = 255);

    void NewTextMultiline(string text, bool force = false, Color c = default (Color), int WidthLimit = -1);

    void DrawChat(bool drawingPlayerChat);

    void Clear();

    void Update();

    void Offset(int linesOffset);

    void ResetOffset();

    void OnResolutionChange();
  }
}
