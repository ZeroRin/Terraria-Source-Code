// Decompiled with JetBrains decompiler
// Type: Terraria.UI.UIScrollWheelEvent
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
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
