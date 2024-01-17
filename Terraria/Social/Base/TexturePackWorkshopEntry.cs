// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.TexturePackWorkshopEntry
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Terraria.IO;

namespace Terraria.Social.Base
{
  public class TexturePackWorkshopEntry : AWorkshopEntry
  {
    public static string GetHeaderTextFor(
      ResourcePack resourcePack,
      ulong workshopEntryId,
      string[] tags,
      WorkshopItemPublicSettingId publicity,
      string previewImagePath)
    {
      return AWorkshopEntry.CreateHeaderJson("ResourcePack", workshopEntryId, tags, publicity, previewImagePath);
    }
  }
}
