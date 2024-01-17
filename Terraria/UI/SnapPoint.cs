// Decompiled with JetBrains decompiler
// Type: Terraria.UI.SnapPoint
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Terraria.UI
{
  [DebuggerDisplay("Snap Point - {Name} {Id}")]
  public class SnapPoint
  {
    public string Name;
    private Vector2 _anchor;
    private Vector2 _offset;

    public int Id { get; private set; }

    public Vector2 Position { get; private set; }

    public SnapPoint(string name, int id, Vector2 anchor, Vector2 offset)
    {
      this.Name = name;
      this.Id = id;
      this._anchor = anchor;
      this._offset = offset;
    }

    public void Calculate(UIElement element)
    {
      CalculatedStyle dimensions = element.GetDimensions();
      this.Position = dimensions.Position() + this._offset + this._anchor * new Vector2(dimensions.Width, dimensions.Height);
    }

    public void ThisIsAHackThatChangesTheSnapPointsInfo(Vector2 anchor, Vector2 offset, int id)
    {
      this._anchor = anchor;
      this._offset = offset;
      this.Id = id;
    }
  }
}
