// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.WeGameFriendListInfo
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using rail;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Terraria.Social.WeGame
{
  [DataContract]
  public class WeGameFriendListInfo
  {
    [DataMember]
    public List<RailFriendInfo> _friendList;
  }
}
