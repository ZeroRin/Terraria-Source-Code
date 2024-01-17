// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ContentRejectionFromSize
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
