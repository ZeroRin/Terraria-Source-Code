// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.ProjectileSource_Buff
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.DataStructures
{
  public class ProjectileSource_Buff : IProjectileSource
  {
    public readonly Player Player;
    public readonly int BuffId;
    public readonly int BuffIndex;

    public ProjectileSource_Buff(Player player, int buffId, int buffIndex)
    {
      this.Player = player;
      this.BuffId = buffId;
      this.BuffIndex = buffIndex;
    }
  }
}
