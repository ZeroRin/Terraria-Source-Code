﻿// Decompiled with JetBrains decompiler
// Type: Terraria.ID.PlayerVariantID
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.ID
{
  public static class PlayerVariantID
  {
    public static SetFactory Factory = new SetFactory(12);
    public const int MaleStarter = 0;
    public const int MaleSticker = 1;
    public const int MaleGangster = 2;
    public const int MaleCoat = 3;
    public const int FemaleStarter = 4;
    public const int FemaleSticker = 5;
    public const int FemaleGangster = 6;
    public const int FemaleCoat = 7;
    public const int MaleDress = 8;
    public const int FemaleDress = 9;
    public const int MaleDisplayDoll = 10;
    public const int FemaleDisplayDoll = 11;
    public const int Count = 12;

    public class Sets
    {
      public static bool[] Male = PlayerVariantID.Factory.CreateBoolSet(0, 1, 2, 3, 8, 10);
      public static int[] AltGenderReference = PlayerVariantID.Factory.CreateIntSet(0, 0, 4, 4, 0, 1, 5, 5, 1, 2, 6, 6, 2, 3, 7, 7, 3, 8, 9, 9, 8, 10, 11, 11, 10);
      public static int[] VariantOrderMale = new int[6]
      {
        0,
        1,
        2,
        3,
        8,
        10
      };
      public static int[] VariantOrderFemale = new int[6]
      {
        4,
        5,
        6,
        7,
        9,
        11
      };
    }
  }
}
