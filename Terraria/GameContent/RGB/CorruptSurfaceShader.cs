﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.CorruptSurfaceShader
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class CorruptSurfaceShader : ChromaShader
  {
    private readonly Vector4 _baseColor;
    private readonly Vector4 _skyColor;
    private Vector4 _lightColor;

    public CorruptSurfaceShader(Color color)
    {
      this._baseColor = color.ToVector4();
      this._skyColor = Vector4.Lerp(this._baseColor, Color.DeepSkyBlue.ToVector4(), 0.5f);
    }

    public CorruptSurfaceShader(Color vineColor, Color skyColor)
    {
      this._baseColor = vineColor.ToVector4();
      this._skyColor = skyColor.ToVector4();
    }

    public virtual void Update(float elapsedTime) => this._lightColor = Main.ColorOfTheSkies.ToVector4() * 0.75f + Vector4.One * 0.25f;

    [RgbProcessor]
    private void ProcessLowDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      Vector4 vector4_1 = this._skyColor * this._lightColor;
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Vector4 vector4_2 = Vector4.Lerp(this._baseColor, vector4_1, (float) (Math.Sin((double) time * 0.5 + (double) canvasPositionOfIndex.X) * 0.5 + 0.5));
        fragment.SetColor(index, vector4_2);
      }
    }

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      Vector4 vector4_1 = this._skyColor * this._lightColor;
      for (int index = 0; index < fragment.Count; ++index)
      {
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        float num1 = (float) (((double) NoiseHelper.GetStaticNoise(gridPositionOfIndex.X) * 10.0 + (double) time * 0.40000000596046448) % 10.0);
        float num2 = 1f;
        if ((double) num1 > 1.0)
        {
          num2 = MathHelper.Clamp((float) (1.0 - ((double) num1 - 1.3999999761581421)), 0.0f, 1f);
          num1 = 1f;
        }
        float num3 = (float) (Math.Sin((double) canvasPositionOfIndex.X) * 0.30000001192092896 + 0.699999988079071);
        float num4 = num1 - (1f - canvasPositionOfIndex.Y);
        Vector4 vector4_2 = vector4_1;
        if ((double) num4 > 0.0)
        {
          float num5 = 1f;
          if ((double) num4 < 0.20000000298023224)
            num5 = num4 * 5f;
          vector4_2 = Vector4.Lerp(vector4_2, this._baseColor, num5 * num2);
        }
        if ((double) canvasPositionOfIndex.Y > (double) num3)
          vector4_2 = this._baseColor;
        fragment.SetColor(index, vector4_2);
      }
    }
  }
}
