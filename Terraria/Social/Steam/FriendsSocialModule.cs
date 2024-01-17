// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.FriendsSocialModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
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
