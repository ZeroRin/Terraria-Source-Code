// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.NPCHeadDrawRenderTargetContent
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.GameContent
{
  public class NPCHeadDrawRenderTargetContent : AnOutlinedDrawRenderTargetContent
  {
    private Texture2D _theTexture;

    public void SetTexture(Texture2D texture)
    {
      if (this._theTexture == texture)
        return;
      this._theTexture = texture;
      this._wasPrepared = false;
      this.width = texture.Width + 8;
      this.height = texture.Height + 8;
    }

    internal override void DrawTheContent(SpriteBatch spriteBatch) => spriteBatch.Draw(this._theTexture, new Vector2(4f, 4f), new Rectangle?(), Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
  }
}
