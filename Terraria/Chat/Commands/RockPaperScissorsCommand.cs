// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.Commands.RockPaperScissorsCommand
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.GameContent.UI;

namespace Terraria.Chat.Commands
{
  [ChatCommand("RPS")]
  public class RockPaperScissorsCommand : IChatCommand
  {
    public void ProcessIncomingMessage(string text, byte clientId)
    {
    }

    public void ProcessOutgoingMessage(ChatMessage message)
    {
      int num = Main.rand.NextFromList<int>(37, 38, 36);
      if (Main.netMode == 0)
      {
        EmoteBubble.NewBubble(num, new WorldUIAnchor((Entity) Main.LocalPlayer), 360);
        EmoteBubble.CheckForNPCsToReactToEmoteBubble(num, Main.LocalPlayer);
      }
      else
        NetMessage.SendData(120, number: Main.myPlayer, number2: (float) num);
      message.Consume();
    }
  }
}
