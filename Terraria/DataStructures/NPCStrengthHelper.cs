// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.NPCStrengthHelper
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.DataStructures
{
  public struct NPCStrengthHelper
  {
    private float _strength;
    private GameModeData _gameModeData;

    public bool IsExpertMode => (double) this._strength >= 2.0 || this._gameModeData.IsExpertMode;

    public bool IsMasterMode => (double) this._strength >= 3.0 || this._gameModeData.IsMasterMode;

    public NPCStrengthHelper(GameModeData data, float strength)
    {
      this._strength = strength;
      this._gameModeData = data;
    }
  }
}
