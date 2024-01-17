﻿// Decompiled with JetBrains decompiler
// Type: Terraria.NPCSpawnParams
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.DataStructures;

namespace Terraria
{
  public struct NPCSpawnParams
  {
    public float? sizeScaleOverride;
    public int? playerCountForMultiplayerDifficultyOverride;
    public GameModeData gameModeData;
    public float? strengthMultiplierOverride;

    public NPCSpawnParams WithScale(float scaleOverride) => new NPCSpawnParams()
    {
      sizeScaleOverride = new float?(scaleOverride),
      playerCountForMultiplayerDifficultyOverride = this.playerCountForMultiplayerDifficultyOverride,
      gameModeData = this.gameModeData,
      strengthMultiplierOverride = this.strengthMultiplierOverride
    };
  }
}
