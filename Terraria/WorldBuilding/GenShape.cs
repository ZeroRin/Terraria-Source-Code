﻿// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenShape
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.WorldBuilding
{
  public abstract class GenShape : GenBase
  {
    private ShapeData _outputData;
    protected bool _quitOnFail;

    public abstract bool Perform(Point origin, GenAction action);

    protected bool UnitApply(GenAction action, Point origin, int x, int y, params object[] args)
    {
      if (this._outputData != null)
        this._outputData.Add(x - origin.X, y - origin.Y);
      return action.Apply(origin, x, y, args);
    }

    public GenShape Output(ShapeData outputData)
    {
      this._outputData = outputData;
      return this;
    }

    public GenShape QuitOnFail(bool value = true)
    {
      this._quitOnFail = value;
      return this;
    }
  }
}
