// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIProgressBar
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIProgressBar : UIElement
  {
    private UIProgressBar.UIInnerProgressBar _progressBar = new UIProgressBar.UIInnerProgressBar();
    private float _visualProgress;
    private float _targetProgress;

    public UIProgressBar()
    {
      this._progressBar.Height.Precent = 1f;
      this._progressBar.Recalculate();
      this.Append((UIElement) this._progressBar);
    }

    public void SetProgress(float value)
    {
      this._targetProgress = value;
      if ((double) value >= (double) this._visualProgress)
        return;
      this._visualProgress = value;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      this._visualProgress = (float) ((double) this._visualProgress * 0.949999988079071 + 0.05000000074505806 * (double) this._targetProgress);
      this._progressBar.Width.Precent = this._visualProgress;
      this._progressBar.Recalculate();
    }

    private class UIInnerProgressBar : UIElement
    {
      protected override void DrawSelf(SpriteBatch spriteBatch)
      {
        CalculatedStyle dimensions = this.GetDimensions();
        spriteBatch.Draw(TextureAssets.MagicPixel.Value, new Vector2(dimensions.X, dimensions.Y), new Rectangle?(), Color.Blue, 0.0f, Vector2.Zero, new Vector2(dimensions.Width, dimensions.Height / 1000f), SpriteEffects.None, 0.0f);
      }
    }
  }
}
