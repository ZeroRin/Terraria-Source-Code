// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.MessageDispatcherClient
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;

namespace Terraria.Social.WeGame
{
  public class MessageDispatcherClient
  {
    private IPCClient _ipcClient = new IPCClient();
    private string _severName;
    private string _clientName;

    public event Action<IPCMessage> OnMessage;

    public event Action OnConnected;

    public void Init(string clientName, string serverName)
    {
      this._clientName = clientName;
      this._severName = serverName;
      this._ipcClient.Init(clientName);
      this._ipcClient.OnDataArrive += new Action<byte[]>(this.OnDataArrive);
      this._ipcClient.OnConnected += new Action(this.OnServerConnected);
    }

    public void Start() => this._ipcClient.ConnectTo(this._severName);

    private void OnDataArrive(byte[] data)
    {
      IPCMessage ipcMessage = new IPCMessage();
      ipcMessage.BuildFrom(data);
      if (this.OnMessage == null)
        return;
      this.OnMessage(ipcMessage);
    }

    private void OnServerConnected()
    {
      if (this.OnConnected == null)
        return;
      this.OnConnected();
    }

    public void Tick() => this._ipcClient.Tick();

    public bool SendMessage(IPCMessage msg) => this._ipcClient.Send(msg.GetBytes());
  }
}
