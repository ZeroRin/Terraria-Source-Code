// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ContentRejectionFromSize
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using ReLogic.Content;
using Terraria.Localization;

namespace Terraria.GameContent
{
  public class ContentRejectionFromSize : IRejectionReason
  {
    private int _neededWidth;
    private int _neededHeight;
    private int _actualWidth;
    private int _actualHeight;

    public ContentRejectionFromSize(
      int neededWidth,
      int neededHeight,
      int actualWidth,
      int actualHeight)
    {
      this._neededWidth = neededWidth;
      this._neededHeight = neededHeight;
      this._actualWidth = actualWidth;
      this._actualHeight = actualHeight;
    }

    public string GetReason() => Language.GetTextValueWith("AssetRejections.BadSize", (object) new
    {
      NeededWidth = this._neededWidth,
      NeededHeight = this._neededHeight,
      ActualWidth = this._actualWidth,
      ActualHeight = this._actualHeight
    });
  }
}
