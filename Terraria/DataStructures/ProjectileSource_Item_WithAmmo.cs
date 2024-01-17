﻿// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.ProjectileSource_Item_WithAmmo
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.DataStructures
{
  public class ProjectileSource_Item_WithAmmo : ProjectileSource_Item
  {
    public readonly int AmmoItemIdUsed;

    public ProjectileSource_Item_WithAmmo(Player player, Item item, int ammoItemIdUsed)
      : base(player, item)
    {
      this.AmmoItemIdUsed = ammoItemIdUsed;
    }
  }
}