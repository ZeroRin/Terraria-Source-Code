// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.CritterUICollectionInfoProvider
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class CritterUICollectionInfoProvider : IBestiaryUICollectionInfoProvider
  {
    private string _persistentIdentifierToCheck;

    public CritterUICollectionInfoProvider(string persistentId) => this._persistentIdentifierToCheck = persistentId;

    public BestiaryUICollectionInfo GetEntryUICollectionInfo() => new BestiaryUICollectionInfo()
    {
      UnlockState = Main.BestiaryTracker.Sights.GetWasNearbyBefore(this._persistentIdentifierToCheck) ? BestiaryEntryUnlockState.CanShowDropsWithDropRates_4 : BestiaryEntryUnlockState.NotKnownAtAll_0
    };

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => (UIElement) null;
  }
}
