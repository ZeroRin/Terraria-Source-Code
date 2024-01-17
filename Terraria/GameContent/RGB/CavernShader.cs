﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.CavernShader
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class CavernShader : ChromaShader
  {
    private readonly Vector4 _backColor;
    private readonly Vector4 _frontColor;
    private readonly float _speed;

    public CavernShader(Color backColor, Color frontColor, float speed)
    {
      this._backColor = backColor.ToVector4();
      this._frontColor = frontColor.ToVector4();
      this._speed = speed;
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
        Vector4 vector4 = Vector4.Lerp(this._backColor, this._frontColor, (float) (Math.Sin((double) time * (double) this._speed + (double) canvasPositionOfIndex.X) * 0.5 + 0.5));
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
      time *= this._speed * 0.5f;
      float num1 = time % 1f;
      int num2 = (double) time % 2.0 > 1.0 ? 1 : 0;
      Vector4 vector4_1 = num2 != 0 ? this._frontColor : this._backColor;
      Vector4 vector4_2 = num2 != 0 ? this._backColor : this._frontColor;
      float num3 = num1 * 1.2f;
      for (int index = 0; index < fragment.Count; ++index)
      {
        float staticNoise = NoiseHelper.GetStaticNoise(fragment.GetCanvasPositionOfIndex(index) * 0.5f + new Vector2(0.0f, time * 0.5f));
        Vector4 vector4_3 = vector4_1;
        float num4 = staticNoise + num3;
        if ((double) num4 > 0.99900001287460327)
        {
          float amount = MathHelper.Clamp((float) (((double) num4 - 0.99900001287460327) / 0.20000000298023224), 0.0f, 1f);
          vector4_3 = Vector4.Lerp(vector4_3, vector4_2, amount);
        }
        fragment.SetColor(index, vector4_3);
      }
    }
  }
}
