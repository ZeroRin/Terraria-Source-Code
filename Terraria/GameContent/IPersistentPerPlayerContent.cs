// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.IPersistentPerPlayerContent
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
