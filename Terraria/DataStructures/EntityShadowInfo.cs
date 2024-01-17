// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.EntityShadowInfo
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.DataStructures
{
  public struct EntityShadowInfo
  {
    public Vector2 Position;
    public float Rotation;
    public Vector2 Origin;
    public int Direction;
    public int GravityDirection;
    public int BodyFrameIndex;

    public void CopyPlayer(Player player)
    {
      this.Position = player.position;
      this.Rotation = player.fullRotation;
      this.Origin = player.fullRotationOrigin;
      this.Direction = player.direction;
      this.GravityDirection = (int) player.gravDir;
      this.BodyFrameIndex = player.bodyFrame.Y / player.bodyFrame.Height;
    }

    public Vector2 HeadgearOffset => Main.OffsetsPlayerHeadgear[this.BodyFrameIndex];
  }
}
