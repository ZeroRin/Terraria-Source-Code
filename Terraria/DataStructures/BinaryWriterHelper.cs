// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.BinaryWriterHelper
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.IO;

namespace Terraria.DataStructures
{
  public struct BinaryWriterHelper
  {
    private long _placeInWriter;

    public void ReservePointToFillLengthLaterByFilling6Bytes(BinaryWriter writer)
    {
      this._placeInWriter = writer.BaseStream.Position;
      writer.Write(0U);
      writer.Write((ushort) 0);
    }

    public void FillReservedPoint(BinaryWriter writer, ushort dataId)
    {
      long position = writer.BaseStream.Position;
      writer.BaseStream.Position = this._placeInWriter;
      long num = position - this._placeInWriter - 4L;
      writer.Write((int) num);
      writer.Write(dataId);
      writer.BaseStream.Position = position;
    }

    public void FillOnlyIfThereIsLengthOrRevertToSavedPosition(
      BinaryWriter writer,
      ushort dataId,
      out bool wroteSomething)
    {
      wroteSomething = false;
      long position = writer.BaseStream.Position;
      writer.BaseStream.Position = this._placeInWriter;
      long num = position - this._placeInWriter - 4L;
      if (num == 0L)
        return;
      writer.Write((int) num);
      writer.Write(dataId);
      writer.BaseStream.Position = position;
      wroteSomething = true;
    }
  }
}
