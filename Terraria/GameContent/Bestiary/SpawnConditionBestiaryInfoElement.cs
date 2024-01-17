// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.SpawnConditionBestiaryInfoElement
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace Terraria.GameContent.Bestiary
{
  public class SpawnConditionBestiaryInfoElement : 
    FilterProviderInfoElement,
    IBestiaryBackgroundImagePathAndColorProvider
  {
    private string _backgroundImagePath;
    private Color? _backgroundColor;

    public SpawnConditionBestiaryInfoElement(
      string nameLanguageKey,
      int filterIconFrame,
      string backgroundImagePath = null,
      Color? backgroundColor = null)
      : base(nameLanguageKey, filterIconFrame)
    {
      this._backgroundImagePath = backgroundImagePath;
      this._backgroundColor = backgroundColor;
    }

    public Asset<Texture2D> GetBackgroundImage() => this._backgroundImagePath == null ? (Asset<Texture2D>) null : Main.Assets.Request<Texture2D>(this._backgroundImagePath, (AssetRequestMode) 1);

    public Color? GetBackgroundColor() => this._backgroundColor;
  }
}
