// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.HighestOfMultipleUICollectionInfoProvider
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class HighestOfMultipleUICollectionInfoProvider : IBestiaryUICollectionInfoProvider
  {
    private IBestiaryUICollectionInfoProvider[] _providers;
    private int _mainProviderIndex;

    public HighestOfMultipleUICollectionInfoProvider(
      params IBestiaryUICollectionInfoProvider[] providers)
    {
      this._providers = providers;
      this._mainProviderIndex = 0;
    }

    public BestiaryUICollectionInfo GetEntryUICollectionInfo()
    {
      BestiaryUICollectionInfo uiCollectionInfo1 = this._providers[this._mainProviderIndex].GetEntryUICollectionInfo();
      BestiaryEntryUnlockState unlockState = uiCollectionInfo1.UnlockState;
      for (int index = 0; index < this._providers.Length; ++index)
      {
        BestiaryUICollectionInfo uiCollectionInfo2 = this._providers[index].GetEntryUICollectionInfo();
        if (unlockState < uiCollectionInfo2.UnlockState)
          unlockState = uiCollectionInfo2.UnlockState;
      }
      uiCollectionInfo1.UnlockState = unlockState;
      return uiCollectionInfo1;
    }

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => (UIElement) null;
  }
}
