﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.SkullShader
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class SkullShader : ChromaShader
  {
    private readonly Vector4 _skullColor;
    private readonly Vector4 _bloodDark;
    private readonly Vector4 _bloodLight;
    private readonly Vector4 _backgroundColor = Color.Black.ToVector4();

    public SkullShader(Color skullColor, Color bloodDark, Color bloodLight)
    {
      this._skullColor = skullColor.ToVector4();
      this._bloodDark = bloodDark.ToVector4();
      this._bloodLight = bloodLight.ToVector4();
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
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Vector4 vector4 = Vector4.Lerp(this._skullColor, this._bloodLight, (float) (Math.Sin((double) time * 2.0 + (double) canvasPositionOfIndex.X * 2.0) * 0.5 + 0.5));
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
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
        Vector4 vector4_1 = this._backgroundColor;
        float num = (float) (((double) NoiseHelper.GetStaticNoise(gridPositionOfIndex.X) * 10.0 + (double) time * 0.75) % 10.0 + (double) canvasPositionOfIndex.Y - 1.0);
        if ((double) num > 0.0)
        {
          float amount = Math.Max(0.0f, 1.2f - num);
          if ((double) num < 0.20000000298023224)
            amount = num * 5f;
          vector4_1 = Vector4.Lerp(vector4_1, this._skullColor, amount);
        }
        float staticNoise = NoiseHelper.GetStaticNoise(canvasPositionOfIndex * 0.5f + new Vector2(12.5f, time * 0.2f));
        float amount1 = MathHelper.Clamp(Math.Max(0.0f, (float) (1.0 - (double) staticNoise * (double) staticNoise * 4.0 * (double) staticNoise * (1.0 - (double) canvasPositionOfIndex.Y * (double) canvasPositionOfIndex.Y))) * canvasPositionOfIndex.Y * canvasPositionOfIndex.Y, 0.0f, 1f);
        Vector4 vector4_2 = Vector4.Lerp(this._bloodDark, this._bloodLight, amount1);
        Vector4 vector4_3 = Vector4.Lerp(vector4_1, vector4_2, amount1);
        fragment.SetColor(index, vector4_3);
      }
    }
  }
}
