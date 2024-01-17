// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.PlacementHook
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;

namespace Terraria.DataStructures
{
  public struct PlacementHook
  {
    public Func<int, int, int, int, int, int, int> hook;
    public int badReturn;
    public int badResponse;
    public bool processedCoordinates;
    public static PlacementHook Empty = new PlacementHook((Func<int, int, int, int, int, int, int>) null, 0, 0, false);
    public const int Response_AllInvalid = 0;

    public PlacementHook(
      Func<int, int, int, int, int, int, int> hook,
      int badReturn,
      int badResponse,
      bool processedCoordinates)
    {
      this.hook = hook;
      this.badResponse = badResponse;
      this.badReturn = badReturn;
      this.processedCoordinates = processedCoordinates;
    }

    public static bool operator ==(PlacementHook first, PlacementHook second) => first.hook == second.hook && first.badResponse == second.badResponse && first.badReturn == second.badReturn && first.processedCoordinates == second.processedCoordinates;

    public static bool operator !=(PlacementHook first, PlacementHook second) => first.hook != second.hook || first.badResponse != second.badResponse || first.badReturn != second.badReturn || first.processedCoordinates != second.processedCoordinates;

    public override bool Equals(object obj) => obj is PlacementHook placementHook && this == placementHook;

    public override int GetHashCode() => base.GetHashCode();
  }
}
