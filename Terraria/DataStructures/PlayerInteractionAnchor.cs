﻿// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.PlayerInteractionAnchor
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.DataStructures
{
  public struct PlayerInteractionAnchor
  {
    public int interactEntityID;
    public int X;
    public int Y;

    public PlayerInteractionAnchor(int entityID, int x = -1, int y = -1)
    {
      this.interactEntityID = entityID;
      this.X = x;
      this.Y = y;
    }

    public bool InUse => this.interactEntityID != -1;

    public void Clear()
    {
      this.interactEntityID = -1;
      this.X = -1;
      this.Y = -1;
    }

    public void Set(int entityID, int x, int y)
    {
      this.interactEntityID = entityID;
      this.X = x;
      this.Y = y;
    }

    public bool IsInValidUseTileEntity() => this.InUse && TileEntity.ByID.ContainsKey(this.interactEntityID);

    public TileEntity GetTileEntity() => !this.IsInValidUseTileEntity() ? (TileEntity) null : TileEntity.ByID[this.interactEntityID];
  }
}
