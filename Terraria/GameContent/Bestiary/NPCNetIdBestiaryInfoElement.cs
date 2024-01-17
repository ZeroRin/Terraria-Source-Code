// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.NPCNetIdBestiaryInfoElement
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.ID;
using Terraria.UI;

namespace Terraria.GameContent.Bestiary
{
  public class NPCNetIdBestiaryInfoElement : IBestiaryInfoElement, IBestiaryEntryDisplayIndex
  {
    public int NetId { get; private set; }

    public NPCNetIdBestiaryInfoElement(int npcNetId) => this.NetId = npcNetId;

    public UIElement ProvideUIElement(BestiaryUICollectionInfo info) => (UIElement) null;

    public int BestiaryDisplayIndex => ContentSamples.NpcBestiarySortingId[this.NetId];
  }
}
