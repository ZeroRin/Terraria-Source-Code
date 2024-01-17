﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ItemDropRules.CommonCode
// Assembly: Terraria, Version=1.4.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F541F3E5-89DE-4E5D-868F-1B56DAAB46B2
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.Utilities;

namespace Terraria.GameContent.ItemDropRules
{
  public static class CommonCode
  {
    public static void DropItemFromNPC(NPC npc, int itemId, int stack, bool scattered = false)
    {
      if (itemId <= 0 || itemId >= 5125)
        return;
      int X = (int) npc.position.X + npc.width / 2;
      int Y = (int) npc.position.Y + npc.height / 2;
      if (scattered)
      {
        X = (int) npc.position.X + Main.rand.Next(npc.width + 1);
        Y = (int) npc.position.Y + Main.rand.Next(npc.height + 1);
      }
      int itemIndex = Item.NewItem(npc.GetItemSource_Loot(), X, Y, 0, 0, itemId, stack, pfix: -1);
      CommonCode.ModifyItemDropFromNPC(npc, itemIndex);
    }

    public static void DropItemLocalPerClientAndSetNPCMoneyTo0(
      NPC npc,
      int itemId,
      int stack,
      bool interactionRequired = true)
    {
      if (itemId <= 0 || itemId >= 5125)
        return;
      if (Main.netMode == 2)
      {
        int number = Item.NewItem(npc.GetItemSource_Loot(), (int) npc.position.X, (int) npc.position.Y, npc.width, npc.height, itemId, stack, true, -1);
        Main.timeItemSlotCannotBeReusedFor[number] = 54000;
        for (int remoteClient = 0; remoteClient < (int) byte.MaxValue; ++remoteClient)
        {
          if (Main.player[remoteClient].active && (npc.playerInteraction[remoteClient] || !interactionRequired))
            NetMessage.SendData(90, remoteClient, number: number);
        }
        Main.item[number].active = false;
      }
      else
        CommonCode.DropItemFromNPC(npc, itemId, stack);
      npc.value = 0.0f;
    }

    public static void DropItemForEachInteractingPlayerOnThePlayer(
      NPC npc,
      int itemId,
      UnifiedRandom rng,
      int chanceNumerator,
      int chanceDenominator,
      int stack = 1,
      bool interactionRequired = true)
    {
      if (itemId <= 0 || itemId >= 5125)
        return;
      if (Main.netMode == 2)
      {
        for (int index = 0; index < (int) byte.MaxValue; ++index)
        {
          Player player = Main.player[index];
          if (player.active && (npc.playerInteraction[index] || !interactionRequired) && rng.Next(chanceDenominator) < chanceNumerator)
          {
            int itemIndex = Item.NewItem(npc.GetItemSource_Loot(), player.position, player.Size, itemId, stack, prefixGiven: -1);
            CommonCode.ModifyItemDropFromNPC(npc, itemIndex);
          }
        }
      }
      else if (rng.Next(chanceDenominator) < chanceNumerator)
        CommonCode.DropItemFromNPC(npc, itemId, stack);
      npc.value = 0.0f;
    }

    public static void ModifyItemDropFromNPC(NPC npc, int itemIndex)
    {
      Item obj = Main.item[itemIndex];
      switch (obj.type)
      {
        case 23:
          if (npc.type != 1 || npc.netID == -1 || npc.netID == -2 || npc.netID == -5 || npc.netID == -6)
            break;
          obj.color = npc.color;
          NetMessage.SendData(88, number: itemIndex, number2: 1f);
          break;
        case 319:
          switch (npc.netID)
          {
            case 542:
              obj.color = new Color(189, 148, 96, (int) byte.MaxValue);
              NetMessage.SendData(88, number: itemIndex, number2: 1f);
              return;
            case 543:
              obj.color = new Color(112, 85, 89, (int) byte.MaxValue);
              NetMessage.SendData(88, number: itemIndex, number2: 1f);
              return;
            case 544:
              obj.color = new Color(145, 27, 40, (int) byte.MaxValue);
              NetMessage.SendData(88, number: itemIndex, number2: 1f);
              return;
            case 545:
              obj.color = new Color(158, 113, 164, (int) byte.MaxValue);
              NetMessage.SendData(88, number: itemIndex, number2: 1f);
              return;
            default:
              return;
          }
      }
    }
  }
}
