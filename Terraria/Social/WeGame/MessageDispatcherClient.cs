// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.MessageDispatcherClient
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
