// Decompiled with JetBrains decompiler
// Type: Terraria.Utilities.FileBrowser.FileBrowser
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Utilities.FileBrowser
{
  public class FileBrowser
  {
    private static IFileBrowser _platformWrapper = (IFileBrowser) new NativeFileDialog();

    public static string OpenFilePanel(string title, string extension)
    {
      ExtensionFilter[] extensionFilterArray;
      if (!string.IsNullOrEmpty(extension))
        extensionFilterArray = new ExtensionFilter[1]
        {
          new ExtensionFilter("", new string[1]{ extension })
        };
      else
        extensionFilterArray = (ExtensionFilter[]) null;
      ExtensionFilter[] extensions = extensionFilterArray;
      return Terraria.Utilities.FileBrowser.FileBrowser.OpenFilePanel(title, extensions);
    }

    public static string OpenFilePanel(string title, ExtensionFilter[] extensions) => Terraria.Utilities.FileBrowser.FileBrowser._platformWrapper.OpenFilePanel(title, extensions);
  }
}
