// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Bestiary.NPCNetIdBestiaryInfoElement
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
