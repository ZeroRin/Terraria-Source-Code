// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.NPCStrengthHelper
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
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
