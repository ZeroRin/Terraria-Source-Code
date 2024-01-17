﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.UndergroundMushroomShader
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class UndergroundMushroomShader : ChromaShader
  {
    private readonly Vector4 _baseColor = new Color(10, 10, 10).ToVector4();
    private readonly Vector4 _edgeGlowColor = new Color(0, 0, (int) byte.MaxValue).ToVector4();
    private readonly Vector4 _sporeColor = new Color((int) byte.MaxValue, 230, 150).ToVector4();

    [RgbProcessor]
    private void ProcessLowDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Vector4 vector4 = Vector4.Lerp(this._edgeGlowColor, this._sporeColor, (float) (Math.Sin((double) time * 0.5 + (double) canvasPositionOfIndex.X) * 0.5 + 0.5));
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
      for (int index = 0; index < fragment.Count; ++index)
      {
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Vector4 vector4_1 = this._baseColor;
        float num = (float) ((((double) NoiseHelper.GetStaticNoise(gridPositionOfIndex.X) * 10.0 + (double) time * 0.20000000298023224) % 10.0 - (1.0 - (double) canvasPositionOfIndex.Y)) * 2.0);
        if ((double) num > 0.0)
        {
          float amount = Math.Max(0.0f, 1.5f - num);
          if ((double) num < 0.5)
            amount = num * 2f;
          vector4_1 = Vector4.Lerp(vector4_1, this._sporeColor, amount);
        }
        float amount1 = Math.Max(0.0f, (float) (1.0 - (double) NoiseHelper.GetStaticNoise(canvasPositionOfIndex * 0.3f + new Vector2(0.0f, time * 0.1f)) * (1.0 + (1.0 - (double) canvasPositionOfIndex.Y) * 4.0))) * Math.Max(0.0f, (float) (((double) canvasPositionOfIndex.Y - 0.30000001192092896) / 0.699999988079071));
        Vector4 vector4_2 = Vector4.Lerp(vector4_1, this._edgeGlowColor, amount1);
        fragment.SetColor(index, vector4_2);
      }
    }
  }
}
