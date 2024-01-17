// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.DisabledAudioSystem
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using ReLogic.Content.Sources;
using System.Collections;
using System.Collections.Generic;

namespace Terraria.Audio
{
  public class DisabledAudioSystem : IAudioSystem
  {
    public void LoadFromSources()
    {
    }

    public void UseSources(List<IContentSource> sources)
    {
    }

    public void Update()
    {
    }

    public void UpdateMisc()
    {
    }

    public IEnumerator PrepareWaveBank()
    {
      yield break;
    }

    public void LoadCue(int cueIndex, string cueName)
    {
    }

    public void PauseAll()
    {
    }

    public void ResumeAll()
    {
    }

    public void UpdateAmbientCueState(
      int i,
      bool gameIsActive,
      ref float trackVolume,
      float systemVolume)
    {
    }

    public void UpdateAmbientCueTowardStopping(
      int i,
      float stoppingSpeed,
      ref float trackVolume,
      float systemVolume)
    {
    }

    public bool IsTrackPlaying(int trackIndex) => false;

    public void UpdateCommonTrack(bool active, int i, float totalVolume, ref float tempFade)
    {
    }

    public void UpdateCommonTrackTowardStopping(
      int i,
      float totalVolume,
      ref float tempFade,
      bool isMainTrackAudible)
    {
    }

    public void UpdateAudioEngine()
    {
    }
  }
}
