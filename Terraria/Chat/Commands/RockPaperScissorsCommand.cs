// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.Commands.RockPaperScissorsCommand
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
