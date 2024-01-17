// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.UserJoinToServerRequest
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;

namespace Terraria.Social.Base
{
  public abstract class UserJoinToServerRequest
  {
    internal string UserDisplayName { get; private set; }

    internal string UserFullIdentifier { get; private set; }

    public event Action OnAccepted;

    public event Action OnRejected;

    public UserJoinToServerRequest(string userDisplayName, string fullIdentifier)
    {
      this.UserDisplayName = userDisplayName;
      this.UserFullIdentifier = fullIdentifier;
    }

    public void Accept()
    {
      if (this.OnAccepted == null)
        return;
      this.OnAccepted();
    }

    public void Reject()
    {
      if (this.OnRejected == null)
        return;
      this.OnRejected();
    }

    public abstract bool IsValid();

    public abstract string GetUserWrapperText();
  }
}
