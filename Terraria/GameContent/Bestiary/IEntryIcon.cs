﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.IEntryIcon
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.GameContent.Bestiary
{
  public interface IEntryIcon
  {
    void Update(
      BestiaryUICollectionInfo providedInfo,
      Rectangle hitbox,
      EntryIconDrawSettings settings);

    void Draw(
      BestiaryUICollectionInfo providedInfo,
      SpriteBatch spriteBatch,
      EntryIconDrawSettings settings);

    bool GetUnlockState(BestiaryUICollectionInfo providedInfo);

    string GetHoverText(BestiaryUICollectionInfo providedInfo);

    IEntryIcon CreateClone();
  }
}
