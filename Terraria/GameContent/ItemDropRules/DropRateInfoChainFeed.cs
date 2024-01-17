﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.DropRateInfoChainFeed
// Assembly: Terraria, Version=1.4.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F541F3E5-89DE-4E5D-868F-1B56DAAB46B2
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public struct DropRateInfoChainFeed
  {
    public float parentDroprateChance;
    public List<IItemDropRuleCondition> conditions;

    public void AddCondition(IItemDropRuleCondition condition)
    {
      if (this.conditions == null)
        this.conditions = new List<IItemDropRuleCondition>();
      this.conditions.Add(condition);
    }

    public DropRateInfoChainFeed(float droprate)
    {
      this.parentDroprateChance = droprate;
      this.conditions = (List<IItemDropRuleCondition>) null;
    }

    public DropRateInfoChainFeed With(float multiplier)
    {
      DropRateInfoChainFeed rateInfoChainFeed = new DropRateInfoChainFeed(this.parentDroprateChance * multiplier);
      if (this.conditions != null)
        rateInfoChainFeed.conditions = new List<IItemDropRuleCondition>((IEnumerable<IItemDropRuleCondition>) this.conditions);
      return rateInfoChainFeed;
    }
  }
}
