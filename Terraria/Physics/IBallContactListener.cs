﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Physics.IBallContactListener
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.Physics
{
  public interface IBallContactListener
  {
    void OnCollision(
      PhysicsProperties properties,
      ref Vector2 position,
      ref Vector2 velocity,
      ref BallCollisionEvent collision);

    void OnPassThrough(
      PhysicsProperties properties,
      ref Vector2 position,
      ref Vector2 velocity,
      ref float angularVelocity,
      ref BallPassThroughEvent passThrough);
  }
}
