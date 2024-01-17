// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.BlizzardShader
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;

namespace Terraria.GameContent.RGB
{
  public class BlizzardShader : ChromaShader
  {
    private readonly Vector4 _backColor = new Vector4(0.1f, 0.1f, 0.3f, 1f);
    private readonly Vector4 _frontColor = new Vector4(1f, 1f, 1f, 1f);

    [RgbProcessor]
    private void ProcessHighDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      if (quality == null)
        time *= 0.25f;
      for (int index = 0; index < fragment.Count; ++index)
      {
        float staticNoise = NoiseHelper.GetStaticNoise(fragment.GetCanvasPositionOfIndex(index) * new Vector2(0.2f, 0.4f) + new Vector2(time * 0.35f, time * -0.35f));
        Vector4 vector4 = Vector4.Lerp(this._backColor, this._frontColor, staticNoise * staticNoise);
        fragment.SetColor(index, vector4);
      }
    }
  }
}
