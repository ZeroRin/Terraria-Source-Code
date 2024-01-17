// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.GameModeData
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.DataStructures
{
  public class GameModeData
  {
    public static readonly GameModeData NormalMode = new GameModeData()
    {
      Id = 0,
      EnemyMaxLifeMultiplier = 1f,
      EnemyDamageMultiplier = 1f,
      DebuffTimeMultiplier = 1f,
      KnockbackToEnemiesMultiplier = 1f,
      TownNPCDamageMultiplier = 1f,
      EnemyDefenseMultiplier = 1f,
      EnemyMoneyDropMultiplier = 1f
    };
    public static readonly GameModeData ExpertMode = new GameModeData()
    {
      Id = 1,
      IsExpertMode = true,
      EnemyMaxLifeMultiplier = 2f,
      EnemyDamageMultiplier = 2f,
      DebuffTimeMultiplier = 2f,
      KnockbackToEnemiesMultiplier = 0.9f,
      TownNPCDamageMultiplier = 1.5f,
      EnemyDefenseMultiplier = 1f,
      EnemyMoneyDropMultiplier = 2.5f
    };
    public static readonly GameModeData MasterMode = new GameModeData()
    {
      Id = 2,
      IsExpertMode = true,
      IsMasterMode = true,
      EnemyMaxLifeMultiplier = 3f,
      EnemyDamageMultiplier = 3f,
      DebuffTimeMultiplier = 2.5f,
      KnockbackToEnemiesMultiplier = 0.8f,
      TownNPCDamageMultiplier = 1.75f,
      EnemyDefenseMultiplier = 1f,
      EnemyMoneyDropMultiplier = 2.5f
    };
    public static readonly GameModeData CreativeMode = new GameModeData()
    {
      Id = 3,
      IsJourneyMode = true,
      EnemyMaxLifeMultiplier = 1f,
      EnemyDamageMultiplier = 1f,
      DebuffTimeMultiplier = 1f,
      KnockbackToEnemiesMultiplier = 1f,
      TownNPCDamageMultiplier = 2f,
      EnemyDefenseMultiplier = 1f,
      EnemyMoneyDropMultiplier = 1f
    };

    public int Id { get; private set; }

    public bool IsExpertMode { get; private set; }

    public bool IsMasterMode { get; private set; }

    public bool IsJourneyMode { get; private set; }

    public float EnemyMaxLifeMultiplier { get; private set; }

    public float EnemyDamageMultiplier { get; private set; }

    public float DebuffTimeMultiplier { get; private set; }

    public float KnockbackToEnemiesMultiplier { get; private set; }

    public float TownNPCDamageMultiplier { get; private set; }

    public float EnemyDefenseMultiplier { get; private set; }

    public float EnemyMoneyDropMultiplier { get; private set; }
  }
}
