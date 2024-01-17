// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.ActionStalagtite
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Generation
{
  public class ActionStalagtite : GenAction
  {
    public override bool Apply(Point origin, int x, int y, params object[] args)
    {
      WorldGen.PlaceTight(x, y);
      return this.UnitApply(origin, x, y, args);
    }
  }
}
