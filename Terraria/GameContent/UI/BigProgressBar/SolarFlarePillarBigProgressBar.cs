// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.BigProgressBar.SolarFlarePillarBigProgressBar
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.GameContent.UI.BigProgressBar
{
  public class SolarFlarePillarBigProgressBar : LunarPillarBigProgessBar
  {
    internal override float GetCurrentShieldValue() => (float) NPC.ShieldStrengthTowerSolar;

    internal override float GetMaxShieldValue() => (float) NPC.ShieldStrengthTowerMax;

    internal override bool IsPlayerInCombatArea() => Main.LocalPlayer.ZoneTowerSolar;
  }
}
