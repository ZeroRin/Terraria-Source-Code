// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.SpawnConditionDecorativeOverlayInfoElement
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class SpawnConditionDecorativeOverlayInfoElement : 
    IBestiaryInfoElement,
    IBestiaryBackgroundOverlayAndColorProvider
  {
    private string _overlayImagePath;
    private Color? _overlayColor;

    public float DisplayPriority { get; set; }

    public SpawnConditionDecorativeOverlayInfoElement(string overlayImagePath = null, Color? overlayColor = null)
    {
      this._overlayImagePath = overlayImagePath;
      this._overlayColor = overlayColor;
    }

    public Asset<Texture2D> GetBackgroundOverlayImage() => this._overlayImagePath == null ? (Asset<Texture2D>) null : Main.Assets.Request<Texture2D>(this._overlayImagePath, (AssetRequestMode) 1);

    public Color? GetBackgroundOverlayColor() => this._overlayColor;

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => (UIElement) null;
  }
}
