﻿// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.SpriteFrame
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.DataStructures
{
  public struct SpriteFrame
  {
    public int PaddingX;
    public int PaddingY;
    private byte _currentColumn;
    private byte _currentRow;
    public readonly byte ColumnCount;
    public readonly byte RowCount;

    public byte CurrentColumn
    {
      get => this._currentColumn;
      set => this._currentColumn = value;
    }

    public byte CurrentRow
    {
      get => this._currentRow;
      set => this._currentRow = value;
    }

    public SpriteFrame(byte columns, byte rows)
    {
      this.PaddingX = 2;
      this.PaddingY = 2;
      this._currentColumn = (byte) 0;
      this._currentRow = (byte) 0;
      this.ColumnCount = columns;
      this.RowCount = rows;
    }

    public SpriteFrame(byte columns, byte rows, byte currentColumn, byte currentRow)
    {
      this.PaddingX = 2;
      this.PaddingY = 2;
      this._currentColumn = currentColumn;
      this._currentRow = currentRow;
      this.ColumnCount = columns;
      this.RowCount = rows;
    }

    public SpriteFrame With(byte columnToUse, byte rowToUse) => this with
    {
      CurrentColumn = columnToUse,
      CurrentRow = rowToUse
    };

    public Rectangle GetSourceRectangle(Texture2D texture)
    {
      int num1 = texture.Width / (int) this.ColumnCount;
      int num2 = texture.Height / (int) this.RowCount;
      return new Rectangle((int) this.CurrentColumn * num1, (int) this.CurrentRow * num2, num1 - (this.ColumnCount == (byte) 1 ? 0 : this.PaddingX), num2 - (this.RowCount == (byte) 1 ? 0 : this.PaddingY));
    }
  }
}
