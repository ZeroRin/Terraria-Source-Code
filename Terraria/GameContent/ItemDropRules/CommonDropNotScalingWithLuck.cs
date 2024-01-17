// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.CommonDropNotScalingWithLuck
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.GameContent.ItemDropRules
{
  public class CommonDropNotScalingWithLuck : CommonDrop
  {
    public CommonDropNotScalingWithLuck(
      int itemId,
      int dropsOutOfY,
      int amountDroppedMinimum,
      int amountDroppedMaximum)
      : base(itemId, dropsOutOfY, amountDroppedMinimum, amountDroppedMaximum)
    {
    }

    public override ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info)
    {
      if (info.rng.Next(this._dropsOutOfY) < this._dropsXoutOfY)
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
  }
}
