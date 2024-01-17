﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Achievements.ItemCraftCondition
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;
using Terraria.Achievements;

namespace Terraria.GameContent.Achievements
{
  public class ItemCraftCondition : AchievementCondition
  {
    private const string Identifier = "ITEM_PICKUP";
    private static Dictionary<short, List<ItemCraftCondition>> _listeners = new Dictionary<short, List<ItemCraftCondition>>();
    private static bool _isListenerHooked;
    private short[] _itemIds;

    private ItemCraftCondition(short itemId)
      : base("ITEM_PICKUP_" + itemId.ToString())
    {
      this._itemIds = new short[1]{ itemId };
      ItemCraftCondition.ListenForCraft(this);
    }

    private ItemCraftCondition(short[] itemIds)
      : base("ITEM_PICKUP_" + itemIds[0].ToString())
    {
      this._itemIds = itemIds;
      ItemCraftCondition.ListenForCraft(this);
    }

    private static void ListenForCraft(ItemCraftCondition condition)
    {
      if (!ItemCraftCondition._isListenerHooked)
      {
        AchievementsHelper.OnItemCraft += new AchievementsHelper.ItemCraftEvent(ItemCraftCondition.ItemCraftListener);
        ItemCraftCondition._isListenerHooked = true;
      }
      for (int index = 0; index < condition._itemIds.Length; ++index)
      {
        if (!ItemCraftCondition._listeners.ContainsKey(condition._itemIds[index]))
          ItemCraftCondition._listeners[condition._itemIds[index]] = new List<ItemCraftCondition>();
        ItemCraftCondition._listeners[condition._itemIds[index]].Add(condition);
      }
    }

    private static void ItemCraftListener(short itemId, int count)
    {
      if (!ItemCraftCondition._listeners.ContainsKey(itemId))
        return;
      foreach (AchievementCondition achievementCondition in ItemCraftCondition._listeners[itemId])
        achievementCondition.Complete();
    }

    public static AchievementCondition Create(params short[] items) => (AchievementCondition) new ItemCraftCondition(items);

    public static AchievementCondition Create(short item) => (AchievementCondition) new ItemCraftCondition(item);

    public static AchievementCondition[] CreateMany(params short[] items)
    {
      AchievementCondition[] many = new AchievementCondition[items.Length];
      for (int index = 0; index < items.Length; ++index)
        many[index] = (AchievementCondition) new ItemCraftCondition(items[index]);
      return many;
    }
  }
}
