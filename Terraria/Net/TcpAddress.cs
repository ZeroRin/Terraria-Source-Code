// Decompiled with JetBrains decompiler
// Type: Terraria.Net.TcpAddress
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Net;

namespace Terraria.Net
{
  public class TcpAddress : RemoteAddress
  {
    public IPAddress Address;
    public int Port;

    public TcpAddress(IPAddress address, int port)
    {
      this.Type = AddressType.Tcp;
      this.Address = address;
      this.Port = port;
    }

    public override string GetIdentifier() => this.Address.ToString();

    public override bool IsLocalHost() => this.Address.Equals((object) IPAddress.Loopback);

    public override string ToString() => new IPEndPoint(this.Address, this.Port).ToString();

    public override string GetFriendlyName() => this.ToString();
  }
}
