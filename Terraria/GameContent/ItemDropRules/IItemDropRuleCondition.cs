﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.IItemDropRuleCondition
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.GameContent.ItemDropRules
{
  public interface IItemDropRuleCondition : IProvideItemConditionDescription
  {
    bool CanDrop(DropAttemptInfo info);

    bool CanShowItemDropInUI();
  }
}
