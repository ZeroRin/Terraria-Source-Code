﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.WallOfFleshShader
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class WallOfFleshShader : ChromaShader
  {
    private readonly Vector4 _primaryColor;
    private readonly Vector4 _secondaryColor;

    public WallOfFleshShader(Color primaryColor, Color secondaryColor)
    {
      this._primaryColor = primaryColor.ToVector4();
      this._secondaryColor = secondaryColor.ToVector4();
    }

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector4 vector4 = Vector4.Lerp(this._secondaryColor, this._primaryColor, (float) Math.Sqrt((double) Math.Max(0.0f, (float) (1.0 - (double) NoiseHelper.GetDynamicNoise(fragment.GetCanvasPositionOfIndex(index) * 0.3f, time / 5f) * 2.0))) * 0.75f);
        fragment.SetColor(index, vector4);
      }
    }
  }
}
