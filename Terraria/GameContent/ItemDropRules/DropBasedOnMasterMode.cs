﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.DropBasedOnMasterMode
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public class DropBasedOnMasterMode : IItemDropRule, INestedItemDropRule
  {
    private IItemDropRule _ruleForDefault;
    private IItemDropRule _ruleForMasterMode;

    public List<IItemDropRuleChainAttempt> ChainedRules { get; private set; }

    public DropBasedOnMasterMode(IItemDropRule ruleForDefault, IItemDropRule ruleForMasterMode)
    {
      this._ruleForDefault = ruleForDefault;
      this._ruleForMasterMode = ruleForMasterMode;
      this.ChainedRules = new List<IItemDropRuleChainAttempt>();
    }

    public bool CanDrop(DropAttemptInfo info) => info.IsMasterMode ? this._ruleForMasterMode.CanDrop(info) : this._ruleForDefault.CanDrop(info);

    public ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info) => new ItemDropAttemptResult()
    {
      State = ItemDropAttemptResultState.DidNotRunCode
    };

    public ItemDropAttemptResult TryDroppingItem(
      DropAttemptInfo info,
      ItemDropRuleResolveAction resolveAction)
    {
      return info.IsMasterMode ? resolveAction(this._ruleForMasterMode, info) : resolveAction(this._ruleForDefault, info);
    }

    public void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo)
    {
      DropRateInfoChainFeed ratesInfo1 = ratesInfo.With(1f);
      ratesInfo1.AddCondition((IItemDropRuleCondition) new Conditions.IsMasterMode());
      this._ruleForMasterMode.ReportDroprates(drops, ratesInfo1);
      DropRateInfoChainFeed ratesInfo2 = ratesInfo.With(1f);
      ratesInfo2.AddCondition((IItemDropRuleCondition) new Conditions.NotMasterMode());
      this._ruleForDefault.ReportDroprates(drops, ratesInfo2);
      Chains.ReportDroprates(this.ChainedRules, 1f, drops, ratesInfo);
    }
  }
}
