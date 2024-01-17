// Decompiled with JetBrains decompiler
// Type: Terraria.Physics.PhysicsProperties
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Physics
{
  public class PhysicsProperties
  {
    public readonly float Gravity;
    public readonly float Drag;

    public PhysicsProperties(float gravity, float drag)
    {
      this.Gravity = gravity;
      this.Drag = drag;
    }
  }
}
