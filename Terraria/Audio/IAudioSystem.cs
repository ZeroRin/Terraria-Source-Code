// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.IAudioSystem
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using ReLogic.Content.Sources;
using System.Collections;
using System.Collections.Generic;

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

    void UseSources(List<IContentSource> sources);

    IEnumerator PrepareWaveBank();

    void LoadFromSources();

    void Update();
  }
}
