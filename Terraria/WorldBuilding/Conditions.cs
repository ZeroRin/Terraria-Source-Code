// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.Conditions
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.WorldBuilding
{
  public static class Conditions
  {
    public class IsTile : GenCondition
    {
      private ushort[] _types;

      public IsTile(params ushort[] types) => this._types = types;

      protected override bool CheckValidity(int x, int y)
      {
        if (GenBase._tiles[x, y].active())
        {
          for (int index = 0; index < this._types.Length; ++index)
          {
            if ((int) GenBase._tiles[x, y].type == (int) this._types[index])
              return true;
          }
        }
        return false;
      }
    }

    public class Continue : GenCondition
    {
      protected override bool CheckValidity(int x, int y) => false;
    }

    public class MysticSnake : GenCondition
    {
      protected override bool CheckValidity(int x, int y) => GenBase._tiles[x, y].active() && !Main.tileCut[(int) GenBase._tiles[x, y].type] && GenBase._tiles[x, y].type != (ushort) 504;
    }

    public class IsSolid : GenCondition
    {
      protected override bool CheckValidity(int x, int y) => WorldGen.InWorld(x, y, 10) && GenBase._tiles[x, y].active() && Main.tileSolid[(int) GenBase._tiles[x, y].type];
    }

    public class HasLava : GenCondition
    {
      protected override bool CheckValidity(int x, int y) => GenBase._tiles[x, y].liquid > (byte) 0 && GenBase._tiles[x, y].liquidType() == (byte) 1;
    }

    public class NotNull : GenCondition
    {
      protected override bool CheckValidity(int x, int y) => GenBase._tiles[x, y] != null;
    }
  }
}
