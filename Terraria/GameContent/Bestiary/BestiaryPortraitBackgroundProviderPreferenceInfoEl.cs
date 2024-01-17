// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.BestiaryPortraitBackgroundProviderPreferenceInfoElement
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class BestiaryPortraitBackgroundProviderPreferenceInfoElement : 
    IPreferenceProviderElement,
    IBestiaryInfoElement
  {
    private IBestiaryBackgroundImagePathAndColorProvider _preferredProvider;

    public BestiaryPortraitBackgroundProviderPreferenceInfoElement(
      IBestiaryBackgroundImagePathAndColorProvider preferredProvider)
    {
      this._preferredProvider = preferredProvider;
    }

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => (UIElement) null;

    public bool Matches(
      IBestiaryBackgroundImagePathAndColorProvider provider)
    {
      return provider == this._preferredProvider;
    }

    public IBestiaryBackgroundImagePathAndColorProvider GetPreferredProvider() => this._preferredProvider;
  }
}
