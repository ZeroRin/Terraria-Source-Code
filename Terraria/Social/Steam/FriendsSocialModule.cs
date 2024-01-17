// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.FriendsSocialModule
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Steamworks;

namespace Terraria.Social.Steam
{
  public class FriendsSocialModule : Terraria.Social.Base.FriendsSocialModule
  {
    public override void Initialize()
    {
    }

    public override void Shutdown()
    {
    }

    public override string GetUsername() => SteamFriends.GetPersonaName();

    public override void OpenJoinInterface() => SteamFriends.ActivateGameOverlay("Friends");
  }
}
