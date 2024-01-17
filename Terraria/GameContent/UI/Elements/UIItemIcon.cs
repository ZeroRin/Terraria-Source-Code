// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIItemIcon
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIItemIcon : UIElement
  {
    private Item _item;
    private bool _blackedOut;

    public UIItemIcon(Item item, bool blackedOut)
    {
      this._item = item;
      this.Width.Set(32f, 0.0f);
      this.Height.Set(32f, 0.0f);
      this._blackedOut = blackedOut;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      CalculatedStyle dimensions = this.GetDimensions();
      Main.DrawItemIcon(spriteBatch, this._item, dimensions.Center(), this._blackedOut ? Color.Black : Color.White, 32f);
    }
  }
}
