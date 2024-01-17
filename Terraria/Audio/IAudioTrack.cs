// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.IAudioTrack
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Audio;
using System;

namespace Terraria.Audio
{
  public interface IAudioTrack : IDisposable
  {
    bool IsPlaying { get; }

    bool IsStopped { get; }

    bool IsPaused { get; }

    void Stop(AudioStopOptions options);

    void Play();

    void Pause();

    void SetVariable(string variableName, float value);

    void Resume();

    void Reuse();

    void Update();
  }
}
