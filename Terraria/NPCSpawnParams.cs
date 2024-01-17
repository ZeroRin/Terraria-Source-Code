// Decompiled with JetBrains decompiler
// Type: Terraria.NPCSpawnParams
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
