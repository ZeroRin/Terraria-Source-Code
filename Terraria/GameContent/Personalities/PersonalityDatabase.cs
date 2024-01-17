// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Personalities.PersonalityDatabase
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.Personalities
{
  public class PersonalityDatabase
  {
    private Dictionary<int, PersonalityProfile> _personalityProfiles;

    public PersonalityDatabase() => this._personalityProfiles = new Dictionary<int, PersonalityProfile>();

    private void Register(IShopPersonalityTrait trait, int npcId)
    {
      if (!this._personalityProfiles.ContainsKey(npcId))
        this._personalityProfiles[npcId] = new PersonalityProfile();
      this._personalityProfiles[npcId].ShopModifiers.Add(trait);
    }

    private void Register(IShopPersonalityTrait trait, params int[] npcIds)
    {
      for (int index = 0; index < npcIds.Length; ++index)
        this.Register(trait, npcIds[index]);
    }
  }
}
