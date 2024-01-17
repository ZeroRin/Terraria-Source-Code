// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.IItemDropRule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public interface IItemDropRule
  {
    List<IItemDropRuleChainAttempt> ChainedRules { get; }

    bool CanDrop(DropAttemptInfo info);

    void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo);

    ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info);
  }
}
