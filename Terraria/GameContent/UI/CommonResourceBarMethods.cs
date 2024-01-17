// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.CommonResourceBarMethods
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.GameContent.UI
{
  public class CommonResourceBarMethods
  {
    public static void DrawLifeMouseOver()
    {
      if (Main.mouseText)
        return;
      Player localPlayer = Main.LocalPlayer;
      localPlayer.cursorItemIconEnabled = false;
      string text = localPlayer.statLife.ToString() + "/" + (object) localPlayer.statLifeMax2;
      Main.instance.MouseTextHackZoom(text);
      Main.mouseText = true;
    }

    public static void DrawManaMouseOver()
    {
      if (Main.mouseText)
        return;
      Player localPlayer = Main.LocalPlayer;
      localPlayer.cursorItemIconEnabled = false;
      string text = localPlayer.statMana.ToString() + "/" + (object) localPlayer.statManaMax2;
      Main.instance.MouseTextHackZoom(text);
      Main.mouseText = true;
    }
  }
}
