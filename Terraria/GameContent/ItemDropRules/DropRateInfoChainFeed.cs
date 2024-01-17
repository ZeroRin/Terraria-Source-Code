// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.DropRateInfoChainFeed
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
