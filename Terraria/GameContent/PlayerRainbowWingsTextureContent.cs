// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.PlayerRainbowWingsTextureContent
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
  public class PlayerRainbowWingsTextureContent : ARenderTargetContentByRequest
  {
    protected override void HandleUseReqest(GraphicsDevice device, SpriteBatch spriteBatch)
    {
      Asset<Texture2D> asset = TextureAssets.Extra[171];
      this.PrepareARenderTarget_AndListenToEvents(ref this._target, device, asset.Width(), asset.Height(), RenderTargetUsage.PreserveContents);
      device.SetRenderTarget(this._target);
      device.Clear(Color.Transparent);
      DrawData drawData = new DrawData(asset.Value, Vector2.Zero, Color.White);
      spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
      GameShaders.Misc["HallowBoss"].Apply(new DrawData?(drawData));
      drawData.Draw(spriteBatch);
      spriteBatch.End();
      device.SetRenderTarget((RenderTarget2D) null);
      this._wasPrepared = true;
    }
  }
}
