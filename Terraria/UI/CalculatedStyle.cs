// Decompiled with JetBrains decompiler
// Type: Terraria.UI.CalculatedStyle
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.UI
{
  public struct CalculatedStyle
  {
    public float X;
    public float Y;
    public float Width;
    public float Height;

    public CalculatedStyle(float x, float y, float width, float height)
    {
      this.X = x;
      this.Y = y;
      this.Width = width;
      this.Height = height;
    }

    public Rectangle ToRectangle() => new Rectangle((int) this.X, (int) this.Y, (int) this.Width, (int) this.Height);

    public Vector2 Position() => new Vector2(this.X, this.Y);

    public Vector2 Center() => new Vector2(this.X + this.Width * 0.5f, this.Y + this.Height * 0.5f);
  }
}
