// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.Commands.SayChatCommand
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
