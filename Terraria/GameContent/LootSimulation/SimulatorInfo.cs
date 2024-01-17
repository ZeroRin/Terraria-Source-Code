// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.LootSimulation.SimulatorInfo
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.LootSimulation
{
  public class SimulatorInfo
  {
    public Player player;
    private double _originalDayTimeCounter;
    private bool _originalDayTimeFlag;
    private Vector2 _originalPlayerPosition;
    public bool runningExpertMode;
    public LootSimulationItemCounter itemCounter;
    public NPC npcVictim;

    public SimulatorInfo()
    {
      this.player = new Player();
      this._originalDayTimeCounter = Main.time;
      this._originalDayTimeFlag = Main.dayTime;
      this._originalPlayerPosition = this.player.position;
      this.runningExpertMode = false;
    }

    public void ReturnToOriginalDaytime()
    {
      Main.dayTime = this._originalDayTimeFlag;
      Main.time = this._originalDayTimeCounter;
    }

    public void AddItem(int itemId, int amount) => this.itemCounter.AddItem(itemId, amount, this.runningExpertMode);

    public void ReturnToOriginalPlayerPosition() => this.player.position = this._originalPlayerPosition;
  }
}
