// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.IAudioSystem
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections;

namespace Terraria.Audio
{
  public interface IAudioSystem
  {
    void LoadCue(int cueIndex, string cueName);

    void PauseAll();

    void ResumeAll();

    void UpdateMisc();

    void UpdateAudioEngine();

    void UpdateAmbientCueState(
      int i,
      bool gameIsActive,
      ref float trackVolume,
      float systemVolume);

    void UpdateAmbientCueTowardStopping(
      int i,
      float stoppingSpeed,
      ref float trackVolume,
      float systemVolume);

    void UpdateCommonTrack(bool active, int i, float totalVolume, ref float tempFade);

    void UpdateCommonTrackTowardStopping(
      int i,
      float totalVolume,
      ref float tempFade,
      bool isMainTrackAudible);

    bool IsTrackPlaying(int trackIndex);

    IEnumerator PrepareWaveBank();
  }
}
