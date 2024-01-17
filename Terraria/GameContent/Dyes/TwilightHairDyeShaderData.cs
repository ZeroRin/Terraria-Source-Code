// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Dyes.TwilightHairDyeShaderData
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
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
