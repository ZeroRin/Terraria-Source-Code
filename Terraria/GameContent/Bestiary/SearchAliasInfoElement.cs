// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.SearchAliasInfoElement
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class SearchAliasInfoElement : IBestiaryInfoElement, IProvideSearchFilterString
  {
    private readonly string _alias;

    public SearchAliasInfoElement(string alias) => this._alias = alias;

    public string GetSearchString(ref BestiaryUICollectionInfo info) => info.UnlockState == BestiaryEntryUnlockState.NotKnownAtAll_0 ? (string) null : this._alias;

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => (UIElement) null;
  }
}
