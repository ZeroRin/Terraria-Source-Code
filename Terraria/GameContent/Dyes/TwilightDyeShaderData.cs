// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Dyes.TwilightDyeShaderData
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Dyes
{
  public class TwilightDyeShaderData : ArmorShaderData
  {
    public TwilightDyeShaderData(Ref<Effect> shader, string passName)
      : base(shader, passName)
    {
    }

    public override void Apply(Entity entity, DrawData? drawData)
    {
      if (drawData.HasValue)
      {
        switch (entity)
        {
          case Player player when !player.isDisplayDollOrInanimate && !player.isHatRackDoll:
            this.UseTargetPosition(Main.screenPosition + drawData.Value.position);
            break;
          case Projectile _:
            this.UseTargetPosition(Main.screenPosition + drawData.Value.position);
            break;
          default:
            this.UseTargetPosition(drawData.Value.position);
            break;
        }
      }
      base.Apply(entity, drawData);
    }
  }
}
