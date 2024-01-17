// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.NPCDebuffImmunityData
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.ID;

namespace Terraria.DataStructures
{
  public class NPCDebuffImmunityData
  {
    public bool ImmuneToWhips;
    public bool ImmuneToAllBuffsThatAreNotWhips;
    public int[] SpecificallyImmuneTo;

    public void ApplyToNPC(NPC npc)
    {
      if (this.ImmuneToWhips || this.ImmuneToAllBuffsThatAreNotWhips)
      {
        for (int index = 1; index < 327; ++index)
        {
          bool flag1 = BuffID.Sets.IsAnNPCWhipDebuff[index];
          bool flag2 = ((((false ? 1 : 0) | (!flag1 ? 0 : (this.ImmuneToWhips ? 1 : 0))) != 0 ? 1 : 0) | (flag1 ? 0 : (this.ImmuneToAllBuffsThatAreNotWhips ? 1 : 0))) != 0;
          npc.buffImmune[index] = flag2;
        }
      }
      if (this.SpecificallyImmuneTo == null)
        return;
      for (int index1 = 0; index1 < this.SpecificallyImmuneTo.Length; ++index1)
      {
        int index2 = this.SpecificallyImmuneTo[index1];
        npc.buffImmune[index2] = true;
      }
    }
  }
}
