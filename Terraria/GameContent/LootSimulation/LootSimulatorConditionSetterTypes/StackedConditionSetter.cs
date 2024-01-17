// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes.StackedConditionSetter
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes
{
  public class StackedConditionSetter : ISimulationConditionSetter
  {
    private ISimulationConditionSetter[] _setters;

    public StackedConditionSetter(params ISimulationConditionSetter[] setters) => this._setters = setters;

    public void Setup(SimulatorInfo info)
    {
      for (int index = 0; index < this._setters.Length; ++index)
        this._setters[index].Setup(info);
    }

    public void TearDown(SimulatorInfo info)
    {
      for (int index = 0; index < this._setters.Length; ++index)
        this._setters[index].TearDown(info);
    }

    public int GetTimesToRunMultiplier(SimulatorInfo info) => 1;
  }
}
