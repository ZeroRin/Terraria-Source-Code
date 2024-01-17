﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ChumBucketProjectileHelper
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Terraria.GameContent
{
  public class ChumBucketProjectileHelper
  {
    private Dictionary<Point, int> _chumCountsPendingForThisFrame = new Dictionary<Point, int>();
    private Dictionary<Point, int> _chumCountsFromLastFrame = new Dictionary<Point, int>();

    public void OnPreUpdateAllProjectiles()
    {
      Utils.Swap<Dictionary<Point, int>>(ref this._chumCountsPendingForThisFrame, ref this._chumCountsFromLastFrame);
      this._chumCountsPendingForThisFrame.Clear();
    }

    public void AddChumLocation(Vector2 spot)
    {
      Point tileCoordinates = spot.ToTileCoordinates();
      int num1 = 0;
      this._chumCountsPendingForThisFrame.TryGetValue(tileCoordinates, out num1);
      int num2 = num1 + 1;
      this._chumCountsPendingForThisFrame[tileCoordinates] = num2;
    }

    public int GetChumsInLocation(Point tileCoords)
    {
      int chumsInLocation = 0;
      this._chumCountsFromLastFrame.TryGetValue(tileCoords, out chumsInLocation);
      return chumsInLocation;
    }
  }
}
