// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenModShape
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.WorldBuilding
{
  public abstract class GenModShape : GenShape
  {
    protected ShapeData _data;

    public GenModShape(ShapeData data) => this._data = data;
  }
}
