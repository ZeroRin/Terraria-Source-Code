﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.CritterUICollectionInfoProvider
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
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
