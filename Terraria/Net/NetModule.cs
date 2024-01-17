// Decompiled with JetBrains decompiler
// Type: Terraria.Net.NetModule
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.IO;

namespace Terraria.Net
{
  public abstract class NetModule
  {
    public abstract bool Deserialize(BinaryReader reader, int userId);

    protected static NetPacket CreatePacket<T>(int maxSize) where T : NetModule => new NetPacket(NetManager.Instance.GetId<T>(), maxSize);
  }
}
