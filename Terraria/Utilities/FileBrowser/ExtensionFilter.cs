// Decompiled with JetBrains decompiler
// Type: Terraria.Utilities.FileBrowser.ExtensionFilter
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Utilities.FileBrowser
{
  public struct ExtensionFilter
  {
    public string Name;
    public string[] Extensions;

    public ExtensionFilter(string filterName, params string[] filterExtensions)
    {
      this.Name = filterName;
      this.Extensions = filterExtensions;
    }
  }
}
