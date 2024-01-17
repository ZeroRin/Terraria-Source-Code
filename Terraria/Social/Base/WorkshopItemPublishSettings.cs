// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.WorkshopItemPublishSettings
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Collections.Generic;
using System.Linq;

namespace Terraria.Social.Base
{
  public class WorkshopItemPublishSettings
  {
    public WorkshopTagOption[] UsedTags = new WorkshopTagOption[0];
    public WorkshopItemPublicSettingId Publicity;
    public string PreviewImagePath;

    public string[] GetUsedTagsInternalNames() => ((IEnumerable<WorkshopTagOption>) this.UsedTags).Select<WorkshopTagOption, string>((Func<WorkshopTagOption, string>) (x => x.InternalNameForAPIs)).ToArray<string>();
  }
}
