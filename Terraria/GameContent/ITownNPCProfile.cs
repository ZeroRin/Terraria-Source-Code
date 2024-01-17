// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ITownNPCProfile
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
