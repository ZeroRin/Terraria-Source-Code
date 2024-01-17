// Decompiled with JetBrains decompiler
// Type: Terraria.LiquidBuffer
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria
{
  public class LiquidBuffer
  {
    public static int numLiquidBuffer;
    public int x;
    public int y;

    public static void AddBuffer(int x, int y)
    {
      if (LiquidBuffer.numLiquidBuffer >= 49998 || Main.tile[x, y].checkingLiquid())
        return;
      Main.tile[x, y].checkingLiquid(true);
      Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].x = x;
      Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].y = y;
      ++LiquidBuffer.numLiquidBuffer;
    }

    public static void DelBuffer(int l)
    {
      --LiquidBuffer.numLiquidBuffer;
      Main.liquidBuffer[l].x = Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].x;
      Main.liquidBuffer[l].y = Main.liquidBuffer[LiquidBuffer.numLiquidBuffer].y;
    }
  }
}
