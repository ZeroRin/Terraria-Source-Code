// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.BossBestiaryInfoElement
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.Localization;
using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class BossBestiaryInfoElement : IBestiaryInfoElement, IProvideSearchFilterString
  {
    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => (UIElement) null;

    public string GetSearchString(ref BestiaryUICollectionInfo info) => info.UnlockState < BestiaryEntryUnlockState.CanShowPortraitOnly_1 ? (string) null : Language.GetText("BestiaryInfo.IsBoss").Value;
  }
}
