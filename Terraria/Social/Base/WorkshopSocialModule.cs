// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.WorkshopSocialModule
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;
using Terraria.IO;

namespace Terraria.Social.Base
{
  public abstract class WorkshopSocialModule : ISocialModule
  {
    public WorkshopBranding Branding { get; protected set; }

    public AWorkshopProgressReporter ProgressReporter { get; protected set; }

    public AWorkshopTagsCollection SupportedTags { get; protected set; }

    public WorkshopIssueReporter IssueReporter { get; protected set; }

    public abstract void Initialize();

    public abstract void Shutdown();

    public abstract void PublishWorld(WorldFileData world, WorkshopItemPublishSettings settings);

    public abstract void PublishResourcePack(
      ResourcePack resourcePack,
      WorkshopItemPublishSettings settings);

    public abstract bool TryGetInfoForWorld(WorldFileData world, out FoundWorkshopEntryInfo info);

    public abstract bool TryGetInfoForResourcePack(
      ResourcePack resourcePack,
      out FoundWorkshopEntryInfo info);

    public abstract void LoadEarlyContent();

    public abstract List<string> GetListOfSubscribedResourcePackPaths();

    public abstract List<string> GetListOfSubscribedWorldPaths();

    public abstract bool TryGetPath(string pathEnd, out string fullPathFound);

    public abstract void ImportDownloadedWorldToLocalSaves(
      WorldFileData world,
      string newFileName = null,
      string newDisplayName = null);
  }
}
