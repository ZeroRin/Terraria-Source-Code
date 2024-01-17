﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.IPCMessage
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Terraria.Social.WeGame
{
  public class IPCMessage
  {
    private IPCMessageType _cmd;
    private string _jsonData;

    public void Build<T>(IPCMessageType cmd, T t)
    {
      this._jsonData = WeGameHelper.Serialize<T>(t);
      this._cmd = cmd;
    }

    public void BuildFrom(byte[] data)
    {
      byte[] array1 = ((IEnumerable<byte>) data).Take<byte>(4).ToArray<byte>();
      byte[] array2 = ((IEnumerable<byte>) data).Skip<byte>(4).ToArray<byte>();
      this._cmd = (IPCMessageType) BitConverter.ToInt32(array1, 0);
      this._jsonData = Encoding.UTF8.GetString(array2);
    }

    public void Parse<T>(out T value) => WeGameHelper.UnSerialize<T>(this._jsonData, out value);

    public byte[] GetBytes()
    {
      List<byte> byteList = new List<byte>();
      byteList.AddRange((IEnumerable<byte>) BitConverter.GetBytes((int) this._cmd));
      byteList.AddRange((IEnumerable<byte>) Encoding.UTF8.GetBytes(this._jsonData));
      return byteList.ToArray();
    }

    public IPCMessageType GetCmd() => this._cmd;
  }
}
