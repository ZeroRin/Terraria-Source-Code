﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.BigProgressBar.StardustPillarBigProgressBar
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.GameContent.UI.BigProgressBar
{
  public class StardustPillarBigProgressBar : LunarPillarBigProgessBar
  {
    internal override float GetCurrentShieldValue() => (float) NPC.ShieldStrengthTowerStardust;

    internal override float GetMaxShieldValue() => (float) NPC.ShieldStrengthTowerMax;

    internal override bool IsPlayerInCombatArea() => Main.LocalPlayer.ZoneTowerStardust;
  }
}
