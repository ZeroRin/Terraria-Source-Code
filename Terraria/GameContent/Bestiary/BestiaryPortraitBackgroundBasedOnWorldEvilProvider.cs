// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.BestiaryPortraitBackgroundBasedOnWorldEvilProviderPreferenceInfoElement
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
