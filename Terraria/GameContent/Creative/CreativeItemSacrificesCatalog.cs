﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Creative.CreativeItemSacrificesCatalog
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Terraria.ID;

namespace Terraria.GameContent.Creative
{
  public class CreativeItemSacrificesCatalog
  {
    public static CreativeItemSacrificesCatalog Instance = new CreativeItemSacrificesCatalog();
    private Dictionary<int, int> _sacrificeCountNeededByItemId = new Dictionary<int, int>();

    public Dictionary<int, int> SacrificeCountNeededByItemId => this._sacrificeCountNeededByItemId;

    public void Initialize()
    {
      this._sacrificeCountNeededByItemId.Clear();
      foreach (string str in Regex.Split(Utils.ReadEmbeddedResource("Terraria.GameContent.Creative.Content.Sacrifices.tsv"), "\r\n|\r|\n"))
      {
        if (!str.StartsWith("//"))
        {
          string[] strArray = str.Split('\t');
          int key;
          if (strArray.Length >= 3 && ItemID.Search.TryGetId(strArray[0], ref key))
          {
            int num = 0;
            bool flag = false;
            string lower = strArray[1].ToLower();
            switch (lower)
            {
              case "":
              case "a":
                num = 50;
                break;
              case "b":
                num = 25;
                break;
              case "c":
                num = 5;
                break;
              case "d":
                num = 1;
                break;
              case "e":
                flag = true;
                break;
              case "f":
                num = 2;
                break;
              case "g":
                num = 3;
                break;
              case "h":
                num = 10;
                break;
              case "i":
                num = 15;
                break;
              case "j":
                num = 30;
                break;
              case "k":
                num = 99;
                break;
              case "l":
                num = 100;
                break;
              case "m":
                num = 200;
                break;
              case "n":
                num = 20;
                break;
              case "o":
                num = 400;
                break;
              default:
                throw new Exception("There is no category for this item: " + strArray[0] + ", category: " + lower);
            }
            if (!flag)
              this._sacrificeCountNeededByItemId[key] = num;
          }
        }
      }
    }

    public bool TryGetSacrificeCountCapToUnlockInfiniteItems(int itemId, out int amountNeeded)
    {
      int num;
      if (ContentSamples.CreativeResearchItemPersistentIdOverride.TryGetValue(itemId, out num))
        itemId = num;
      return this._sacrificeCountNeededByItemId.TryGetValue(itemId, out amountNeeded);
    }
  }
}
