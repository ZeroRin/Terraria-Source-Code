// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Personalities.HelperInfo
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.GameContent.Personalities
{
  public struct HelperInfo
  {
    public Player player;
    public NPC npc;
    public List<NPC> NearbyNPCs;
    public int PrimaryPlayerBiome;
    public bool[] nearbyNPCsByType;
  }
}
