// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Generation.ActionStalagtite
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
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
