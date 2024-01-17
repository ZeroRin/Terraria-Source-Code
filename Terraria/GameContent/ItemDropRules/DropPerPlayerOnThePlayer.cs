// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.DropPerPlayerOnThePlayer
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.GameContent.ItemDropRules
{
  public class DropPerPlayerOnThePlayer : CommonDrop
  {
    public IItemDropRuleCondition condition;

    public DropPerPlayerOnThePlayer(
      int itemId,
      int chanceDenominator,
      int amountDroppedMinimum,
      int amountDroppedMaximum,
      IItemDropRuleCondition optionalCondition)
      : base(itemId, chanceDenominator, amountDroppedMinimum, amountDroppedMaximum)
    {
      this.condition = optionalCondition;
    }

    public override bool CanDrop(DropAttemptInfo info) => this.condition == null || this.condition.CanDrop(info);

    public override ItemDropAttemptResult TryDroppingItem(DropAttemptInfo info)
    {
      CommonCode.DropItemForEachInteractingPlayerOnThePlayer(info.npc, this.itemId, info.rng, this.chanceNumerator, this.chanceDenominator, info.rng.Next(this.amountDroppedMinimum, this.amountDroppedMaximum + 1));
      return new ItemDropAttemptResult()
      {
        State = ItemDropAttemptResultState.Success
      };
    }
  }
}
