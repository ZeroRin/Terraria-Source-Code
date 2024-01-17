﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.PlayerStatsSnapshot
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.GameContent.UI
{
  public struct PlayerStatsSnapshot
  {
    public int Life;
    public int LifeMax;
    public int LifeFruitCount;
    public float LifePerSegment;
    public int Mana;
    public int ManaMax;
    public float ManaPerSegment;

    public PlayerStatsSnapshot(Player player)
    {
      this.Life = player.statLife;
      this.Mana = player.statMana;
      this.LifeMax = player.statLifeMax2;
      this.ManaMax = player.statManaMax2;
      float num1 = 20f;
      int num2 = player.statLifeMax / 20;
      int num3 = (player.statLifeMax - 400) / 5;
      if (num3 < 0)
        num3 = 0;
      if (num3 > 0)
      {
        num2 = player.statLifeMax / (20 + num3 / 4);
        num1 = (float) player.statLifeMax / 20f;
      }
      int num4 = player.statLifeMax2 - player.statLifeMax;
      float num5 = num1 + (float) (num4 / num2);
      this.LifeFruitCount = num3;
      this.LifePerSegment = num5;
      this.ManaPerSegment = 20f;
    }
  }
}
