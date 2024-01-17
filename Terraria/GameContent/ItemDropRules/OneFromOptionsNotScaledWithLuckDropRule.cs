// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.OneFromOptionsNotScaledWithLuckDropRule
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public class OneFromOptionsNotScaledWithLuckDropRule : IItemDropRule
  {
    private int[] _dropIds;
    private int _outOfY;
    private int _xoutOfY;

    public List<IItemDropRuleChainAttempt> ChainedRules { get; private set; }

    public OneFromOptionsNotScaledWithLuckDropRule(int outOfY, int xoutOfY, params int[] options)
    {
      this._outOfY = outOfY;
      this._dropIds = options;
      this._xoutOfY = xoutOfY;
      this.ChainedRules = new List<IItemDropRuleChainAttempt>();
    }

    public bool CanDrop(DropAttemptInfo info) => true;

    public ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info)
    {
      if (info.rng.Next(this._outOfY) < this._xoutOfY)
      {
        CommonCode.DropItemFromNPC(info.npc, this._dropIds[info.rng.Next(this._dropIds.Length)], 1);
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
      float personalDropRate = (float) this._xoutOfY / (float) this._outOfY;
      float dropRate = 1f / (float) this._dropIds.Length * (personalDropRate * ratesInfo.parentDroprateChance);
      for (int index = 0; index < this._dropIds.Length; ++index)
        drops.Add(new DropRateInfo(this._dropIds[index], 1, 1, dropRate, ratesInfo.conditions));
      Chains.ReportDroprates(this.ChainedRules, personalDropRate, drops, ratesInfo);
    }
  }
}
