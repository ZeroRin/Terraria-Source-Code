// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIItemIcon
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
