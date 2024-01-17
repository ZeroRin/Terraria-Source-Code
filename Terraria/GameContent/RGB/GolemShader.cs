// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.GolemShader
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class GolemShader : ChromaShader
  {
    private readonly Vector4 _glowColor;
    private readonly Vector4 _coreColor;
    private readonly Vector4 _backgroundColor;

    public GolemShader(Color glowColor, Color coreColor, Color backgroundColor)
    {
      this._glowColor = glowColor.ToVector4();
      this._coreColor = coreColor.ToVector4();
      this._backgroundColor = backgroundColor.ToVector4();
    }

    [RgbProcessor]
    private void ProcessLowDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      Vector4 vector4_1 = Vector4.Lerp(this._backgroundColor, this._coreColor, Math.Max(0.0f, (float) Math.Sin((double) time * 0.5)));
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Vector4 vector4_2 = Vector4.Lerp(vector4_1, this._glowColor, Math.Max(0.0f, (float) Math.Sin((double) canvasPositionOfIndex.X * 2.0 + (double) time + 101.0)));
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
      float num1 = (float) (0.5 + Math.Sin((double) time * 3.0) * 0.10000000149011612);
      Vector2 vector2 = new Vector2(1.6f, 0.5f);
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        Point gridPositionOfIndex = fragment.GetGridPositionOfIndex(index);
        Vector4 vector4 = this._backgroundColor;
        float num2 = (float) (((double) NoiseHelper.GetStaticNoise(gridPositionOfIndex.Y) * 10.0 + (double) time * 2.0) % 10.0) - Math.Abs(canvasPositionOfIndex.X - vector2.X);
        if ((double) num2 > 0.0)
        {
          float amount = Math.Max(0.0f, 1.2f - num2);
          if ((double) num2 < 0.20000000298023224)
            amount = num2 * 5f;
          vector4 = Vector4.Lerp(vector4, this._glowColor, amount);
        }
        float num3 = (canvasPositionOfIndex - vector2).Length();
        if ((double) num3 < (double) num1)
        {
          float amount = 1f - MathHelper.Clamp((float) (((double) num3 - (double) num1 + 0.10000000149011612) / 0.10000000149011612), 0.0f, 1f);
          vector4 = Vector4.Lerp(vector4, this._coreColor, amount);
        }
        fragment.SetColor(index, vector4);
      }
    }
  }
}
