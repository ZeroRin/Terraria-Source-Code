// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.HighestOfMultipleUICollectionInfoProvider
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
