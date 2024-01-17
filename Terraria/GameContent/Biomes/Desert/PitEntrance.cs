﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.Desert.PitEntrance
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria.GameContent.Biomes.Desert
{
  public static class PitEntrance
  {
    public static void Place(DesertDescription description)
    {
      int holeRadius = WorldGen.genRand.Next(6, 9);
      Point center = description.CombinedArea.Center;
      center.Y = (int) description.Surface[center.X];
      PitEntrance.PlaceAt(description, center, holeRadius);
    }

    private static void PlaceAt(DesertDescription description, Point position, int holeRadius)
    {
      for (int index = -holeRadius - 3; index < holeRadius + 3; ++index)
      {
        int j = (int) description.Surface[index + position.X];
        while (true)
        {
          int num1 = j;
          Rectangle rectangle = description.Hive;
          int num2 = rectangle.Top + 10;
          if (num1 <= num2)
          {
            double num3 = (double) (j - (int) description.Surface[index + position.X]);
            rectangle = description.Hive;
            int top1 = rectangle.Top;
            rectangle = description.Desert;
            int top2 = rectangle.Top;
            double num4 = (double) (top1 - top2);
            float yProgress = MathHelper.Clamp((float) (num3 / num4), 0.0f, 1f);
            int num5 = (int) ((double) PitEntrance.GetHoleRadiusScaleAt(yProgress) * (double) holeRadius);
            if (Math.Abs(index) < num5)
              Main.tile[index + position.X, j].ClearEverything();
            else if (Math.Abs(index) < num5 + 3 && (double) yProgress > 0.34999999403953552)
              Main.tile[index + position.X, j].ResetToType((ushort) 397);
            float num6 = Math.Abs((float) index / (float) holeRadius);
            float num7 = num6 * num6;
            if (Math.Abs(index) < num5 + 3 && (double) (j - position.Y) > 15.0 - 3.0 * (double) num7)
            {
              Main.tile[index + position.X, j].wall = (ushort) 187;
              WorldGen.SquareWallFrame(index + position.X, j - 1);
              WorldGen.SquareWallFrame(index + position.X, j);
            }
            ++j;
          }
          else
            break;
        }
      }
      holeRadius += 4;
      for (int index1 = -holeRadius; index1 < holeRadius; ++index1)
      {
        int num8 = holeRadius - Math.Abs(index1);
        int num9 = Math.Min(10, num8 * num8);
        for (int index2 = 0; index2 < num9; ++index2)
          Main.tile[index1 + position.X, index2 + (int) description.Surface[index1 + position.X]].ClearEverything();
      }
    }

    private static float GetHoleRadiusScaleAt(float yProgress) => (double) yProgress < 0.60000002384185791 ? 1f : (float) ((1.0 - (double) PitEntrance.SmootherStep((float) (((double) yProgress - 0.60000002384185791) / 0.40000000596046448))) * 0.5 + 0.5);

    private static float SmootherStep(float delta)
    {
      delta = MathHelper.Clamp(delta, 0.0f, 1f);
      return (float) (1.0 - Math.Cos((double) delta * 3.1415927410125732) * 0.5 - 0.5);
    }
  }
}
