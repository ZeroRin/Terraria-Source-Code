// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.IItemDropRuleChainAttempt
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public interface IItemDropRuleChainAttempt
  {
    IItemDropRule RuleToChain { get; }

    bool CanChainIntoRule(ItemDropAttemptResult parentResult);

    void ReportDroprates(
      float personalDropRate,
      List<DropRateInfo> drops,
      DropRateInfoChainFeed ratesInfo);
  }
}
