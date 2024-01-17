// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.CommonEnemyUICollectionInfoProvider
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class CommonEnemyUICollectionInfoProvider : IBestiaryUICollectionInfoProvider
  {
    private string _persistentIdentifierToCheck;
    private bool _quickUnlock;

    public CommonEnemyUICollectionInfoProvider(string persistentId, bool quickUnlock)
    {
      this._persistentIdentifierToCheck = persistentId;
      this._quickUnlock = quickUnlock;
    }

    public BestiaryUICollectionInfo GetEntryUICollectionInfo()
    {
      BestiaryEntryUnlockState stateByKillCount = CommonEnemyUICollectionInfoProvider.GetUnlockStateByKillCount(Main.BestiaryTracker.Kills.GetKillCount(this._persistentIdentifierToCheck), this._quickUnlock);
      return new BestiaryUICollectionInfo()
      {
        UnlockState = stateByKillCount
      };
    }

    public static BestiaryEntryUnlockState GetUnlockStateByKillCount(
      int killCount,
      bool quickUnlock)
    {
      return !quickUnlock || killCount <= 0 ? (killCount < 50 ? (killCount < 25 ? (killCount < 10 ? (killCount < 1 ? BestiaryEntryUnlockState.NotKnownAtAll_0 : BestiaryEntryUnlockState.CanShowPortraitOnly_1) : BestiaryEntryUnlockState.CanShowStats_2) : BestiaryEntryUnlockState.CanShowDropsWithoutDropRates_3) : BestiaryEntryUnlockState.CanShowDropsWithDropRates_4) : BestiaryEntryUnlockState.CanShowDropsWithDropRates_4;
    }

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => (UIElement) null;
  }
}
