// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenAction
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.WorldBuilding
{
  public abstract class GenAction : GenBase
  {
    public GenAction NextAction;
    public ShapeData OutputData;
    private bool _returnFalseOnFailure = true;

    public abstract bool Apply(Point origin, int x, int y, params object[] args);

    protected bool UnitApply(Point origin, int x, int y, params object[] args)
    {
      if (this.OutputData != null)
        this.OutputData.Add(x - origin.X, y - origin.Y);
      return this.NextAction == null || this.NextAction.Apply(origin, x, y, args);
    }

    public GenAction IgnoreFailures()
    {
      this._returnFalseOnFailure = false;
      return this;
    }

    protected bool Fail() => !this._returnFalseOnFailure;

    public GenAction Output(ShapeData data)
    {
      this.OutputData = data;
      return this;
    }
  }
}
