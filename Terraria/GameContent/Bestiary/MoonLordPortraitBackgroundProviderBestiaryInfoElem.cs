// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.MoonLordPortraitBackgroundProviderBestiaryInfoElement
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class MoonLordPortraitBackgroundProviderBestiaryInfoElement : 
    IBestiaryInfoElement,
    IBestiaryBackgroundImagePathAndColorProvider
  {
    public Asset<Texture2D> GetBackgroundImage() => Main.Assets.Request<Texture2D>("Images/MapBG1", (AssetRequestMode) 1);

    public Color? GetBackgroundColor() => new Color?(Color.Black);

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => (UIElement) null;
  }
}
