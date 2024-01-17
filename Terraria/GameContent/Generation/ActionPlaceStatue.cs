// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.ActionPlaceStatue
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Generation
{
  public class ActionPlaceStatue : GenAction
  {
    private int _statueIndex;

    public ActionPlaceStatue(int index = -1) => this._statueIndex = index;

    public override bool Apply(Point origin, int x, int y, params object[] args)
    {
      Point16 point16 = this._statueIndex != -1 ? WorldGen.statueList[this._statueIndex] : WorldGen.statueList[GenBase._random.Next(2, WorldGen.statueList.Length)];
      WorldGen.PlaceTile(x, y, (int) point16.X, true, style: (int) point16.Y);
      return this.UnitApply(origin, x, y, args);
    }
  }
}
