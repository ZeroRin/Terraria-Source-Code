// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ITownNPCProfile
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace Terraria.GameContent
{
  public interface ITownNPCProfile
  {
    int RollVariation();

    string GetNameForVariant(NPC npc);

    Asset<Texture2D> GetTextureNPCShouldUse(NPC npc);

    int GetHeadTextureIndex(NPC npc);
  }
}
