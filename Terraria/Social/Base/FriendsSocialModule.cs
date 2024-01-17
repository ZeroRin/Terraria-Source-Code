// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.FriendsSocialModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Social.Base
{
  public abstract class FriendsSocialModule : ISocialModule
  {
    public abstract string GetUsername();

    public abstract void OpenJoinInterface();

    public abstract void Initialize();

    public abstract void Shutdown();
  }
}
