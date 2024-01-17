// Decompiled with JetBrains decompiler
// Type: Terraria.RemoteServer
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.IO;
using Terraria.Localization;
using Terraria.Net.Sockets;

namespace Terraria
{
  public class RemoteServer
  {
    public ISocket Socket = (ISocket) new TcpSocket();
    public bool IsActive;
    public int State;
    public int TimeOutTimer;
    public bool IsReading;
    public byte[] ReadBuffer;
    public string StatusText;
    public int StatusCount;
    public int StatusMax;
    public BitsByte ServerSpecialFlags;

    public bool HideStatusTextPercent => this.ServerSpecialFlags[0];

    public bool StatusTextHasShadows => this.ServerSpecialFlags[1];

    public bool ServerWantsToRunCheckBytesInClientLoopThread => this.ServerSpecialFlags[2];

    public void ResetSpecialFlags() => this.ServerSpecialFlags = (BitsByte) (byte) 0;

    public void ClientWriteCallBack(object state) => --NetMessage.buffer[256].spamCount;

    public void ClientReadCallBack(object state, int length)
    {
      try
      {
        if (!Netplay.Disconnect)
        {
          int streamLength = length;
          if (streamLength == 0)
          {
            Netplay.Disconnect = true;
            Main.statusText = Language.GetTextValue("Net.LostConnection");
          }
          else if (Main.ignoreErrors)
          {
            try
            {
              NetMessage.ReceiveBytes(this.ReadBuffer, streamLength);
            }
            catch
            {
            }
          }
          else
            NetMessage.ReceiveBytes(this.ReadBuffer, streamLength);
        }
        this.IsReading = false;
      }
      catch (Exception ex)
      {
        try
        {
          using (StreamWriter streamWriter = new StreamWriter("client-crashlog.txt", true))
          {
            streamWriter.WriteLine((object) DateTime.Now);
            streamWriter.WriteLine((object) ex);
            streamWriter.WriteLine("");
          }
        }
        catch
        {
        }
        Netplay.Disconnect = true;
      }
    }
  }
}
