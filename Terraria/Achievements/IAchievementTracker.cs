// Decompiled with JetBrains decompiler
// Type: Terraria.Achievements.IAchievementTracker
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Achievements
{
  public interface IAchievementTracker
  {
    void ReportAs(string name);

    TrackerType GetTrackerType();

    void Load();

    void Clear();
  }
}
