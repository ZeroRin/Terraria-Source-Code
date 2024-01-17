// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.Commands.SayChatCommand
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.Localization;

namespace Terraria.Chat.Commands
{
  [ChatCommand("Say")]
  public class SayChatCommand : IChatCommand
  {
    public void ProcessIncomingMessage(string text, byte clientId) => ChatHelper.BroadcastChatMessageAs(clientId, NetworkText.FromLiteral(text), Main.player[(int) clientId].ChatColor());

    public void ProcessOutgoingMessage(ChatMessage message)
    {
    }
  }
}
