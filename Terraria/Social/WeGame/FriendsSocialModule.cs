// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.FriendsSocialModule
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using rail;

namespace Terraria.Social.WeGame
{
  public class FriendsSocialModule : Terraria.Social.Base.FriendsSocialModule
  {
    public override void Initialize()
    {
    }

    public override void Shutdown()
    {
    }

    public override string GetUsername()
    {
      string username;
      rail_api.RailFactory().RailPlayer().GetPlayerName(ref username);
      WeGameHelper.WriteDebugString("GetUsername by wegame" + username);
      return username;
    }

    public override void OpenJoinInterface()
    {
      WeGameHelper.WriteDebugString("OpenJoinInterface by wegame");
      rail_api.RailFactory().RailFloatingWindow().AsyncShowRailFloatingWindow((EnumRailWindowType) 10, "");
    }
  }
}
