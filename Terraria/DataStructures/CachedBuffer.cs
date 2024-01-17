// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.CachedBuffer
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.IO;

namespace Terraria.DataStructures
{
  public class CachedBuffer
  {
    public readonly byte[] Data;
    public readonly BinaryWriter Writer;
    public readonly BinaryReader Reader;
    private readonly MemoryStream _memoryStream;
    private bool _isActive = true;

    public int Length => this.Data.Length;

    public bool IsActive => this._isActive;

    public CachedBuffer(byte[] data)
    {
      this.Data = data;
      this._memoryStream = new MemoryStream(data);
      this.Writer = new BinaryWriter((Stream) this._memoryStream);
      this.Reader = new BinaryReader((Stream) this._memoryStream);
    }

    internal CachedBuffer Activate()
    {
      this._isActive = true;
      this._memoryStream.Position = 0L;
      return this;
    }

    public void Recycle()
    {
      if (!this._isActive)
        return;
      this._isActive = false;
      BufferPool.Recycle(this);
    }
  }
}
