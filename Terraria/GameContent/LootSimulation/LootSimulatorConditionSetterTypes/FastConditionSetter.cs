// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes.FastConditionSetter
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;

namespace Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes
{
  public class FastConditionSetter : ISimulationConditionSetter
  {
    private Action<SimulatorInfo> _setup;
    private Action<SimulatorInfo> _tearDown;

    public FastConditionSetter(Action<SimulatorInfo> setup, Action<SimulatorInfo> tearDown)
    {
      this._setup = setup;
      this._tearDown = tearDown;
    }

    public void Setup(SimulatorInfo info)
    {
      if (this._setup == null)
        return;
      this._setup(info);
    }

    public void TearDown(SimulatorInfo info)
    {
      if (this._tearDown == null)
        return;
      this._tearDown(info);
    }

    public int GetTimesToRunMultiplier(SimulatorInfo info) => 1;
  }
}
