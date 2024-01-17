// Decompiled with JetBrains decompiler
// Type: Terraria.Achievements.ConditionIntTracker
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.Social;

namespace Terraria.Achievements
{
  public class ConditionIntTracker : AchievementTracker<int>
  {
    public ConditionIntTracker()
      : base(TrackerType.Int)
    {
    }

    public ConditionIntTracker(int maxValue)
      : base(TrackerType.Int)
    {
      this._maxValue = maxValue;
    }

    public override void ReportUpdate()
    {
      if (SocialAPI.Achievements == null || this._name == null)
        return;
      SocialAPI.Achievements.UpdateIntStat(this._name, this._value);
    }

    protected override void Load()
    {
    }
  }
}
