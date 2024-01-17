// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.RejectionMenuInfo
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.Audio;

namespace Terraria.DataStructures
{
  public class RejectionMenuInfo
  {
    public ReturnFromRejectionMenuAction ExitAction;
    public string TextToShow;

    public void DefaultExitAction()
    {
      SoundEngine.PlaySound(11);
      Main.menuMode = 0;
      Main.netMode = 0;
    }
  }
}
