// Decompiled with JetBrains decompiler
// Type: Terraria.Testing.ChatCommands.ArgumentHelper
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Collections.Generic;
using System.Linq;

namespace Terraria.Testing.ChatCommands
{
  public static class ArgumentHelper
  {
    public static ArgumentListResult ParseList(string arguments) => new ArgumentListResult(((IEnumerable<string>) arguments.Split(' ')).Select<string, string>((Func<string, string>) (arg => arg.Trim())).Where<string>((Func<string, bool>) (arg => arg.Length != 0)));
  }
}
