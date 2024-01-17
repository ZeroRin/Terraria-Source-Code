// Decompiled with JetBrains decompiler
// Type: Terraria.Physics.BallStepResult
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Physics
{
  public struct BallStepResult
  {
    public readonly BallState State;

    private BallStepResult(BallState state) => this.State = state;

    public static BallStepResult OutOfBounds() => new BallStepResult(BallState.OutOfBounds);

    public static BallStepResult Moving() => new BallStepResult(BallState.Moving);

    public static BallStepResult Resting() => new BallStepResult(BallState.Resting);
  }
}
