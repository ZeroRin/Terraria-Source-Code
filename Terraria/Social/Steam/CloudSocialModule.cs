﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.CloudSocialModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Steamworks;
using System;
using System.Collections.Generic;

namespace Terraria.Social.Steam
{
  public class CloudSocialModule : Terraria.Social.Base.CloudSocialModule
  {
    private const uint WRITE_CHUNK_SIZE = 1024;
    private object ioLock = new object();
    private byte[] writeBuffer = new byte[1024];

    public override void Initialize() => base.Initialize();

    public override void Shutdown()
    {
    }

    public override IEnumerable<string> GetFiles()
    {
      lock (this.ioLock)
      {
        int fileCount = SteamRemoteStorage.GetFileCount();
        List<string> files = new List<string>(fileCount);
        for (int index = 0; index < fileCount; ++index)
        {
          int num;
          files.Add(SteamRemoteStorage.GetFileNameAndSize(index, ref num));
        }
        return (IEnumerable<string>) files;
      }
    }

    public override bool Write(string path, byte[] data, int length)
    {
      lock (this.ioLock)
      {
        UGCFileWriteStreamHandle_t writeStreamHandleT = SteamRemoteStorage.FileWriteStreamOpen(path);
        for (uint sourceIndex = 0; (long) sourceIndex < (long) length; sourceIndex += 1024U)
        {
          int length1 = (int) Math.Min(1024L, (long) length - (long) sourceIndex);
          Array.Copy((Array) data, (long) sourceIndex, (Array) this.writeBuffer, 0L, (long) length1);
          SteamRemoteStorage.FileWriteStreamWriteChunk(writeStreamHandleT, this.writeBuffer, length1);
        }
        return SteamRemoteStorage.FileWriteStreamClose(writeStreamHandleT);
      }
    }

    public override int GetFileSize(string path)
    {
      lock (this.ioLock)
        return SteamRemoteStorage.GetFileSize(path);
    }

    public override void Read(string path, byte[] buffer, int size)
    {
      lock (this.ioLock)
        SteamRemoteStorage.FileRead(path, buffer, size);
    }

    public override bool HasFile(string path)
    {
      lock (this.ioLock)
        return SteamRemoteStorage.FileExists(path);
    }

    public override bool Delete(string path)
    {
      lock (this.ioLock)
        return SteamRemoteStorage.FileDelete(path);
    }
  }
}
