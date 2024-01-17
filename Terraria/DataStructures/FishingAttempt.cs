// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.FishingAttempt
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
