// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.ItemSyncPersistentStats
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
