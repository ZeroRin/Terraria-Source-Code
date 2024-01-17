// Decompiled with JetBrains decompiler
// Type: Terraria.Utilities.FileBrowser.NativeFileDialog
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Collections.Generic;
using System.Linq;

namespace Terraria.Utilities.FileBrowser
{
  public class NativeFileDialog : IFileBrowser
  {
    public string OpenFilePanel(string title, ExtensionFilter[] extensions)
    {
      string outPath;
      return nativefiledialog.NFD_OpenDialog(string.Join(",", ((IEnumerable<ExtensionFilter>) extensions).SelectMany<ExtensionFilter, string>((Func<ExtensionFilter, IEnumerable<string>>) (x => (IEnumerable<string>) x.Extensions)).ToArray<string>()), (string) null, out outPath) == nativefiledialog.nfdresult_t.NFD_OKAY ? outPath : (string) null;
    }
  }
}
