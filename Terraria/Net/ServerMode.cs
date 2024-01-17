// Decompiled with JetBrains decompiler
// Type: Terraria.Net.ServerMode
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;

namespace Terraria.Net
{
  [Flags]
  public enum ServerMode : byte
  {
    None = 0,
    Lobby = 1,
    FriendsCanJoin = 2,
    FriendsOfFriends = 4,
  }
}
