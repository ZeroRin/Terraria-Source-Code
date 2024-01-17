﻿// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenCondition
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.WorldBuilding
{
  public abstract class GenCondition : GenBase
  {
    private bool InvertResults;
    private int _width;
    private int _height;
    private GenCondition.AreaType _areaType = GenCondition.AreaType.None;

    public bool IsValid(int x, int y)
    {
      switch (this._areaType)
      {
        case GenCondition.AreaType.And:
          for (int x1 = x; x1 < x + this._width; ++x1)
          {
            for (int y1 = y; y1 < y + this._height; ++y1)
            {
              if (!this.CheckValidity(x1, y1))
                return this.InvertResults;
            }
          }
          return !this.InvertResults;
        case GenCondition.AreaType.Or:
          for (int x2 = x; x2 < x + this._width; ++x2)
          {
            for (int y2 = y; y2 < y + this._height; ++y2)
            {
              if (this.CheckValidity(x2, y2))
                return !this.InvertResults;
            }
          }
          return this.InvertResults;
        case GenCondition.AreaType.None:
          return this.CheckValidity(x, y) ^ this.InvertResults;
        default:
          return true;
      }
    }

    public GenCondition Not()
    {
      this.InvertResults = !this.InvertResults;
      return this;
    }

    public GenCondition AreaOr(int width, int height)
    {
      this._areaType = GenCondition.AreaType.Or;
      this._width = width;
      this._height = height;
      return this;
    }

    public GenCondition AreaAnd(int width, int height)
    {
      this._areaType = GenCondition.AreaType.And;
      this._width = width;
      this._height = height;
      return this;
    }

    protected abstract bool CheckValidity(int x, int y);

    private enum AreaType
    {
      And,
      Or,
      None,
    }
  }
}
