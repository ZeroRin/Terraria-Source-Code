// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Golf.GolfBallTrackRecord
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
