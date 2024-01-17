// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.NPCDebuffImmunityData
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
