// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.LineSegment
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.DataStructures
{
  public struct LineSegment
  {
    public Vector2 Start;
    public Vector2 End;

    public LineSegment(Vector2 start, Vector2 end)
    {
      this.Start = start;
      this.End = end;
    }
  }
}
