// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.OneFromRulesRule
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public class OneFromRulesRule : IItemDropRule, INestedItemDropRule
  {
    private IItemDropRule[] _options;
    private int _outOfY;

    public List<IItemDropRuleChainAttempt> ChainedRules { get; private set; }

    public OneFromRulesRule(int outOfY, params IItemDropRule[] options)
    {
      this._outOfY = outOfY;
      this._options = options;
      this.ChainedRules = new List<IItemDropRuleChainAttempt>();
    }

    public bool CanDrop(DropAttemptInfo info) => true;

    public ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info) => new ItemDropAttemptResult()
    {
      State = ItemDropAttemptResultState.DidNotRunCode
    };

    public ItemDropAttemptResult TryDroppingItem(
      DropAttemptInfo info,
      ItemDropRuleResolveAction resolveAction)
    {
      if (info.rng.Next(this._outOfY) == 0)
      {
        int index = info.rng.Next(this._options.Length);
        ItemDropAttemptResult dropAttemptResult = resolveAction(this._options[index], info);
        return new ItemDropAttemptResult()
        {
          State = ItemDropAttemptResultState.Success
        };
      }
      return new ItemDropAttemptResult()
      {
        State = ItemDropAttemptResultState.FailedRandomRoll
      };
    }

    public void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo)
    {
      float personalDropRate = 1f / (float) this._outOfY;
      float multiplier = 1f / (float) this._options.Length * (personalDropRate * ratesInfo.parentDroprateChance);
      for (int index = 0; index < this._options.Length; ++index)
        this._options[index].ReportDroprates(drops, ratesInfo.With(multiplier));
      Chains.ReportDroprates(this.ChainedRules, personalDropRate, drops, ratesInfo);
    }
  }
}
