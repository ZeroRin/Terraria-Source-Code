// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Golf.GolfBallTrackRecord
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Terraria.GameContent.Golf
{
  public class GolfBallTrackRecord
  {
    private List<Vector2> _hitLocations = new List<Vector2>();

    public void RecordHit(Vector2 position) => this._hitLocations.Add(position);

    public int GetAccumulatedScore()
    {
      double totalDistancePassed;
      int hitsMade;
      this.GetTrackInfo(out totalDistancePassed, out hitsMade);
      return (int) (totalDistancePassed / 16.0) / (hitsMade + 2);
    }

    private void GetTrackInfo(out double totalDistancePassed, out int hitsMade)
    {
      hitsMade = 0;
      totalDistancePassed = 0.0;
      int index = 0;
      while (index < this._hitLocations.Count - 1)
      {
        totalDistancePassed += (double) Vector2.Distance(this._hitLocations[index], this._hitLocations[index + 1]);
        ++index;
        ++hitsMade;
      }
    }
  }
}
