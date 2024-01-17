// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.DesertShader
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class DesertShader : ChromaShader
  {
    private readonly Vector4 _baseColor;
    private readonly Vector4 _sandColor;

    public DesertShader(Color baseColor, Color sandColor)
    {
      this._baseColor = baseColor.ToVector4();
      this._sandColor = sandColor.ToVector4();
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
        fragment.GetGridPositionOfIndex(index);
        canvasPositionOfIndex.Y += (float) Math.Sin((double) canvasPositionOfIndex.X * 2.0 + (double) time * 2.0) * 0.2f;
        float staticNoise = NoiseHelper.GetStaticNoise(canvasPositionOfIndex * new Vector2(0.1f, 0.5f));
        Vector4 vector4 = Vector4.Lerp(this._baseColor, this._sandColor, staticNoise * staticNoise);
        fragment.SetColor(index, vector4);
      }
    }
  }
}
