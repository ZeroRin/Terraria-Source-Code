// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Dyes.TeamArmorShaderData
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Dyes
{
  public class TeamArmorShaderData : ArmorShaderData
  {
    private static bool isInitialized;
    private static ArmorShaderData[] dustShaderData;

    public TeamArmorShaderData(Ref<Effect> shader, string passName)
      : base(shader, passName)
    {
      if (TeamArmorShaderData.isInitialized)
        return;
      TeamArmorShaderData.isInitialized = true;
      TeamArmorShaderData.dustShaderData = new ArmorShaderData[Main.teamColor.Length];
      for (int index = 1; index < Main.teamColor.Length; ++index)
        TeamArmorShaderData.dustShaderData[index] = new ArmorShaderData(shader, passName).UseColor(Main.teamColor[index]);
      TeamArmorShaderData.dustShaderData[0] = new ArmorShaderData(shader, "Default");
    }

    public override void Apply(Entity entity, DrawData? drawData)
    {
      if (!(entity is Player player) || player.team == 0)
      {
        TeamArmorShaderData.dustShaderData[0].Apply((Entity) player, drawData);
      }
      else
      {
        this.UseColor(Main.teamColor[player.team]);
        base.Apply((Entity) player, drawData);
      }
    }

    public override ArmorShaderData GetSecondaryShader(Entity entity)
    {
      Player player = entity as Player;
      return TeamArmorShaderData.dustShaderData[player.team];
    }
  }
}
