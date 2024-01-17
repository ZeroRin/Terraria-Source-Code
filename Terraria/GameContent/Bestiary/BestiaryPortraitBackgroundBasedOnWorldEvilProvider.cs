// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.BestiaryPortraitBackgroundBasedOnWorldEvilProviderPreferenceInfoElement
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class BestiaryPortraitBackgroundBasedOnWorldEvilProviderPreferenceInfoElement : 
    IPreferenceProviderElement,
    IBestiaryInfoElement
  {
    private IBestiaryBackgroundImagePathAndColorProvider _preferredProviderCorrupt;
    private IBestiaryBackgroundImagePathAndColorProvider _preferredProviderCrimson;

    public BestiaryPortraitBackgroundBasedOnWorldEvilProviderPreferenceInfoElement(
      IBestiaryBackgroundImagePathAndColorProvider preferredProviderCorrupt,
      IBestiaryBackgroundImagePathAndColorProvider preferredProviderCrimson)
    {
      this._preferredProviderCorrupt = preferredProviderCorrupt;
      this._preferredProviderCrimson = preferredProviderCrimson;
    }

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => (UIElement) null;

    public bool Matches(
      IBestiaryBackgroundImagePathAndColorProvider provider)
    {
      return Main.ActiveWorldFileData == null || !WorldGen.crimson ? provider == this._preferredProviderCorrupt : provider == this._preferredProviderCrimson;
    }

    public IBestiaryBackgroundImagePathAndColorProvider GetPreferredProvider() => Main.ActiveWorldFileData == null || !WorldGen.crimson ? this._preferredProviderCorrupt : this._preferredProviderCrimson;
  }
}
