// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.Commands.ListPlayersCommand
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.Localization;

namespace Terraria.Chat.Commands
{
  [ChatCommand("Playing")]
  public class ListPlayersCommand : IChatCommand
  {
    private static readonly Color RESPONSE_COLOR = new Color((int) byte.MaxValue, 240, 20);

    public void ProcessIncomingMessage(string text, byte clientId) => ChatHelper.SendChatMessageToClient(NetworkText.FromLiteral(string.Join(", ", ((IEnumerable<Player>) Main.player).Where<Player>((Func<Player, bool>) (player => player.active)).Select<Player, string>((Func<Player, string>) (player => player.name)))), ListPlayersCommand.RESPONSE_COLOR, (int) clientId);

    public void ProcessOutgoingMessage(ChatMessage message)
    {
    }
  }
}
