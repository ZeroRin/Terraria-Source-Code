// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.ItemSyncPersistentStats
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.DataStructures
{
  public struct ItemSyncPersistentStats
  {
    private Color color;
    private int type;

    public void CopyFrom(Item item)
    {
      this.type = item.type;
      this.color = item.color;
    }

    public void PasteInto(Item item)
    {
      if (this.type != item.type)
        return;
      item.color = this.color;
    }
  }
}
