﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.QueenSlimeShader
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class QueenSlimeShader : ChromaShader
  {
    private readonly Vector4 _slimeColor;
    private readonly Vector4 _debrisColor;

    public QueenSlimeShader(Color slimeColor, Color debrisColor)
    {
      this._slimeColor = slimeColor.ToVector4();
      this._debrisColor = debrisColor.ToVector4();
    }

    [RgbProcessor]
    private void ProcessLowDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector4 vector4 = Vector4.Lerp(this._slimeColor, this._debrisColor, Math.Max(0.0f, (float) (1.0 - (double) NoiseHelper.GetDynamicNoise(fragment.GetCanvasPositionOfIndex(index), time * 0.25f) * 2.0)));
        fragment.SetColor(index, vector4);
      }
    }

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      Vector2 vector2 = new Vector2(1.6f, 0.5f);
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector4 vector4 = Vector4.Lerp(this._slimeColor, this._debrisColor, (float) Math.Sqrt((double) Math.Max(0.0f, (float) (1.0 - (double) NoiseHelper.GetStaticNoise(fragment.GetCanvasPositionOfIndex(index) * 0.3f + new Vector2(0.0f, time * 0.1f)) * 3.0))));
        fragment.SetColor(index, vector4);
      }
    }
  }
}
