// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIItemSlot
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIItemSlot : UIElement
  {
    private Item[] _itemArray;
    private int _itemIndex;
    private int _itemSlotContext;

    public UIItemSlot(Item[] itemArray, int itemIndex, int itemSlotContext)
    {
      this._itemArray = itemArray;
      this._itemIndex = itemIndex;
      this._itemSlotContext = itemSlotContext;
      this.Width = new StyleDimension(48f, 0.0f);
      this.Height = new StyleDimension(48f, 0.0f);
    }

    private void HandleItemSlotLogic()
    {
      if (!this.IsMouseHovering)
        return;
      Main.LocalPlayer.mouseInterface = true;
      Item inv = this._itemArray[this._itemIndex];
      ItemSlot.OverrideHover(ref inv, this._itemSlotContext);
      ItemSlot.LeftClick(ref inv, this._itemSlotContext);
      ItemSlot.RightClick(ref inv, this._itemSlotContext);
      ItemSlot.MouseHover(ref inv, this._itemSlotContext);
      this._itemArray[this._itemIndex] = inv;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
      this.HandleItemSlotLogic();
      Item inv = this._itemArray[this._itemIndex];
      Vector2 position = this.GetDimensions().Center() + new Vector2(52f, 52f) * -0.5f * Main.inventoryScale;
      ItemSlot.Draw(spriteBatch, ref inv, this._itemSlotContext, position);
    }
  }
}
