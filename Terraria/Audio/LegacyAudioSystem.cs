// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.LegacyAudioSystem
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections;

namespace Terraria.Audio
{
  public class LegacyAudioSystem : IAudioSystem
  {
    private Cue[] music;
    private int _musicReplayDelay;
    private AudioEngine engine;
    private SoundBank soundBank;
    private WaveBank waveBank;

    public LegacyAudioSystem()
    {
      this.engine = new AudioEngine("Content\\TerrariaMusic.xgs");
      this.soundBank = new SoundBank(this.engine, "Content\\Sound Bank.xsb");
      this.engine.Update();
      this.waveBank = new WaveBank(this.engine, "Content\\Wave Bank.xwb", 0, (short) 512);
      this.engine.Update();
      this.music = new Cue[90];
    }

    public IEnumerator PrepareWaveBank()
    {
      while (!this.waveBank.IsPrepared)
      {
        this.engine.Update();
        yield return (object) null;
      }
    }

    public void LoadCue(int cueIndex, string cueName) => this.music[cueIndex] = this.soundBank.GetCue(cueName);

    public void UpdateMisc()
    {
      if (Main.curMusic != Main.newMusic)
        this._musicReplayDelay = 0;
      if (this._musicReplayDelay <= 0)
        return;
      --this._musicReplayDelay;
    }

    public void PauseAll()
    {
      if (!this.waveBank.IsPrepared)
        return;
      float[] musicFade = Main.musicFade;
      for (int index = 0; index < this.music.Length; ++index)
      {
        if (this.music[index] != null && !this.music[index].IsPaused && this.music[index].IsPlaying)
        {
          if ((double) musicFade[index] > 0.0)
          {
            try
            {
              this.music[index].Pause();
            }
            catch (Exception ex)
            {
            }
          }
        }
      }
    }

    public void ResumeAll()
    {
      if (!this.waveBank.IsPrepared)
        return;
      float[] musicFade = Main.musicFade;
      for (int index = 0; index < this.music.Length; ++index)
      {
        if (this.music[index] != null && this.music[index].IsPaused)
        {
          if ((double) musicFade[index] > 0.0)
          {
            try
            {
              this.music[index].Resume();
            }
            catch (Exception ex)
            {
            }
          }
        }
      }
    }

    public void UpdateAmbientCueState(
      int i,
      bool gameIsActive,
      ref float trackVolume,
      float systemVolume)
    {
      if (!this.waveBank.IsPrepared)
        return;
      if ((double) systemVolume == 0.0)
      {
        if (!this.music[i].IsPlaying)
          return;
        this.music[i].Stop(AudioStopOptions.Immediate);
      }
      else if (!this.music[i].IsPlaying)
      {
        this.music[i].Stop(AudioStopOptions.Immediate);
        this.music[i] = this.soundBank.GetCue("Music_" + (object) i);
        this.music[i].Play();
        this.music[i].SetVariable("Volume", trackVolume * systemVolume);
      }
      else if (this.music[i].IsPaused & gameIsActive)
      {
        this.music[i].Resume();
      }
      else
      {
        trackVolume += 0.005f;
        if ((double) trackVolume > 1.0)
          trackVolume = 1f;
        this.music[i].SetVariable("Volume", trackVolume * systemVolume);
      }
    }

    public void UpdateAmbientCueTowardStopping(
      int i,
      float stoppingSpeed,
      ref float trackVolume,
      float systemVolume)
    {
      if (!this.waveBank.IsPrepared)
        return;
      if (!this.music[i].IsPlaying)
      {
        trackVolume = 0.0f;
      }
      else
      {
        if ((double) trackVolume > 0.0)
        {
          trackVolume -= stoppingSpeed;
          if ((double) trackVolume < 0.0)
            trackVolume = 0.0f;
        }
        if ((double) trackVolume <= 0.0)
          this.music[i].Stop(AudioStopOptions.Immediate);
        else
          this.music[i].SetVariable("Volume", trackVolume * systemVolume);
      }
    }

    public bool IsTrackPlaying(int trackIndex) => this.waveBank.IsPrepared && this.music[trackIndex].IsPlaying;

    public void UpdateCommonTrack(bool active, int i, float totalVolume, ref float tempFade)
    {
      if (!this.waveBank.IsPrepared)
        return;
      tempFade += 0.005f;
      if ((double) tempFade > 1.0)
        tempFade = 1f;
      if (!this.music[i].IsPlaying & active)
      {
        if (this._musicReplayDelay != 0)
          return;
        if (Main.SettingMusicReplayDelayEnabled)
          this._musicReplayDelay = Main.rand.Next(14400, 21601);
        this.music[i].Stop(AudioStopOptions.Immediate);
        this.music[i] = this.soundBank.GetCue("Music_" + (object) i);
        this.music[i].SetVariable("Volume", totalVolume);
        this.music[i].Play();
      }
      else
        this.music[i].SetVariable("Volume", totalVolume);
    }

    public void UpdateCommonTrackTowardStopping(
      int i,
      float totalVolume,
      ref float tempFade,
      bool isMainTrackAudible)
    {
      if (!this.waveBank.IsPrepared)
        return;
      if (this.music[i].IsPlaying || !this.music[i].IsStopped)
      {
        if (isMainTrackAudible)
          tempFade -= 0.005f;
        else if (Main.curMusic == 0)
          tempFade = 0.0f;
        if ((double) tempFade <= 0.0)
        {
          tempFade = 0.0f;
          this.music[i].SetVariable("Volume", 0.0f);
          this.music[i].Stop(AudioStopOptions.Immediate);
        }
        else
          this.music[i].SetVariable("Volume", totalVolume);
      }
      else
        tempFade = 0.0f;
    }

    public void UpdateAudioEngine() => this.engine.Update();
  }
}
