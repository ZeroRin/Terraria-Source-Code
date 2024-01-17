// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Personalities.PersonalityDatabase
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
