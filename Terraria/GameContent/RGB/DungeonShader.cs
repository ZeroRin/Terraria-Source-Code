// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.DungeonShader
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class DungeonShader : ChromaShader
  {
    private readonly Vector4 _backgroundColor = new Color(5, 5, 5).ToVector4();
    private readonly Vector4 _spiritTrailColor = new Color(6, 51, 222).ToVector4();
    private readonly Vector4 _spiritColor = Color.White.ToVector4();

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
        float num = (float) ((((double) NoiseHelper.GetStaticNoise(gridPositionOfIndex.Y) * 10.0 + (double) time) % 10.0 - ((double) canvasPositionOfIndex.X + 2.0)) * 0.5);
        Vector4 vector4_1 = this._backgroundColor;
        if ((double) num > 0.0)
        {
          float amount1 = Math.Max(0.0f, 1.2f - num);
          float amount2 = MathHelper.Clamp(amount1 * amount1 * amount1, 0.0f, 1f);
          if ((double) num < 0.20000000298023224)
            amount1 = num / 0.2f;
          Vector4 vector4_2 = Vector4.Lerp(this._spiritTrailColor, this._spiritColor, amount2);
          vector4_1 = Vector4.Lerp(vector4_1, vector4_2, amount1);
        }
        fragment.SetColor(index, vector4_1);
      }
    }
  }
}
