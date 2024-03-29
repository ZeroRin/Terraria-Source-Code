﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.SpriteRenderTargetHelper
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Terraria.DataStructures;

namespace Terraria.Graphics
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct SpriteRenderTargetHelper
  {
    public static void GetDrawBoundary(
      List<DrawData> playerDrawData,
      out Vector2 lowest,
      out Vector2 highest)
    {
      lowest = Vector2.Zero;
      highest = Vector2.Zero;
      for (int index = 0; index <= playerDrawData.Count; ++index)
      {
        if (index != playerDrawData.Count)
        {
          DrawData cdd = playerDrawData[index];
          if (index == 0)
          {
            lowest = cdd.position;
            highest = cdd.position;
          }
          SpriteRenderTargetHelper.GetHighsAndLowsOf(ref lowest, ref highest, ref cdd);
        }
      }
    }

    public static void GetHighsAndLowsOf(ref Vector2 lowest, ref Vector2 highest, ref DrawData cdd)
    {
      Vector2 origin = cdd.origin;
      Rectangle rectangle = cdd.destinationRectangle;
      if (cdd.sourceRect.HasValue)
        rectangle = cdd.sourceRect.Value;
      if (!cdd.sourceRect.HasValue)
        rectangle = cdd.texture.Frame();
      rectangle.X = 0;
      rectangle.Y = 0;
      Vector2 position = cdd.position;
      SpriteRenderTargetHelper.GetHighsAndLowsOf(ref lowest, ref highest, ref cdd, ref position, ref origin, new Vector2(0.0f, 0.0f));
      SpriteRenderTargetHelper.GetHighsAndLowsOf(ref lowest, ref highest, ref cdd, ref position, ref origin, new Vector2((float) rectangle.Width, 0.0f));
      SpriteRenderTargetHelper.GetHighsAndLowsOf(ref lowest, ref highest, ref cdd, ref position, ref origin, new Vector2(0.0f, (float) rectangle.Height));
      SpriteRenderTargetHelper.GetHighsAndLowsOf(ref lowest, ref highest, ref cdd, ref position, ref origin, new Vector2((float) rectangle.Width, (float) rectangle.Height));
    }

    public static void GetHighsAndLowsOf(
      ref Vector2 lowest,
      ref Vector2 highest,
      ref DrawData cdd,
      ref Vector2 pos,
      ref Vector2 origin,
      Vector2 corner)
    {
      Vector2 corner1 = SpriteRenderTargetHelper.GetCorner(ref cdd, ref pos, ref origin, corner);
      lowest = Vector2.Min(lowest, corner1);
      highest = Vector2.Max(highest, corner1);
    }

    public static Vector2 GetCorner(
      ref DrawData cdd,
      ref Vector2 pos,
      ref Vector2 origin,
      Vector2 corner)
    {
      Vector2 spinningpoint = corner - origin;
      return pos + spinningpoint.RotatedBy((double) cdd.rotation) * cdd.scale;
    }
  }
}
