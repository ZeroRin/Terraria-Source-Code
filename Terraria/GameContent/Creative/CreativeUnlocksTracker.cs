// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Creative.CreativeUnlocksTracker
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.IO;

namespace Terraria.GameContent.Creative
{
  public class CreativeUnlocksTracker : IPersistentPerWorldContent, IOnPlayerJoining
  {
    public ItemsSacrificedUnlocksTracker ItemSacrifices = new ItemsSacrificedUnlocksTracker();

    public void Save(BinaryWriter writer) => this.ItemSacrifices.Save(writer);

    public void Load(BinaryReader reader, int gameVersionSaveWasMadeOn) => this.ItemSacrifices.Load(reader, gameVersionSaveWasMadeOn);

    public void ValidateWorld(BinaryReader reader, int gameVersionSaveWasMadeOn) => this.ValidateWorld(reader, gameVersionSaveWasMadeOn);

    public void Reset() => this.ItemSacrifices.Reset();

    public void OnPlayerJoining(int playerIndex) => this.ItemSacrifices.OnPlayerJoining(playerIndex);
  }
}
