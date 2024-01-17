// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.VirtualCamera
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.Graphics
{
  public struct VirtualCamera
  {
    public readonly Player Player;

    public VirtualCamera(Player player) => this.Player = player;

    public Vector2 Position => this.Center - this.Size * 0.5f;

    public Vector2 Size => new Vector2((float) Main.maxScreenW, (float) Main.maxScreenH);

    public Vector2 Center => this.Player.Center;
  }
}
