﻿// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.AnchorData
// Assembly: Terraria, Version=1.4.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F541F3E5-89DE-4E5D-868F-1B56DAAB46B2
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.Enums;

namespace Terraria.DataStructures
{
  public struct AnchorData
  {
    public AnchorType type;
    public int tileCount;
    public int checkStart;
    public static AnchorData Empty;

    public AnchorData(AnchorType type, int count, int start)
    {
      this.type = type;
      this.tileCount = count;
      this.checkStart = start;
    }

    public static bool operator ==(AnchorData data1, AnchorData data2) => data1.type == data2.type && data1.tileCount == data2.tileCount && data1.checkStart == data2.checkStart;

    public static bool operator !=(AnchorData data1, AnchorData data2) => data1.type != data2.type || data1.tileCount != data2.tileCount || data1.checkStart != data2.checkStart;

    public override bool Equals(object obj) => obj is AnchorData anchorData && this.type == anchorData.type && this.tileCount == ((AnchorData) obj).tileCount && this.checkStart == ((AnchorData) obj).checkStart;

    public override int GetHashCode() => (int) (ushort) this.type << 16 | (int) (byte) this.tileCount << 8 | (int) (byte) this.checkStart;
  }
}
