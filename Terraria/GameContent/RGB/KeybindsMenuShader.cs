﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.KeybindsMenuShader
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  internal class KeybindsMenuShader : ChromaShader
  {
    private static Vector4 _baseColor = new Color(20, 20, 20, 245).ToVector4();

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      float num = (float) (Math.Cos((double) time * 1.5707963705062866) * 0.20000000298023224 + 0.800000011920929);
      Vector4 vector4 = (KeybindsMenuShader._baseColor * num) with
      {
        W = KeybindsMenuShader._baseColor.W
      };
      for (int index = 0; index < fragment.Count; ++index)
        fragment.SetColor(index, vector4);
    }
  }
}