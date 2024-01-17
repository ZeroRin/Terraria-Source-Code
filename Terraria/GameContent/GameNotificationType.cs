// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.GameNotificationType
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;

namespace Terraria.GameContent
{
  [Flags]
  public enum GameNotificationType
  {
    None = 0,
    Damage = 1,
    SpawnOrDeath = 2,
    WorldGen = 4,
    All = WorldGen | SpawnOrDeath | Damage, // 0x00000007
  }
}
