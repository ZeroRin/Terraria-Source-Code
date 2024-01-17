// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ObjectInteractions.PotionOfReturnGateInteractionChecker
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.ObjectInteractions
{
  public class PotionOfReturnGateInteractionChecker : AHoverInteractionChecker
  {
    internal override bool? AttemptOverridingHoverStatus(Player player, Rectangle rectangle) => Main.SmartInteractPotionOfReturn ? new bool?(true) : new bool?();

    internal override void DoHoverEffect(Player player, Rectangle hitbox)
    {
      player.noThrow = 2;
      player.cursorItemIconEnabled = true;
      player.cursorItemIconID = 4870;
    }

    internal override bool ShouldBlockInteraction(Player player, Rectangle hitbox) => Player.BlockInteractionWithProjectiles != 0;

    internal override void PerformInteraction(Player player, Rectangle hitbox) => player.DoPotionOfReturnReturnToOriginalUsePosition();
  }
}
