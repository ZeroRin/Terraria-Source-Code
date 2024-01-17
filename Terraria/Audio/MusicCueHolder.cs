﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.MusicCueHolder
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Audio;
using System;

namespace Terraria.Audio
{
  public class MusicCueHolder
  {
    private SoundBank _soundBank;
    private string _cueName;
    private Cue _loadedCue;
    private float _lastSetVolume;

    public MusicCueHolder(SoundBank soundBank, string cueName)
    {
      this._soundBank = soundBank;
      this._cueName = cueName;
      this._loadedCue = (Cue) null;
    }

    public void Pause()
    {
      if (this._loadedCue == null || this._loadedCue.IsPaused)
        return;
      if (!this._loadedCue.IsPlaying)
        return;
      try
      {
        this._loadedCue.Pause();
      }
      catch (Exception ex)
      {
      }
    }

    public void Resume()
    {
      if (this._loadedCue == null)
        return;
      if (!this._loadedCue.IsPaused)
        return;
      try
      {
        this._loadedCue.Resume();
      }
      catch (Exception ex)
      {
      }
    }

    public void Stop()
    {
      if (this._loadedCue == null)
        return;
      this.SetVolume(0.0f);
      this._loadedCue.Stop(AudioStopOptions.Immediate);
    }

    public bool IsPlaying => this._loadedCue != null && this._loadedCue.IsPlaying;

    public bool IsOngoing
    {
      get
      {
        if (this._loadedCue == null)
          return false;
        return this._loadedCue.IsPlaying || !this._loadedCue.IsStopped;
      }
    }

    public void RestartAndTryPlaying(float volume)
    {
      this.PurgeCue();
      this.TryPlaying(volume);
    }

    private void PurgeCue()
    {
      if (this._loadedCue == null)
        return;
      this._loadedCue.Stop(AudioStopOptions.Immediate);
      this._loadedCue.Dispose();
      this._loadedCue = (Cue) null;
    }

    public void Play(float volume)
    {
      this.LoadTrack(false);
      this.SetVolume(volume);
      this._loadedCue.Play();
    }

    public void TryPlaying(float volume)
    {
      this.LoadTrack(false);
      if (!this._loadedCue.IsPrepared)
        return;
      this.SetVolume(volume);
      if (this._loadedCue.IsPlaying)
        return;
      this._loadedCue.Play();
    }

    public void SetVolume(float volume)
    {
      this._lastSetVolume = volume;
      if (this._loadedCue == null)
        return;
      this._loadedCue.SetVariable("Volume", this._lastSetVolume);
    }

    private void LoadTrack(bool forceReload)
    {
      if (!forceReload && this._loadedCue != null)
        return;
      this._loadedCue = this._soundBank.GetCue(this._cueName);
    }
  }
}
