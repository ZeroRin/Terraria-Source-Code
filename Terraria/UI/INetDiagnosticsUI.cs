// Decompiled with JetBrains decompiler
// Type: Terraria.UI.INetDiagnosticsUI
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Graphics;

namespace Terraria.UI
{
  public interface INetDiagnosticsUI
  {
    void Reset();

    void Draw(SpriteBatch spriteBatch);

    void CountReadMessage(int messageId, int messageLength);

    void CountSentMessage(int messageId, int messageLength);

    void CountReadModuleMessage(int moduleMessageId, int messageLength);

    void CountSentModuleMessage(int moduleMessageId, int messageLength);
  }
}
