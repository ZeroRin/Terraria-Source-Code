﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.IPersistentPerPlayerContent
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.IO;

namespace Terraria.GameContent
{
  public interface IPersistentPerPlayerContent
  {
    void Save(Player player, BinaryWriter writer);

    void Load(Player player, BinaryReader reader, int gameVersionSaveWasMadeOn);

    void ApplyLoadedDataToOutOfPlayerFields(Player player);

    void ResetDataForNewPlayer(Player player);

    void Reset();
  }
}
