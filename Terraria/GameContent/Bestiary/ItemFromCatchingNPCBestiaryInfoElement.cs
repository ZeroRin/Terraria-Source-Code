// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.ItemFromCatchingNPCBestiaryInfoElement
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
