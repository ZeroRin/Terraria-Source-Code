// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.TileDrawInfo
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.DataStructures
{
  public class TileDrawInfo
  {
    public Tile tileCache;
    public ushort typeCache;
    public short tileFrameX;
    public short tileFrameY;
    public Texture2D drawTexture;
    public Color tileLight;
    public int tileTop;
    public int tileWidth;
    public int tileHeight;
    public int halfBrickHeight;
    public int addFrY;
    public int addFrX;
    public SpriteEffects tileSpriteEffect;
    public Texture2D glowTexture;
    public Rectangle glowSourceRect;
    public Color glowColor;
    public Vector3[] colorSlices = new Vector3[9];
    public Color finalColor;
    public Color colorTint;
  }
}
