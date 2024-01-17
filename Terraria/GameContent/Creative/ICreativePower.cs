// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Creative.ICreativePower
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;
using System.IO;
using Terraria.UI;

namespace Terraria.GameContent.Creative
{
  public interface ICreativePower
  {
    ushort PowerId { get; set; }

    string ServerConfigName { get; set; }

    PowerPermissionLevel CurrentPermissionLevel { get; set; }

    PowerPermissionLevel DefaultPermissionLevel { get; set; }

    void DeserializeNetMessage(BinaryReader reader, int userId);

    void ProvidePowerButtons(CreativePowerUIElementRequestInfo info, List<UIElement> elements);

    bool GetIsUnlocked();
  }
}
