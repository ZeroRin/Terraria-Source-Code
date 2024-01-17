// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.ServerJoinRequestsManager
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Terraria.Social.Base
{
  public class ServerJoinRequestsManager
  {
    private readonly List<UserJoinToServerRequest> _requests;
    public readonly ReadOnlyCollection<UserJoinToServerRequest> CurrentRequests;

    public event ServerJoinRequestEvent OnRequestAdded;

    public event ServerJoinRequestEvent OnRequestRemoved;

    public ServerJoinRequestsManager()
    {
      this._requests = new List<UserJoinToServerRequest>();
      this.CurrentRequests = new ReadOnlyCollection<UserJoinToServerRequest>((IList<UserJoinToServerRequest>) this._requests);
    }

    public void Update()
    {
      for (int index = this._requests.Count - 1; index >= 0; --index)
      {
        if (!this._requests[index].IsValid())
          this.RemoveRequestAtIndex(index);
      }
    }

    public void Add(UserJoinToServerRequest request)
    {
      for (int index = this._requests.Count - 1; index >= 0; --index)
      {
        if (this._requests[index].Equals((object) request))
          this.RemoveRequestAtIndex(index);
      }
      this._requests.Add(request);
      request.OnAccepted += (Action) (() => this.RemoveRequest(request));
      request.OnRejected += (Action) (() => this.RemoveRequest(request));
      if (this.OnRequestAdded == null)
        return;
      this.OnRequestAdded(request);
    }

    private void RemoveRequestAtIndex(int i)
    {
      UserJoinToServerRequest request = this._requests[i];
      this._requests.RemoveAt(i);
      if (this.OnRequestRemoved == null)
        return;
      this.OnRequestRemoved(request);
    }

    private void RemoveRequest(UserJoinToServerRequest request)
    {
      if (!this._requests.Remove(request) || this.OnRequestRemoved == null)
        return;
      this.OnRequestRemoved(request);
    }
  }
}
