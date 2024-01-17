﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Map.SpawnMapLayer
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.Localization;
using Terraria.UI;

namespace Terraria.Map
{
  public class SpawnMapLayer : IMapLayer
  {
    public void Draw(ref MapOverlayDrawContext context, ref string text)
    {
      Player localPlayer = Main.LocalPlayer;
      Vector2 position1 = new Vector2((float) localPlayer.SpawnX, (float) localPlayer.SpawnY);
      Vector2 position2 = new Vector2((float) Main.spawnTileX, (float) Main.spawnTileY);
      if (context.Draw(TextureAssets.SpawnPoint.Value, position2, Alignment.Bottom).IsMouseOver)
        text = Language.GetTextValue("UI.SpawnPoint");
      if (localPlayer.SpawnX == -1 || !context.Draw(TextureAssets.SpawnBed.Value, position1, Alignment.Bottom).IsMouseOver)
        return;
      text = Language.GetTextValue("UI.SpawnBed");
    }
  }
}
