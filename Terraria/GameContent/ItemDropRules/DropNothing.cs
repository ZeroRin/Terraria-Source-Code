// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.DropNothing
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public class DropNothing : IItemDropRule
  {
    public List<IItemDropRuleChainAttempt> ChainedRules { get; private set; }

    public DropNothing() => this.ChainedRules = new List<IItemDropRuleChainAttempt>();

    public bool CanDrop(DropAttemptInfo info) => false;

    public ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info) => new ItemDropAttemptResult()
    {
      State = ItemDropAttemptResultState.DoesntFillConditions
    };

    public void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo) => Chains.ReportDroprates(this.ChainedRules, 1f, drops, ratesInfo);
  }
}
