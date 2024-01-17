// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.DropPerPlayerOnThePlayer
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.GameContent.ItemDropRules
{
  public class DropPerPlayerOnThePlayer : CommonDrop
  {
    private IItemDropRuleCondition _condition;

    public DropPerPlayerOnThePlayer(
      int itemId,
      int dropsOutOfY,
      int amountDroppedMinimum,
      int amountDroppedMaximum,
      IItemDropRuleCondition optionalCondition)
      : base(itemId, dropsOutOfY, amountDroppedMinimum, amountDroppedMaximum)
    {
      this._condition = optionalCondition;
    }

    public override bool CanDrop(DropAttemptInfo info) => this._condition == null || this._condition.CanDrop(info);

    public override ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info)
    {
      CommonCode.DropItemForEachInteractingPlayerOnThePlayer(info.npc, this._itemId, info.rng, this._dropsXoutOfY, this._dropsOutOfY, info.rng.Next(this._amtDroppedMinimum, this._amtDroppedMaximum + 1));
      return new ItemDropAttemptResult()
      {
        State = ItemDropAttemptResultState.Success
      };
    }
  }
}
