// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenSearch
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.WorldBuilding
{
  public abstract class GenSearch : GenBase
  {
    public static Point NOT_FOUND = new Point(int.MaxValue, int.MaxValue);
    private bool _requireAll = true;
    private GenCondition[] _conditions;

    public GenSearch Conditions(params GenCondition[] conditions)
    {
      this._conditions = conditions;
      return this;
    }

    public abstract Point Find(Point origin);

    protected bool Check(int x, int y)
    {
      for (int index = 0; index < this._conditions.Length; ++index)
      {
        if (this._requireAll ^ this._conditions[index].IsValid(x, y))
          return !this._requireAll;
      }
      return this._requireAll;
    }

    public GenSearch RequireAll(bool mode)
    {
      this._requireAll = mode;
      return this;
    }
  }
}
