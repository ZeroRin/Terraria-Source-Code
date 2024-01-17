// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.AssetSourceController
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using ReLogic.Content;
using ReLogic.Content.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.IO;

namespace Terraria.GameContent
{
  public class AssetSourceController
  {
    private readonly List<IContentSource> _staticSources;
    private readonly IAssetRepository _assetRepository;

    public event Action<ResourcePackList> OnResourcePackChange;

    public ResourcePackList ActiveResourcePackList { get; private set; }

    public AssetSourceController(
      IAssetRepository assetRepository,
      IEnumerable<IContentSource> staticSources)
    {
      this._assetRepository = assetRepository;
      this._staticSources = staticSources.ToList<IContentSource>();
      this.UseResourcePacks(new ResourcePackList());
    }

    public void Refresh()
    {
      foreach (ResourcePack allPack in this.ActiveResourcePackList.AllPacks)
        allPack.Refresh();
      this.UseResourcePacks(this.ActiveResourcePackList);
    }

    public void UseResourcePacks(ResourcePackList resourcePacks)
    {
      if (this.OnResourcePackChange != null)
        this.OnResourcePackChange(resourcePacks);
      this.ActiveResourcePackList = resourcePacks;
      List<IContentSource> icontentSourceList = new List<IContentSource>(resourcePacks.EnabledPacks.OrderBy<ResourcePack, int>((Func<ResourcePack, int>) (pack => pack.SortingOrder)).Select<ResourcePack, IContentSource>((Func<ResourcePack, IContentSource>) (pack => pack.GetContentSource())));
      icontentSourceList.AddRange((IEnumerable<IContentSource>) this._staticSources);
      foreach (IContentSource icontentSource in icontentSourceList)
        icontentSource.ClearRejections();
      this._assetRepository.SetSources((IEnumerable<IContentSource>) icontentSourceList, (AssetRequestMode) 1);
    }
  }
}
