// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UISliderBase
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UISliderBase : UIElement
  {
    internal const int UsageLevel_NotSelected = 0;
    internal const int UsageLevel_SelectedAndLocked = 1;
    internal const int UsageLevel_OtherElementIsLocked = 2;
    internal static UIElement CurrentLockedSlider;
    internal static UIElement CurrentAimedSlider;

    internal int GetUsageLevel()
    {
      int usageLevel = 0;
      if (UISliderBase.CurrentLockedSlider == this)
        usageLevel = 1;
      else if (UISliderBase.CurrentLockedSlider != null)
        usageLevel = 2;
      return usageLevel;
    }

    public static void EscapeElements()
    {
      UISliderBase.CurrentLockedSlider = (UIElement) null;
      UISliderBase.CurrentAimedSlider = (UIElement) null;
    }
  }
}
