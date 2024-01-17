// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.DropRateInfo
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
