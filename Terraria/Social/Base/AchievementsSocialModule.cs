﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.AchievementsSocialModule
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Social.Base
{
  public abstract class AchievementsSocialModule : ISocialModule
  {
    public abstract void Initialize();

    public abstract void Shutdown();

    public abstract byte[] GetEncryptionKey();

    public abstract string GetSavePath();

    public abstract void UpdateIntStat(string name, int value);

    public abstract void UpdateFloatStat(string name, float value);

    public abstract void CompleteAchievement(string name);

    public abstract bool IsAchievementCompleted(string name);

    public abstract void StoreStats();
  }
}
