// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.LootSimulation.SimulatorInfo
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
