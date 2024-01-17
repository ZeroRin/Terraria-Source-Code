﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.ChildSafety
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.ID;

namespace Terraria.GameContent
{
  public class ChildSafety
  {
    private static SetFactory factoryDust = new SetFactory(305);
    private static SetFactory factoryGore = new SetFactory(1270);
    private static readonly bool[] SafeGore = ChildSafety.factoryGore.CreateBoolSet(11, 12, 13, 16, 17, 42, 53, 44, 51, 52, 53, 54, 55, 56, 57, 61, 62, 63, 67, 68, 69, 99, 106, 120, 130, 131, 147, 148, 149, 150, 156, 197, 198, 199, 200, 201, 202, 203, 204, 205, 206, 213, 217, 218, 219, 220, 221, 222, 257, 265, 266, 267, 268, 269, 276, 277, 278, 279, 280, 281, 282, 314, 321, 322, 326, 331, 360, 361, 362, 363, 364, 365, 366, 367, 368, 369, 370, 375, 376, 377, 406, 407, 408, 409, 410, 411, 412, 413, 414, 415, 416, 417, 418, 419, 420, 421, 422, 423, 424, 425, 426, 427, 428, 429, 430, 435, 436, 437, 521, 522, 523, 525, 526, 527, 542, 570, 571, 572, 580, 581, 582, 603, 604, 605, 606, 610, 611, 612, 613, 614, 615, 616, 617, 618, 639, 704, 705, 706, 707, 708, 709, 710, 711, 712, 713, 714, 715, 716, 717, 718, 719, 720, 721, 734, 728, 729, 730, 731, 732, 733, 825, 826, 827, 848, 849, 850, 851, 853, 854, 855, 856, 857, 858, 859, 860, 861, 862, 892, 893, 898, 899, 907, 908, 909, 910, 911, 912, 913, 914, 915, 916, 917, 918, 919, 920, 921, 922, 923, 924, 925, 926, 939, 940, 941, 942, 943, 1087, 1088, 1089, 1090, 1091, 1092, 1093, 1113, 1114, 1115, 1116, 1117, 1118, 1119, 1120, 1121, 1125, 1126, 1127, 1128, 1129, 1130, 1131, 1132, 1133, 1134, 1135, 1136, 1137, 1138, 1139, 1140, 1141, 1142, 1143, 1144, 1145, 1146, 1147, 1160, 1161, 1162, 1201, 1202, 1203, 1204, 1208, 1209, 1218, 1225, 1226, 1248, 1249, 1250, 1251, 1252, 1253, 1254, 1255, 1257, 1261);
    private static readonly bool[] SafeDust = ChildSafety.factoryDust.CreateBoolSet(true, 5, 227, 273);
    public static bool Disabled = true;

    public static bool DangerousGore(int id) => !ChildSafety.SafeGore[id];

    public static bool DangerousDust(int id) => !ChildSafety.SafeDust[id];
  }
}
