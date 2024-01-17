// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes.FastConditionSetter
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
