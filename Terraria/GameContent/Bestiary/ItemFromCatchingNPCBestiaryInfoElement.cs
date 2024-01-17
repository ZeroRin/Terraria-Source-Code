// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.ItemFromCatchingNPCBestiaryInfoElement
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class ItemFromCatchingNPCBestiaryInfoElement : 
    IItemBestiaryInfoElement,
    IBestiaryInfoElement,
    IProvideSearchFilterString
  {
    private int _itemType;

    public ItemFromCatchingNPCBestiaryInfoElement(int itemId) => this._itemType = itemId;

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => info.UnlockState < BestiaryEntryUnlockState.CanShowDropsWithoutDropRates_3 ? (UIElement) null : (UIElement) new UIBestiaryInfoLine<string>("catch item #" + (object) this._itemType ?? "");

    public string GetSearchString(ref BestiaryUICollectionInfo info) => info.UnlockState < BestiaryEntryUnlockState.CanShowDropsWithoutDropRates_3 ? (string) null : ContentSamples.ItemsByType[this._itemType].Name;
  }
}
