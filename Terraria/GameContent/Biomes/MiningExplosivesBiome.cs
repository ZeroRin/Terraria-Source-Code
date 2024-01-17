﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.MiningExplosivesBiome
// Assembly: Terraria, Version=1.4.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F541F3E5-89DE-4E5D-868F-1B56DAAB46B2
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes
{
  public class MiningExplosivesBiome : MicroBiome
  {
    public override bool Place(Point origin, StructureMap structures)
    {
      if (WorldGen.SolidTile(origin.X, origin.Y) || Main.tile[origin.X, origin.Y].wall == (ushort) 216 || Main.tile[origin.X, origin.Y].wall == (ushort) 187)
        return false;
      ushort type = Utils.SelectRandom<ushort>(GenBase._random, WorldGen.goldBar == 19 ? (ushort) 8 : (ushort) 169, WorldGen.silverBar == 21 ? (ushort) 9 : (ushort) 168, WorldGen.ironBar == 22 ? (ushort) 6 : (ushort) 167, WorldGen.copperBar == 20 ? (ushort) 7 : (ushort) 166);
      double x = GenBase._random.NextDouble() * 2.0 - 1.0;
      if (!WorldUtils.Find(origin, Searches.Chain(x > 0.0 ? (GenSearch) new Searches.Right(40) : (GenSearch) new Searches.Left(40), (GenCondition) new Conditions.IsSolid()), out origin))
        return false;
      if (!WorldUtils.Find(origin, Searches.Chain((GenSearch) new Searches.Down(80), (GenCondition) new Conditions.IsSolid()), out origin))
        return false;
      ShapeData shapeData = new ShapeData();
      Ref<int> count1 = new Ref<int>(0);
      Ref<int> count2 = new Ref<int>(0);
      WorldUtils.Gen(origin, new ShapeRunner(10f, 20, new Vector2((float) x, 1f)).Output(shapeData), Actions.Chain((GenAction) new Modifiers.Blotches(), (GenAction) new Actions.Scanner(count1), (GenAction) new Modifiers.IsSolid(), (GenAction) new Actions.Scanner(count2)));
      if (count2.Value < count1.Value / 2)
        return false;
      Microsoft.Xna.Framework.Rectangle area = new Microsoft.Xna.Framework.Rectangle(origin.X - 15, origin.Y - 10, 30, 20);
      if (!structures.CanPlace(area))
        return false;
      WorldUtils.Gen(origin, (GenShape) new ModShapes.All(shapeData), (GenAction) new Actions.SetTile(type, true));
      WorldUtils.Gen(new Point(origin.X - (int) (x * -5.0), origin.Y - 5), (GenShape) new Shapes.Circle(5), Actions.Chain((GenAction) new Modifiers.Blotches(), (GenAction) new Actions.ClearTile(true)));
      Point result1;
      int num1 = 1 & (WorldUtils.Find(new Point(origin.X - (x > 0.0 ? 3 : -3), origin.Y - 3), Searches.Chain((GenSearch) new Searches.Down(10), (GenCondition) new Conditions.IsSolid()), out result1) ? 1 : 0);
      int num2 = GenBase._random.Next(4) == 0 ? 3 : 7;
      Point result2;
      int num3 = WorldUtils.Find(new Point(origin.X - (x > 0.0 ? -num2 : num2), origin.Y - 3), Searches.Chain((GenSearch) new Searches.Down(10), (GenCondition) new Conditions.IsSolid()), out result2) ? 1 : 0;
      if ((num1 & num3) == 0)
        return false;
      --result1.Y;
      --result2.Y;
      Tile tile1 = GenBase._tiles[result1.X, result1.Y + 1];
      tile1.slope((byte) 0);
      tile1.halfBrick(false);
      for (int index = -1; index <= 1; ++index)
      {
        WorldUtils.ClearTile(result2.X + index, result2.Y);
        Tile tile2 = GenBase._tiles[result2.X + index, result2.Y + 1];
        if (!WorldGen.SolidOrSlopedTile(tile2))
        {
          tile2.ResetToType((ushort) 1);
          tile2.active(true);
        }
        tile2.slope((byte) 0);
        tile2.halfBrick(false);
        WorldUtils.TileFrame(result2.X + index, result2.Y + 1, true);
      }
      WorldGen.PlaceTile(result1.X, result1.Y, 141);
      WorldGen.PlaceTile(result2.X, result2.Y, 411, true, true);
      WorldUtils.WireLine(result1, result2);
      structures.AddProtectedStructure(area, 5);
      return true;
    }
  }
}
