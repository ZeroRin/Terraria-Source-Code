﻿// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.EntitySource_ItemOpen
// Assembly: Terraria, Version=1.4.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F541F3E5-89DE-4E5D-868F-1B56DAAB46B2
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.DataStructures
{
  public class EntitySource_ItemOpen : IEntitySource
  {
    public readonly Entity Entity;
    public readonly int ItemType;

    public EntitySource_ItemOpen(Entity entity, int itemType)
    {
      this.Entity = entity;
      this.ItemType = itemType;
    }
  }
}