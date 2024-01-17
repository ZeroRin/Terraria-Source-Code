// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.CommonDrop
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public class CommonDrop : IItemDropRule
  {
    public int itemId;
    public int chanceDenominator;
    public int amountDroppedMinimum;
    public int amountDroppedMaximum;
    public int chanceNumerator;

    public List<IItemDropRuleChainAttempt> ChainedRules { get; private set; }

    public CommonDrop(
      int itemId,
      int chanceDenominator,
      int amountDroppedMinimum = 1,
      int amountDroppedMaximum = 1,
      int chanceNumerator = 1)
    {
      this.itemId = itemId;
      this.chanceDenominator = chanceDenominator;
      this.amountDroppedMinimum = amountDroppedMinimum;
      this.amountDroppedMaximum = amountDroppedMaximum;
      this.chanceNumerator = chanceNumerator;
      this.ChainedRules = new List<IItemDropRuleChainAttempt>();
    }

    public virtual bool CanDrop(DropAttemptInfo info) => true;

    public virtual ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info)
    {
      if (info.player.RollLuck(this.chanceDenominator) < this.chanceNumerator)
      {
        CommonCode.DropItemFromNPC(info.npc, this.itemId, info.rng.Next(this.amountDroppedMinimum, this.amountDroppedMaximum + 1));
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

    public virtual void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo)
    {
      float personalDropRate = (float) this.chanceNumerator / (float) this.chanceDenominator;
      float dropRate = personalDropRate * ratesInfo.parentDroprateChance;
      drops.Add(new DropRateInfo(this.itemId, this.amountDroppedMinimum, this.amountDroppedMaximum, dropRate, ratesInfo.conditions));
      Chains.ReportDroprates(this.ChainedRules, personalDropRate, drops, ratesInfo);
    }
  }
}
