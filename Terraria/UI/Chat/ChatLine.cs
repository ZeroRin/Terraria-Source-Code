// Decompiled with JetBrains decompiler
// Type: Terraria.UI.Chat.ChatLine
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.UI.Chat
{
  public class ChatLine
  {
    public Color color = Color.White;
    public int showTime;
    public string originalText = "";
    public TextSnippet[] parsedText = new TextSnippet[0];
    private int? parsingPixelLimit;
    private bool needsParsing;

    public void UpdateTimeLeft()
    {
      if (this.showTime > 0)
        --this.showTime;
      if (!this.needsParsing)
        return;
      this.needsParsing = false;
    }

    public void Copy(ChatLine other)
    {
      this.needsParsing = other.needsParsing;
      this.parsingPixelLimit = other.parsingPixelLimit;
      this.originalText = other.originalText;
      this.parsedText = other.parsedText;
      this.showTime = other.showTime;
      this.color = other.color;
    }

    public void FlagAsNeedsReprocessing() => this.needsParsing = true;
  }
}
