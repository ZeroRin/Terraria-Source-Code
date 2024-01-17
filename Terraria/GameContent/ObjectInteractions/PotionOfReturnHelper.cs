// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ObjectInteractions.PotionOfReturnHelper
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.ObjectInteractions
{
  public class PotionOfReturnHelper
  {
    public static bool TryGetGateHitbox(Player player, out Rectangle homeHitbox)
    {
      homeHitbox = Rectangle.Empty;
      if (!player.PotionOfReturnHomePosition.HasValue)
        return false;
      Vector2 vector2 = new Vector2(0.0f, (float) (-player.height / 2));
      Vector2 center = player.PotionOfReturnHomePosition.Value + vector2;
      homeHitbox = Utils.CenteredRectangle(center, new Vector2(24f, 40f));
      return true;
    }
  }
}
