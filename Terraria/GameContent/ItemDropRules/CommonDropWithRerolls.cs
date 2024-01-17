﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.CommonDropWithRerolls
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.ItemDropRules
{
  public class CommonDropWithRerolls : CommonDrop
  {
    private int _timesToRoll;

    public CommonDropWithRerolls(
      int itemId,
      int dropsOutOfY,
      int amountDroppedMinimum,
      int amountDroppedMaximum,
      int rerolls)
      : base(itemId, dropsOutOfY, amountDroppedMinimum, amountDroppedMaximum)
    {
      this._timesToRoll = rerolls + 1;
    }

    public override ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info)
    {
      bool flag = false;
      for (int index = 0; index < this._timesToRoll; ++index)
        flag = flag || info.player.RollLuck(this._dropsOutOfY) < this._dropsXoutOfY;
      if (flag)
      {
        CommonCode.DropItemFromNPC(info.npc, this._itemId, info.rng.Next(this._amtDroppedMinimum, this._amtDroppedMaximum + 1));
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

    public override void ReportDroprates(List<DropRateInfo> drops, DropRateInfoChainFeed ratesInfo)
    {
      float num1 = 1f - (float) this._dropsXoutOfY / (float) this._dropsOutOfY;
      float num2 = 1f;
      for (int index = 0; index < this._timesToRoll; ++index)
        num2 *= num1;
      float personalDropRate = 1f - num2;
      float dropRate = personalDropRate * ratesInfo.parentDroprateChance;
      drops.Add(new DropRateInfo(this._itemId, this._amtDroppedMinimum, this._amtDroppedMaximum, dropRate, ratesInfo.conditions));
      Chains.ReportDroprates(this.ChainedRules, personalDropRate, drops, ratesInfo);
    }
  }
}
