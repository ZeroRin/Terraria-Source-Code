// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenModShape
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.WorldBuilding
{
  public abstract class GenModShape : GenShape
  {
    protected ShapeData _data;

    public GenModShape(ShapeData data) => this._data = data;
  }
}
