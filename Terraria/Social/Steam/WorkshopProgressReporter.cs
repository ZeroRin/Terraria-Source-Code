﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Steam.WorkshopProgressReporter
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;
using Terraria.Social.Base;

namespace Terraria.Social.Steam
{
  public class WorkshopProgressReporter : AWorkshopProgressReporter
  {
    private List<WorkshopHelper.UGCBased.APublisherInstance> _publisherInstances;

    public WorkshopProgressReporter(
      List<WorkshopHelper.UGCBased.APublisherInstance> publisherInstances)
    {
      this._publisherInstances = publisherInstances;
    }

    public override bool HasOngoingTasks => this._publisherInstances.Count > 0;

    public override bool TryGetProgress(out float progress)
    {
      float num1 = 0.0f;
      float num2 = 0.0f;
      for (int index = 0; index < this._publisherInstances.Count; ++index)
      {
        float progress1;
        if (this._publisherInstances[index].TryGetProgress(out progress1))
        {
          num1 += progress1;
          ++num2;
        }
      }
      progress = 0.0f;
      if ((double) num2 == 0.0)
        return false;
      progress = num1 / num2;
      return true;
    }
  }
}