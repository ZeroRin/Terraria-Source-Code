// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.GameNotificationType
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
