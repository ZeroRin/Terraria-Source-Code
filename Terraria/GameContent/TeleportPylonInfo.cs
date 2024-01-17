// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.TeleportPylonInfo
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using Terraria.DataStructures;

namespace Terraria.GameContent
{
  public struct TeleportPylonInfo : IEquatable<TeleportPylonInfo>
  {
    public Point16 PositionInTiles;
    public TeleportPylonType TypeOfPylon;

    public bool Equals(TeleportPylonInfo other) => this.PositionInTiles == other.PositionInTiles && this.TypeOfPylon == other.TypeOfPylon;
  }
}
