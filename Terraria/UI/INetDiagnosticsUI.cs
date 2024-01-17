// Decompiled with JetBrains decompiler
// Type: Terraria.UI.INetDiagnosticsUI
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
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
