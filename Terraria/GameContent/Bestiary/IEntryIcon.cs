// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.IEntryIcon
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
