// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.OverlaySocialModule
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Social.Base
{
  public abstract class OverlaySocialModule : ISocialModule
  {
    public abstract void Initialize();

    public abstract void Shutdown();

    public abstract bool IsGamepadTextInputActive();

    public abstract bool ShowGamepadTextInput(
      string description,
      uint maxLength,
      bool multiLine = false,
      string existingText = "",
      bool password = false);

    public abstract string GetGamepadText();
  }
}
