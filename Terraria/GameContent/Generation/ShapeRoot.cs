// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.ShapeRoot
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Generation
{
  public class ShapeRoot : GenShape
  {
    private float _angle;
    private float _startingSize;
    private float _endingSize;
    private float _distance;

    public ShapeRoot(float angle, float distance = 10f, float startingSize = 4f, float endingSize = 1f)
    {
      this._angle = angle;
      this._distance = distance;
      this._startingSize = startingSize;
      this._endingSize = endingSize;
    }

    private bool DoRoot(
      Point origin,
      GenAction action,
      float angle,
      float distance,
      float startingSize)
    {
      float x = (float) origin.X;
      float y = (float) origin.Y;
      for (float num1 = 0.0f; (double) num1 < (double) distance * 0.85000002384185791; ++num1)
      {
        float amount = num1 / distance;
        float num2 = MathHelper.Lerp(startingSize, this._endingSize, amount);
        x += (float) Math.Cos((double) angle);
        y += (float) Math.Sin((double) angle);
        angle += (float) ((double) GenBase._random.NextFloat() - 0.5 + (double) GenBase._random.NextFloat() * ((double) this._angle - 1.5707963705062866) * 0.10000000149011612 * (1.0 - (double) amount));
        angle = (float) ((double) angle * 0.40000000596046448 + 0.44999998807907104 * (double) MathHelper.Clamp(angle, this._angle - (float) (2.0 * (1.0 - 0.5 * (double) amount)), this._angle + (float) (2.0 * (1.0 - 0.5 * (double) amount))) + (double) MathHelper.Lerp(this._angle, 1.57079637f, amount) * 0.15000000596046448);
        for (int index1 = 0; index1 < (int) num2; ++index1)
        {
          for (int index2 = 0; index2 < (int) num2; ++index2)
          {
            if (!this.UnitApply(action, origin, (int) x + index1, (int) y + index2) && this._quitOnFail)
              return false;
          }
        }
      }
      return true;
    }

    public override bool Perform(Point origin, GenAction action) => this.DoRoot(origin, action, this._angle, this._distance, this._startingSize);
  }
}
