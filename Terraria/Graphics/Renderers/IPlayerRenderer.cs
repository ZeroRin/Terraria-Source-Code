// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Renderers.IPlayerRenderer
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Terraria.Graphics.Renderers
{
  public interface IPlayerRenderer
  {
    void DrawPlayers(Camera camera, IEnumerable<Player> players);

    void DrawPlayerHead(
      Camera camera,
      Player drawPlayer,
      Vector2 position,
      float alpha = 1f,
      float scale = 1f,
      Color borderColor = default (Color));

    void DrawPlayer(
      Camera camera,
      Player drawPlayer,
      Vector2 position,
      float rotation,
      Vector2 rotationOrigin,
      float shadow = 0.0f,
      float scale = 1f);
  }
}
