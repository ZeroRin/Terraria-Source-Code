// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.OverlaySocialModule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Social.WeGame
{
  public class OverlaySocialModule : Terraria.Social.Base.OverlaySocialModule
  {
    private bool _gamepadTextInputActive;

    public override void Initialize()
    {
    }

    public override void Shutdown()
    {
    }

    public override bool IsGamepadTextInputActive() => this._gamepadTextInputActive;

    public override bool ShowGamepadTextInput(
      string description,
      uint maxLength,
      bool multiLine = false,
      string existingText = "",
      bool password = false)
    {
      return false;
    }

    public override string GetGamepadText() => "";
  }
}
