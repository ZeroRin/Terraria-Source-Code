﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.States.UISortableElement
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.UI;

namespace Terraria.GameContent.UI.States
{
  public class UISortableElement : UIElement
  {
    public int OrderIndex;

    public UISortableElement(int index) => this.OrderIndex = index;

    public override int CompareTo(object obj) => obj is UISortableElement uiSortableElement ? this.OrderIndex.CompareTo(uiSortableElement.OrderIndex) : base.CompareTo(obj);
  }
}
