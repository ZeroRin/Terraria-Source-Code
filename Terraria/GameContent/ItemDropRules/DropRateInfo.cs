﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.DropRateInfo
// Assembly: Terraria, Version=1.4.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F541F3E5-89DE-4E5D-868F-1B56DAAB46B2
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public struct DropRateInfo
  {
    public int itemId;
    public int stackMin;
    public int stackMax;
    public float dropRate;
    public List<IItemDropRuleCondition> conditions;

    public DropRateInfo(
      int itemId,
      int stackMin,
      int stackMax,
      float dropRate,
      List<IItemDropRuleCondition> conditions = null)
    {
      this.itemId = itemId;
      this.stackMin = stackMin;
      this.stackMax = stackMax;
      this.dropRate = dropRate;
      this.conditions = (List<IItemDropRuleCondition>) null;
      if (conditions == null || conditions.Count <= 0)
        return;
      this.conditions = new List<IItemDropRuleCondition>((IEnumerable<IItemDropRuleCondition>) conditions);
    }

    public void AddCondition(IItemDropRuleCondition condition)
    {
      if (this.conditions == null)
        this.conditions = new List<IItemDropRuleCondition>();
      this.conditions.Add(condition);
    }
  }
}
