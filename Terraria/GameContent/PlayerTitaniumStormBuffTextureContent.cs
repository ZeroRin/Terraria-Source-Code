// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.PlayerTitaniumStormBuffTextureContent
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;

namespace Terraria.GameContent
{
  public class PlayerTitaniumStormBuffTextureContent : ARenderTargetContentByRequest
  {
    private MiscShaderData _shaderData;

    public PlayerTitaniumStormBuffTextureContent()
    {
      this._shaderData = new MiscShaderData(Main.PixelShaderRef, "TitaniumStorm");
      this._shaderData.UseImage1("Images/Extra_" + (short) 156.ToString());
    }

    protected override void HandleUseReqest(GraphicsDevice device, SpriteBatch spriteBatch)
    {
      Main.instance.LoadProjectile(908);
      Asset<Texture2D> asset = TextureAssets.Projectile[908];
      this.UpdateSettingsForRendering(0.6f, 0.0f, Main.GlobalTimeWrappedHourly, 0.3f);
      this.PrepareARenderTarget_AndListenToEvents(ref this._target, device, asset.Width(), asset.Height(), RenderTargetUsage.PreserveContents);
      device.SetRenderTarget(this._target);
      device.Clear(Color.Transparent);
      DrawData drawData = new DrawData(asset.Value, Vector2.Zero, Color.White);
      spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
      this._shaderData.Apply(new DrawData?(drawData));
      drawData.Draw(spriteBatch);
      spriteBatch.End();
      device.SetRenderTarget((RenderTarget2D) null);
      this._wasPrepared = true;
    }

    public void UpdateSettingsForRendering(
      float gradientContributionFromOriginalTexture,
      float gradientScrollingSpeed,
      float flatGradientOffset,
      float gradientColorDominance)
    {
      this._shaderData.UseColor(gradientScrollingSpeed, gradientContributionFromOriginalTexture, gradientColorDominance);
      this._shaderData.UseOpacity(flatGradientOffset);
    }
  }
}
