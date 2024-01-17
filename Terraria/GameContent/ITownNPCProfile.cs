// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ITownNPCProfile
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
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
