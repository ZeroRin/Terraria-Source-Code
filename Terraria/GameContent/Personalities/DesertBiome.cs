﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Personalities.DesertBiome
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.GameContent.Personalities
{
  public class DesertBiome : AShoppingBiome
  {
    public DesertBiome() => this.NameKey = "Desert";

    public override bool IsInBiome(Player player) => player.ZoneDesert;
  }
}
