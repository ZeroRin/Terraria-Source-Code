// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.LowLifeShader
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using ReLogic.Peripherals.RGB;
using System;

namespace Terraria.GameContent.RGB
{
  public class LowLifeShader : ChromaShader
  {
    private static Vector4 _baseColor = new Color(40, 0, 8, (int) byte.MaxValue).ToVector4();

    [RgbProcessor]
    private void ProcessAnyDetail(
      RgbDevice device,
      Fragment fragment,
      EffectDetailLevel quality,
      float time)
    {
      float num = (float) (Math.Cos((double) time * 3.1415927410125732) * 0.30000001192092896 + 0.699999988079071);
      Vector4 vector4 = (LowLifeShader._baseColor * num) with
      {
        W = LowLifeShader._baseColor.W
      };
      for (int index = 0; index < fragment.Count; ++index)
        fragment.SetColor(index, vector4);
    }
  }
}
