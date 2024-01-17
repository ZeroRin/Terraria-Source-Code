// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NetModules.NetCreativeUnlocksModule
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.IO;
using Terraria.ID;
using Terraria.Net;

namespace Terraria.GameContent.NetModules
{
  public class NetCreativeUnlocksModule : NetModule
  {
    public static NetPacket SerializeItemSacrifice(int itemId, int sacrificeCount)
    {
      NetPacket packet = NetModule.CreatePacket<NetCreativeUnlocksModule>(3);
      packet.Writer.Write((short) itemId);
      packet.Writer.Write((ushort) sacrificeCount);
      return packet;
    }

    public override bool Deserialize(BinaryReader reader, int userId)
    {
      short key = reader.ReadInt16();
      Main.LocalPlayerCreativeTracker.ItemSacrifices.SetSacrificeCountDirectly(ContentSamples.ItemPersistentIdsByNetIds[(int) key], (int) reader.ReadUInt16());
      return true;
    }
  }
}
