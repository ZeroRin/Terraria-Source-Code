// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.SpawnConditionBestiaryInfoElement
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
