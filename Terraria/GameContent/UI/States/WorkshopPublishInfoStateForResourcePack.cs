// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.States.WorkshopPublishInfoStateForResourcePack
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;
using Terraria.IO;
using Terraria.Social;
using Terraria.Social.Base;
using Terraria.UI;

namespace Terraria.GameContent.UI.States
{
  public class WorkshopPublishInfoStateForResourcePack : AWorkshopPublishInfoState<ResourcePack>
  {
    public WorkshopPublishInfoStateForResourcePack(
      UIState stateToGoBackTo,
      ResourcePack resourcePack)
      : base(stateToGoBackTo, resourcePack)
    {
      this._instructionsTextKey = "Workshop.ResourcePackPublishDescription";
      this._publishedObjectNameDescriptorTexKey = "Workshop.ResourcePackName";
    }

    protected override string GetPublishedObjectDisplayName() => this._dataObject == null ? "null" : this._dataObject.Name;

    protected override void GoToPublishConfirmation()
    {
      if (SocialAPI.Workshop != null && this._dataObject != null)
        SocialAPI.Workshop.PublishResourcePack(this._dataObject, this.GetPublishSettings());
      Main.menuMode = 888;
      Main.MenuUI.SetState(this._previousUIState);
    }

    protected override List<WorkshopTagOption> GetTagsToShow() => SocialAPI.Workshop.SupportedTags.ResourcePackTags;

    protected override bool TryFindingTags(out FoundWorkshopEntryInfo info) => SocialAPI.Workshop.TryGetInfoForResourcePack(this._dataObject, out info);
  }
}
