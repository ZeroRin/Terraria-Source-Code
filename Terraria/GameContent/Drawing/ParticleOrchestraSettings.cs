// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Drawing.ParticleOrchestraSettings
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
