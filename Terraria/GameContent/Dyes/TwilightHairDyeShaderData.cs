// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Dyes.TwilightHairDyeShaderData
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent.Dyes
{
  public class TwilightHairDyeShaderData : HairShaderData
  {
    public TwilightHairDyeShaderData(Ref<Effect> shader, string passName)
      : base(shader, passName)
    {
    }

    public override void Apply(Player player, DrawData? drawData = null)
    {
      if (drawData.HasValue)
        this.UseTargetPosition(Main.screenPosition + drawData.Value.position);
      base.Apply(player, drawData);
    }
  }
}
