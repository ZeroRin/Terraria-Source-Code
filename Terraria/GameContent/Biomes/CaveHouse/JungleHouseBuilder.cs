// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Biomes.CaveHouse.JungleHouseBuilder
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;

namespace Terraria.GameContent.Biomes.CaveHouse
{
  public class JungleHouseBuilder : HouseBuilder
  {
    public JungleHouseBuilder(IEnumerable<Microsoft.Xna.Framework.Rectangle> rooms)
      : base(HouseType.Jungle, rooms)
    {
      this.TileType = (ushort) 158;
      this.WallType = (ushort) 42;
      this.BeamType = (ushort) 575;
      this.PlatformStyle = 2;
      this.DoorStyle = 2;
      this.TableStyle = 2;
      this.WorkbenchStyle = 2;
      this.PianoStyle = 2;
      this.BookcaseStyle = 12;
      this.ChairStyle = 3;
      this.ChestStyle = 8;
    }

    protected override void AgeRoom(Microsoft.Xna.Framework.Rectangle room)
    {
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.60000002384185791), (GenAction) new Modifiers.Blotches(chance: 0.60000002384185791), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        this.TileType
      }), (GenAction) new Actions.SetTileKeepWall((ushort) 60, true), (GenAction) new Modifiers.Dither(0.800000011920929), (GenAction) new Actions.SetTileKeepWall((ushort) 59, true)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 60
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new Modifiers.IsEmpty(), (GenAction) new ActionVines(3, room.Height, 62)));
      WorldUtils.Gen(new Point(room.X + 1, room.Y + room.Height - 1), (GenShape) new Shapes.Rectangle(room.Width - 2, 1), Actions.Chain((GenAction) new Modifiers.Dither(), (GenAction) new Modifiers.OnlyTiles(new ushort[1]
      {
        (ushort) 60
      }), (GenAction) new Modifiers.Offset(0, 1), (GenAction) new Modifiers.IsEmpty(), (GenAction) new ActionVines(3, room.Height, 62)));
      WorldUtils.Gen(new Point(room.X, room.Y), (GenShape) new Shapes.Rectangle(room.Width, room.Height), Actions.Chain((GenAction) new Modifiers.Dither(0.85000002384185791), (GenAction) new Modifiers.Blotches(), (GenAction) new Actions.PlaceWall((ushort) 64)));
    }
  }
}
