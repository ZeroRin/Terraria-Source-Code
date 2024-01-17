// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.WormShader
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class WormShader : ChromaShader
  {
    private readonly Vector4 _skinColor;
    private readonly Vector4 _eyeColor;
    private readonly Vector4 _innerEyeColor;

    public WormShader()
    {
    }

    public WormShader(Color skinColor, Color eyeColor, Color innerEyeColor)
    {
      this._skinColor = skinColor.ToVector4();
      this._eyeColor = eyeColor.ToVector4();
      this._innerEyeColor = innerEyeColor.ToVector4();
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
        Vector4 vector4 = Vector4.Lerp(this._skinColor, this._eyeColor, Math.Max(0.0f, (float) Math.Sin((double) time * -3.0 + (double) canvasPositionOfIndex.X)));
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
      time *= 0.25f;
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector2 canvasPositionOfIndex = fragment.GetCanvasPositionOfIndex(index);
        canvasPositionOfIndex.X -= time * 1.5f;
        canvasPositionOfIndex.X %= 2f;
        if ((double) canvasPositionOfIndex.X < 0.0)
          canvasPositionOfIndex.X += 2f;
        float num1 = (canvasPositionOfIndex - new Vector2(0.5f)).Length();
        Vector4 vector4 = this._skinColor;
        if ((double) num1 < 0.5)
        {
          float num2 = MathHelper.Clamp((float) (((double) num1 - 0.5 + 0.20000000298023224) / 0.20000000298023224), 0.0f, 1f);
          vector4 = Vector4.Lerp(vector4, this._eyeColor, 1f - num2);
          if ((double) num1 < 0.40000000596046448)
          {
            float num3 = MathHelper.Clamp((float) (((double) num1 - 0.40000000596046448 + 0.20000000298023224) / 0.20000000298023224), 0.0f, 1f);
            vector4 = Vector4.Lerp(vector4, this._innerEyeColor, 1f - num3);
          }
        }
        fragment.SetColor(index, vector4);
      }
    }
  }
}
