// Decompiled with JetBrains decompiler
// Type: Terraria.Audio.SoundInstanceGarbageCollector
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Terraria.Audio
{
  public static class SoundInstanceGarbageCollector
  {
    private static readonly List<SoundEffectInstance> _activeSounds = new List<SoundEffectInstance>(128);

    public static void Track(SoundEffectInstance sound)
    {
    }

    public static void Update()
    {
      for (int index = 0; index < SoundInstanceGarbageCollector._activeSounds.Count; ++index)
      {
        if (SoundInstanceGarbageCollector._activeSounds[index] == null)
        {
          SoundInstanceGarbageCollector._activeSounds.RemoveAt(index);
          --index;
        }
        else if (SoundInstanceGarbageCollector._activeSounds[index].State == SoundState.Stopped)
        {
          SoundInstanceGarbageCollector._activeSounds[index].Dispose();
          SoundInstanceGarbageCollector._activeSounds.RemoveAt(index);
          --index;
        }
      }
    }
  }
}
