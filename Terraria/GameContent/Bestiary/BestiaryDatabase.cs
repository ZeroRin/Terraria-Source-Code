// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.BestiaryDatabase
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;
using Terraria.GameContent.ItemDropRules;

namespace Terraria.GameContent.Bestiary
{
  public class BestiaryDatabase
  {
    private List<BestiaryEntry> _entries = new List<BestiaryEntry>();
    private List<IBestiaryEntryFilter> _filters = new List<IBestiaryEntryFilter>();
    private List<IBestiarySortStep> _sortSteps = new List<IBestiarySortStep>();
    private Dictionary<int, BestiaryEntry> _byNpcId = new Dictionary<int, BestiaryEntry>();
    private BestiaryEntry _trashEntry = new BestiaryEntry();

    public List<BestiaryEntry> Entries => this._entries;

    public List<IBestiaryEntryFilter> Filters => this._filters;

    public List<IBestiarySortStep> SortSteps => this._sortSteps;

    public BestiaryEntry Register(BestiaryEntry entry)
    {
      this._entries.Add(entry);
      for (int index = 0; index < entry.Info.Count; ++index)
      {
        if (entry.Info[index] is NPCNetIdBestiaryInfoElement bestiaryInfoElement)
          this._byNpcId[bestiaryInfoElement.NetId] = entry;
      }
      return entry;
    }

    public IBestiaryEntryFilter Register(IBestiaryEntryFilter filter)
    {
      this._filters.Add(filter);
      return filter;
    }

    public IBestiarySortStep Register(IBestiarySortStep sortStep)
    {
      this._sortSteps.Add(sortStep);
      return sortStep;
    }

    public BestiaryEntry FindEntryByNPCID(int npcNetId)
    {
      BestiaryEntry entryByNpcid;
      if (this._byNpcId.TryGetValue(npcNetId, out entryByNpcid))
        return entryByNpcid;
      this._trashEntry.Info.Clear();
      return this._trashEntry;
    }

    public void Merge(ItemDropDatabase dropsDatabase)
    {
      for (int npcId = -65; npcId < 668; ++npcId)
        this.ExtractDropsForNPC(dropsDatabase, npcId);
    }

    private void ExtractDropsForNPC(ItemDropDatabase dropsDatabase, int npcId)
    {
      BestiaryEntry entryByNpcid = this.FindEntryByNPCID(npcId);
      if (entryByNpcid == null)
        return;
      List<IItemDropRule> rulesForNpcid = dropsDatabase.GetRulesForNPCID(npcId, false);
      List<DropRateInfo> drops = new List<DropRateInfo>();
      DropRateInfoChainFeed ratesInfo = new DropRateInfoChainFeed(1f);
      foreach (IItemDropRule itemDropRule in rulesForNpcid)
        itemDropRule.ReportDroprates(drops, ratesInfo);
      foreach (DropRateInfo info in drops)
        entryByNpcid.Info.Add((IBestiaryInfoElement) new ItemDropBestiaryInfoElement(info));
    }

    public void ApplyPass(BestiaryDatabase.BestiaryEntriesPass pass)
    {
      for (int index = 0; index < this._entries.Count; ++index)
        pass(this._entries[index]);
    }

    public delegate void BestiaryEntriesPass(BestiaryEntry entry);
  }
}
