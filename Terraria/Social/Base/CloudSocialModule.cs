// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.CloudSocialModule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Collections.Generic;
using Terraria.IO;

namespace Terraria.Social.Base
{
  public abstract class CloudSocialModule : ISocialModule
  {
    public bool EnabledByDefault;

    public virtual void Initialize()
    {
      Main.Configuration.OnLoad += (Action<Preferences>) (preferences => this.EnabledByDefault = preferences.Get<bool>("CloudSavingDefault", false));
      Main.Configuration.OnSave += (Action<Preferences>) (preferences => preferences.Put("CloudSavingDefault", (object) this.EnabledByDefault));
    }

    public abstract void Shutdown();

    public abstract IEnumerable<string> GetFiles();

    public abstract bool Write(string path, byte[] data, int length);

    public abstract void Read(string path, byte[] buffer, int length);

    public abstract bool HasFile(string path);

    public abstract int GetFileSize(string path);

    public abstract bool Delete(string path);

    public byte[] Read(string path)
    {
      byte[] buffer = new byte[this.GetFileSize(path)];
      this.Read(path, buffer, buffer.Length);
      return buffer;
    }

    public void Read(string path, byte[] buffer) => this.Read(path, buffer, buffer.Length);

    public bool Write(string path, byte[] data) => this.Write(path, data, data.Length);
  }
}
