// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.ActionPlaceStatue
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
