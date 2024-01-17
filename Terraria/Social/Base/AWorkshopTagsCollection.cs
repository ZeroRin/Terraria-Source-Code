// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.AWorkshopTagsCollection
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.Social.Base
{
  public abstract class AWorkshopTagsCollection
  {
    public readonly List<WorkshopTagOption> WorldTags = new List<WorkshopTagOption>();
    public readonly List<WorkshopTagOption> ResourcePackTags = new List<WorkshopTagOption>();

    protected void AddWorldTag(string tagNameKey, string tagInternalName) => this.WorldTags.Add(new WorkshopTagOption(tagNameKey, tagInternalName));

    protected void AddResourcePackTag(string tagNameKey, string tagInternalName) => this.ResourcePackTags.Add(new WorkshopTagOption(tagNameKey, tagInternalName));
  }
}
