// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.FriendsSocialModule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
