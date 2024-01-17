// Decompiled with JetBrains decompiler
// Type: Terraria.UI.IInGameNotification
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.UI
{
  public interface IInGameNotification
  {
    object CreationObject { get; }

    bool ShouldBeRemoved { get; }

    void Update();

    void DrawInGame(SpriteBatch spriteBatch, Vector2 bottomAnchorPosition);

    void PushAnchor(ref Vector2 positionAnchorBottom);

    void DrawInNotificationsArea(
      SpriteBatch spriteBatch,
      Rectangle area,
      ref int gamepadPointLocalIndexTouse);
  }
}
