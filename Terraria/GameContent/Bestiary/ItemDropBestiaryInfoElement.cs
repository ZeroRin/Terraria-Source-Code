// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.ItemDropBestiaryInfoElement
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class ItemDropBestiaryInfoElement : 
    IItemBestiaryInfoElement,
    IBestiaryInfoElement,
    IProvideSearchFilterString
  {
    protected DropRateInfo _droprateInfo;

    public ItemDropBestiaryInfoElement(DropRateInfo info) => this._droprateInfo = info;

    public virtual UIElement ProvideUIElement(BestiaryUICollectionInfo info)
    {
      bool flag = ItemDropBestiaryInfoElement.ShouldShowItem(ref this._droprateInfo);
      if (info.UnlockState < BestiaryEntryUnlockState.CanShowStats_2)
        flag = false;
      return !flag ? (UIElement) null : (UIElement) new UIBestiaryInfoItemLine(this._droprateInfo, info);
    }

    private static bool ShouldShowItem(ref DropRateInfo dropRateInfo)
    {
      bool flag = true;
      if (dropRateInfo.conditions != null && dropRateInfo.conditions.Count > 0)
      {
        for (int index = 0; index < dropRateInfo.conditions.Count; ++index)
        {
          if (!dropRateInfo.conditions[index].CanShowItemDropInUI())
          {
            flag = false;
            break;
          }
        }
      }
      return flag;
    }

    public string GetSearchString(ref BestiaryUICollectionInfo info)
    {
      bool flag = ItemDropBestiaryInfoElement.ShouldShowItem(ref this._droprateInfo);
      if (info.UnlockState < BestiaryEntryUnlockState.CanShowStats_2)
        flag = false;
      return !flag ? (string) null : ContentSamples.ItemsByType[this._droprateInfo.itemId].Name;
    }
  }
}
