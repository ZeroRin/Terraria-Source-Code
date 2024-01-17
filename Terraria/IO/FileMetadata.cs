// Decompiled with JetBrains decompiler
// Type: Terraria.IO.FileMetadata
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.IO;

namespace Terraria.IO
{
  public class FileMetadata
  {
    public const ulong MAGIC_NUMBER = 27981915666277746;
    public const int SIZE = 20;
    public FileType Type;
    public uint Revision;
    public bool IsFavorite;

    private FileMetadata()
    {
    }

    public void Write(BinaryWriter writer)
    {
      writer.Write((ulong) (27981915666277746L | (long) this.Type << 56));
      writer.Write(this.Revision);
      writer.Write((ulong) (this.IsFavorite.ToInt() & 1 | 0));
    }

    public void IncrementAndWrite(BinaryWriter writer)
    {
      ++this.Revision;
      this.Write(writer);
    }

    public static FileMetadata FromCurrentSettings(FileType type) => new FileMetadata()
    {
      Type = type,
      Revision = 0,
      IsFavorite = false
    };

    public static FileMetadata Read(BinaryReader reader, FileType expectedType)
    {
      FileMetadata fileMetadata = new FileMetadata();
      fileMetadata.Read(reader);
      if (fileMetadata.Type != expectedType)
        throw new FormatException("Expected type \"" + Enum.GetName(typeof (FileType), (object) expectedType) + "\" but found \"" + Enum.GetName(typeof (FileType), (object) fileMetadata.Type) + "\".");
      return fileMetadata;
    }

    private void Read(BinaryReader reader)
    {
      long num1 = (long) reader.ReadUInt64();
      if ((num1 & 72057594037927935L) != 27981915666277746L)
        throw new FormatException("Expected Re-Logic file format.");
      byte num2 = (byte) ((ulong) (num1 >>> 56) & (ulong) byte.MaxValue);
      FileType fileType = FileType.None;
      FileType[] values = (FileType[]) Enum.GetValues(typeof (FileType));
      for (int index = 0; index < values.Length; ++index)
      {
        if (values[index] == (FileType) num2)
        {
          fileType = values[index];
          break;
        }
      }
      this.Type = fileType != FileType.None ? fileType : throw new FormatException("Found invalid file type.");
      this.Revision = reader.ReadUInt32();
      this.IsFavorite = ((long) reader.ReadUInt64() & 1L) == 1L;
    }
  }
}
