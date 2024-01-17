﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.Commands.PartyChatCommand
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Terraria.Chat.Commands
{
  [ChatCommand("Party")]
  public class PartyChatCommand : IChatCommand
  {
    private static readonly Color ERROR_COLOR = new Color((int) byte.MaxValue, 240, 20);

    public void ProcessIncomingMessage(string text, byte clientId)
    {
      int team = Main.player[(int) clientId].team;
      Color color = Main.teamColor[team];
      if (team == 0)
      {
        this.SendNoTeamError(clientId);
      }
      else
      {
        if (text == "")
          return;
        for (int playerId = 0; playerId < (int) byte.MaxValue; ++playerId)
        {
          if (Main.player[playerId].team == team)
            ChatHelper.SendChatMessageToClientAs(clientId, NetworkText.FromLiteral(text), color, playerId);
        }
      }
    }

    public void ProcessOutgoingMessage(ChatMessage message)
    {
    }

    private void SendNoTeamError(byte clientId) => ChatHelper.SendChatMessageToClient(Lang.mp[10].ToNetworkText(), PartyChatCommand.ERROR_COLOR, (int) clientId);
  }
}
