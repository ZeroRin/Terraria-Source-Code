﻿// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.EntitySource_ByProjectileSourceId
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.DataStructures
{
  public class EntitySource_ByProjectileSourceId : IEntitySource
  {
    public readonly int SourceId;

    public EntitySource_ByProjectileSourceId(int projectileSourceId) => this.SourceId = projectileSourceId;
  }
}
