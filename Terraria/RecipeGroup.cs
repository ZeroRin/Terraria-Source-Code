// Decompiled with JetBrains decompiler
// Type: Terraria.RecipeGroup
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Collections.Generic;

namespace Terraria
{
  public class RecipeGroup
  {
    public Func<string> GetText;
    public HashSet<int> ValidItems;
    public int IconicItemId;
    public static Dictionary<int, RecipeGroup> recipeGroups = new Dictionary<int, RecipeGroup>();
    public static Dictionary<string, int> recipeGroupIDs = new Dictionary<string, int>();
    public static int nextRecipeGroupIndex;

    public RecipeGroup(Func<string> getName, params int[] validItems)
    {
      this.GetText = getName;
      this.ValidItems = new HashSet<int>((IEnumerable<int>) validItems);
      this.IconicItemId = validItems[0];
    }

    public static int RegisterGroup(string name, RecipeGroup rec)
    {
      int key = RecipeGroup.nextRecipeGroupIndex++;
      RecipeGroup.recipeGroups.Add(key, rec);
      RecipeGroup.recipeGroupIDs.Add(name, key);
      return key;
    }
  }
}
