// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.LootSimulation.LootSimulatorConditionSetterTypes.StackedConditionSetter
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
