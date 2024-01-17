// Decompiled with JetBrains decompiler
// Type: Terraria.UI.UIScrollWheelEvent
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.UI
{
  public class UIScrollWheelEvent : UIMouseEvent
  {
    public readonly int ScrollWheelValue;

    public UIScrollWheelEvent(UIElement target, Vector2 mousePosition, int scrollWheelValue)
      : base(target, mousePosition)
    {
      this.ScrollWheelValue = scrollWheelValue;
    }
  }
}
