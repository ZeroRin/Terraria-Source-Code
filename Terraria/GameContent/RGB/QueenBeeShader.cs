// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.QueenBeeShader
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class QueenBeeShader : ChromaShader
  {
    private readonly Vector4 _primaryColor;
    private readonly Vector4 _secondaryColor;

    public QueenBeeShader(Color primaryColor, Color secondaryColor)
    {
      this._primaryColor = primaryColor.ToVector4();
      this._secondaryColor = secondaryColor.ToVector4();
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
        Vector4 vector4 = Vector4.Lerp(this._primaryColor, this._secondaryColor, (float) (Math.Sin((double) time * 2.0 + (double) canvasPositionOfIndex.X * 10.0) * 0.5 + 0.5));
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
      time *= 0.5f;
      for (int index = 0; index < fragment.Count; ++index)
      {
        Vector4 vector4 = Vector4.Lerp(this._primaryColor, this._secondaryColor, MathHelper.Clamp((float) Math.Sin((double) fragment.GetCanvasPositionOfIndex(index).X * 5.0 - 4.0 * (double) time) * 1.5f, 0.0f, 1f));
        fragment.SetColor(index, vector4);
      }
    }
  }
}
