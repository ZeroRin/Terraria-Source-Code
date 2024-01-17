// Decompiled with JetBrains decompiler
// Type: Terraria.IO.ResourcePackContentValidator
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using ReLogic.Content;
using System.IO;
using Terraria.GameContent;

namespace Terraria.IO
{
  public class ResourcePackContentValidator
  {
    public void ValidateResourePack(ResourcePack pack)
    {
      if ((AssetReaderCollection) Main.instance.Services.GetService(typeof (AssetReaderCollection)) == null)
        return;
      pack.GetContentSource().GetAllAssetsStartingWith("Images" + Path.DirectorySeparatorChar.ToString());
      VanillaContentValidator.Instance.GetValidImageFilePaths();
    }
  }
}
