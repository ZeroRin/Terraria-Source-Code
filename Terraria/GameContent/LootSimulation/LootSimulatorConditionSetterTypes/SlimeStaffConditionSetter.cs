﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes.SlimeStaffConditionSetter
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes
{
  public class SlimeStaffConditionSetter : ISimulationConditionSetter
  {
    private int _timesToRun;

    public SlimeStaffConditionSetter(int timesToRunMultiplier) => this._timesToRun = timesToRunMultiplier;

    public int GetTimesToRunMultiplier(SimulatorInfo info)
    {
      switch (info.npcVictim.netID)
      {
        case -33:
        case -32:
        case -10:
        case -9:
        case -8:
        case -7:
        case -6:
        case -5:
        case -4:
        case -3:
        case 1:
        case 16:
        case 138:
        case 141:
        case 147:
        case 184:
        case 187:
        case 204:
        case 302:
        case 333:
        case 334:
        case 335:
        case 336:
        case 433:
        case 535:
        case 537:
          return this._timesToRun;
        default:
          return 0;
      }
    }

    public void Setup(SimulatorInfo info)
    {
    }

    public void TearDown(SimulatorInfo info)
    {
    }
  }
}
