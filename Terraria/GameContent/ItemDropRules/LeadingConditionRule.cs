// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.LeadingConditionRule
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public class LeadingConditionRule : IItemDropRule
  {
    private IItemDropRuleCondition _condition;

    public List<IItemDropRuleChainAttempt> ChainedRules { get; private set; }

    public LeadingConditionRule(IItemDropRuleCondition condition)
    {
      this._condition = condition;
      this.ChainedRules = new List<IItemDropRuleChainAttempt>();
    }

    public bool CanDrop(DropAttemptInfo info) => this._condition.CanDrop(info);

    public void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo)
    {
      ratesInfo.AddCondition(this._condition);
      Chains.ReportDroprates(this.ChainedRules, 1f, drops, ratesInfo);
    }

    public ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info) => new ItemDropAttemptResult()
    {
      State = ItemDropAttemptResultState.Success
    };
  }
}
