﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Personalities.BiomePreferenceListTrait
// Assembly: Terraria, Version=1.4.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F541F3E5-89DE-4E5D-868F-1B56DAAB46B2
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections;
using System.Collections.Generic;

namespace Terraria.GameContent.Personalities
{
  public class BiomePreferenceListTrait : 
    IShopPersonalityTrait,
    IEnumerable<BiomePreferenceListTrait.BiomePreference>,
    IEnumerable
  {
    private List<BiomePreferenceListTrait.BiomePreference> _preferences;

    public BiomePreferenceListTrait() => this._preferences = new List<BiomePreferenceListTrait.BiomePreference>();

    public void Add(
      BiomePreferenceListTrait.BiomePreference preference)
    {
      this._preferences.Add(preference);
    }

    public void Add(AffectionLevel level, AShoppingBiome biome) => this._preferences.Add(new BiomePreferenceListTrait.BiomePreference(level, biome));

    public void ModifyShopPrice(HelperInfo info, ShopHelper shopHelperInstance)
    {
      BiomePreferenceListTrait.BiomePreference preference1 = (BiomePreferenceListTrait.BiomePreference) null;
      for (int index = 0; index < this._preferences.Count; ++index)
      {
        BiomePreferenceListTrait.BiomePreference preference2 = this._preferences[index];
        if (preference2.Biome.IsInBiome(info.player) && (preference1 == null || preference1.Affection < preference2.Affection))
          preference1 = preference2;
      }
      if (preference1 == null)
        return;
      this.ApplyPreference(preference1, info, shopHelperInstance);
    }

    private void ApplyPreference(
      BiomePreferenceListTrait.BiomePreference preference,
      HelperInfo info,
      ShopHelper shopHelperInstance)
    {
      string nameKey = preference.Biome.NameKey;
      switch (preference.Affection)
      {
        case AffectionLevel.Hate:
          shopHelperInstance.HateBiome(nameKey);
          break;
        case AffectionLevel.Dislike:
          shopHelperInstance.DislikeBiome(nameKey);
          break;
        case AffectionLevel.Like:
          shopHelperInstance.LikeBiome(nameKey);
          break;
        case AffectionLevel.Love:
          shopHelperInstance.LoveBiome(nameKey);
          break;
      }
    }

    public IEnumerator<BiomePreferenceListTrait.BiomePreference> GetEnumerator() => (IEnumerator<BiomePreferenceListTrait.BiomePreference>) this._preferences.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this._preferences.GetEnumerator();

    public class BiomePreference
    {
      public AffectionLevel Affection;
      public AShoppingBiome Biome;

      public BiomePreference(AffectionLevel affection, AShoppingBiome biome)
      {
        this.Affection = affection;
        this.Biome = biome;
      }
    }
  }
}
