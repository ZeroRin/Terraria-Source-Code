// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Drawing.ParticleOrchestraSettings
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System.IO;

namespace Terraria.GameContent.Drawing
{
  public struct ParticleOrchestraSettings
  {
    public Vector2 PositionInWorld;
    public Vector2 MovementVector;
    public int PackedShaderIndex;
    public byte IndexOfPlayerWhoInvokedThis;
    public const int SerializationSize = 21;

    public void Serialize(BinaryWriter writer)
    {
      writer.WriteVector2(this.PositionInWorld);
      writer.WriteVector2(this.MovementVector);
      writer.Write(this.PackedShaderIndex);
      writer.Write(this.IndexOfPlayerWhoInvokedThis);
    }

    public void DeserializeFrom(BinaryReader reader)
    {
      this.PositionInWorld = reader.ReadVector2();
      this.MovementVector = reader.ReadVector2();
      this.PackedShaderIndex = reader.ReadInt32();
      this.IndexOfPlayerWhoInvokedThis = reader.ReadByte();
    }
  }
}
