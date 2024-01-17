// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.States.UIGamepadHelper
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Terraria.GameInput;
using Terraria.UI;
using Terraria.UI.Gamepad;

namespace Terraria.GameContent.UI.States
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct UIGamepadHelper
  {
    public UILinkPoint[,] CreateUILinkPointGrid(
      ref int currentID,
      List<SnapPoint> pointsForGrid,
      int pointsPerLine,
      UILinkPoint topLinkPoint,
      UILinkPoint leftLinkPoint)
    {
      int length = (int) Math.Ceiling((double) pointsForGrid.Count / (double) pointsPerLine);
      UILinkPoint[,] uiLinkPointGrid = new UILinkPoint[pointsPerLine, length];
      for (int index1 = 0; index1 < pointsForGrid.Count; ++index1)
      {
        int index2 = index1 % pointsPerLine;
        int index3 = index1 / pointsPerLine;
        uiLinkPointGrid[index2, index3] = this.MakeLinkPointFromSnapPoint(currentID++, pointsForGrid[index1]);
      }
      for (int index4 = 0; index4 < uiLinkPointGrid.GetLength(0); ++index4)
      {
        for (int index5 = 0; index5 < uiLinkPointGrid.GetLength(1); ++index5)
        {
          UILinkPoint uiLinkPoint = uiLinkPointGrid[index4, index5];
          if (uiLinkPoint != null)
          {
            if (index4 < uiLinkPointGrid.GetLength(0) - 1)
            {
              UILinkPoint rightSide = uiLinkPointGrid[index4 + 1, index5];
              if (rightSide != null)
                this.PairLeftRight(uiLinkPoint, rightSide);
            }
            if (index5 < uiLinkPointGrid.GetLength(1) - 1)
            {
              UILinkPoint downSide = uiLinkPointGrid[index4, index5 + 1];
              if (downSide != null)
                this.PairUpDown(uiLinkPoint, downSide);
            }
            if (index4 == 0)
              uiLinkPoint.Left = leftLinkPoint.ID;
            if (index5 == 0)
              uiLinkPoint.Up = topLinkPoint.ID;
          }
        }
      }
      return uiLinkPointGrid;
    }

    public void LinkVerticalStrips(
      UILinkPoint[] stripOnLeft,
      UILinkPoint[] stripOnRight,
      int leftStripStartOffset)
    {
      if (stripOnLeft == null || stripOnRight == null)
        return;
      int num1 = Math.Max(stripOnLeft.Length, stripOnRight.Length);
      int num2 = Math.Min(stripOnLeft.Length, stripOnRight.Length);
      for (int index = 0; index < leftStripStartOffset; ++index)
        this.PairLeftRight(stripOnLeft[index], stripOnRight[0]);
      for (int index = 0; index < num2; ++index)
        this.PairLeftRight(stripOnLeft[index + leftStripStartOffset], stripOnRight[index]);
      for (int index = num2; index < num1; ++index)
      {
        if (stripOnLeft.Length > index)
          stripOnLeft[index].Right = stripOnRight[stripOnRight.Length - 1].ID;
        if (stripOnRight.Length > index)
          stripOnRight[index].Left = stripOnLeft[stripOnLeft.Length - 1].ID;
      }
    }

    public void LinkVerticalStripRightSideToSingle(UILinkPoint[] strip, UILinkPoint theSingle)
    {
      if (strip == null || theSingle == null)
        return;
      int num1 = Math.Max(strip.Length, 1);
      int num2 = Math.Min(strip.Length, 1);
      for (int index = 0; index < num2; ++index)
        this.PairLeftRight(strip[index], theSingle);
      for (int index = num2; index < num1; ++index)
      {
        if (strip.Length > index)
          strip[index].Right = theSingle.ID;
      }
    }

    public void LinkVerticalStripBottomSideToSingle(UILinkPoint[] strip, UILinkPoint theSingle)
    {
      if (strip == null || theSingle == null)
        return;
      this.PairUpDown(strip[strip.Length - 1], theSingle);
    }

    public UILinkPoint[] CreateUILinkStripVertical(ref int currentID, List<SnapPoint> currentStrip)
    {
      UILinkPoint[] linkStripVertical = new UILinkPoint[currentStrip.Count];
      for (int index = 0; index < currentStrip.Count; ++index)
        linkStripVertical[index] = this.MakeLinkPointFromSnapPoint(currentID++, currentStrip[index]);
      for (int index = 0; index < currentStrip.Count - 1; ++index)
        this.PairUpDown(linkStripVertical[index], linkStripVertical[index + 1]);
      return linkStripVertical;
    }

    public UILinkPoint[] CreateUILinkStripHorizontal(
      ref int currentID,
      List<SnapPoint> currentStrip)
    {
      UILinkPoint[] linkStripHorizontal = new UILinkPoint[currentStrip.Count];
      for (int index = 0; index < currentStrip.Count; ++index)
        linkStripHorizontal[index] = this.MakeLinkPointFromSnapPoint(currentID++, currentStrip[index]);
      for (int index = 0; index < currentStrip.Count - 1; ++index)
        this.PairLeftRight(linkStripHorizontal[index], linkStripHorizontal[index + 1]);
      return linkStripHorizontal;
    }

    public void TryMovingBackIntoCreativeGridIfOutOfIt(int start, int currentID)
    {
      List<UILinkPoint> lostrefpoints = new List<UILinkPoint>();
      for (int key = start; key < currentID; ++key)
        lostrefpoints.Add(UILinkPointNavigator.Points[key]);
      if (!PlayerInput.UsingGamepadUI || UILinkPointNavigator.CurrentPoint < currentID)
        return;
      this.MoveToVisuallyClosestPoint(lostrefpoints);
    }

    public void MoveToVisuallyClosestPoint(List<UILinkPoint> lostrefpoints)
    {
      Dictionary<int, UILinkPoint> points = UILinkPointNavigator.Points;
      Vector2 mouseScreen = Main.MouseScreen;
      UILinkPoint uiLinkPoint = (UILinkPoint) null;
      foreach (UILinkPoint lostrefpoint in lostrefpoints)
      {
        if (uiLinkPoint == null || (double) Vector2.Distance(mouseScreen, uiLinkPoint.Position) > (double) Vector2.Distance(mouseScreen, lostrefpoint.Position))
          uiLinkPoint = lostrefpoint;
      }
      if (uiLinkPoint == null)
        return;
      UILinkPointNavigator.ChangePoint(uiLinkPoint.ID);
    }

    public List<SnapPoint> GetOrderedPointsByCategoryName(List<SnapPoint> pts, string name) => pts.Where<SnapPoint>((Func<SnapPoint, bool>) (x => x.Name == name)).OrderBy<SnapPoint, int>((Func<SnapPoint, int>) (x => x.Id)).ToList<SnapPoint>();

    public void PairLeftRight(UILinkPoint leftSide, UILinkPoint rightSide)
    {
      leftSide.Right = rightSide.ID;
      rightSide.Left = leftSide.ID;
    }

    public void PairUpDown(UILinkPoint upSide, UILinkPoint downSide)
    {
      upSide.Down = downSide.ID;
      downSide.Up = upSide.ID;
    }

    public UILinkPoint MakeLinkPointFromSnapPoint(int id, SnapPoint snap)
    {
      UILinkPointNavigator.SetPosition(id, snap.Position);
      UILinkPoint point = UILinkPointNavigator.Points[id];
      point.Unlink();
      return point;
    }

    public UILinkPoint[] GetVerticalStripFromCategoryName(
      ref int currentID,
      List<SnapPoint> pts,
      string categoryName)
    {
      List<SnapPoint> pointsByCategoryName = this.GetOrderedPointsByCategoryName(pts, categoryName);
      UILinkPoint[] fromCategoryName = (UILinkPoint[]) null;
      if (pointsByCategoryName.Count > 0)
        fromCategoryName = this.CreateUILinkStripVertical(ref currentID, pointsByCategoryName);
      return fromCategoryName;
    }

    public void MoveToVisuallyClosestPoint(int idRangeStartInclusive, int idRangeEndExclusive)
    {
      if (UILinkPointNavigator.CurrentPoint >= idRangeStartInclusive && UILinkPointNavigator.CurrentPoint < idRangeEndExclusive)
        return;
      Dictionary<int, UILinkPoint> points = UILinkPointNavigator.Points;
      Vector2 mouseScreen = Main.MouseScreen;
      UILinkPoint uiLinkPoint1 = (UILinkPoint) null;
      for (int key = idRangeStartInclusive; key < idRangeEndExclusive; ++key)
      {
        UILinkPoint uiLinkPoint2;
        if (!points.TryGetValue(key, out uiLinkPoint2))
          return;
        if (uiLinkPoint1 == null || (double) Vector2.Distance(mouseScreen, uiLinkPoint1.Position) > (double) Vector2.Distance(mouseScreen, uiLinkPoint2.Position))
          uiLinkPoint1 = uiLinkPoint2;
      }
      if (uiLinkPoint1 == null)
        return;
      UILinkPointNavigator.ChangePoint(uiLinkPoint1.ID);
    }

    public void CullPointsOutOfElementArea(
      SpriteBatch spriteBatch,
      List<SnapPoint> pointsAtMiddle,
      UIElement container)
    {
      float num = 1f / Main.UIScale;
      Rectangle clippingRectangle = container.GetClippingRectangle(spriteBatch);
      Vector2 minimum = clippingRectangle.TopLeft() * num;
      Vector2 maximum = clippingRectangle.BottomRight() * num;
      for (int index = 0; index < pointsAtMiddle.Count; ++index)
      {
        if (!pointsAtMiddle[index].Position.Between(minimum, maximum))
        {
          pointsAtMiddle.Remove(pointsAtMiddle[index]);
          --index;
        }
      }
    }
  }
}
