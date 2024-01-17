// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.FishingAttempt
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.DataStructures
{
  public struct FishingAttempt
  {
    public PlayerFishingConditions playerFishingConditions;
    public int X;
    public int Y;
    public int bobberType;
    public bool common;
    public bool uncommon;
    public bool rare;
    public bool veryrare;
    public bool legendary;
    public bool crate;
    public bool inLava;
    public bool inHoney;
    public int waterTilesCount;
    public int waterNeededToFish;
    public float waterQuality;
    public int chumsInWater;
    public int fishingLevel;
    public bool CanFishInLava;
    public float atmo;
    public int questFish;
    public int heightLevel;
    public int rolledItemDrop;
    public int rolledEnemySpawn;
  }
}
