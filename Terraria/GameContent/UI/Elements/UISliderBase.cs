// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UISliderBase
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
