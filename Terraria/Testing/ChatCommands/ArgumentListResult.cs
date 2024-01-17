// Decompiled with JetBrains decompiler
// Type: Terraria.Testing.ChatCommands.ArgumentListResult
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Terraria.Testing.ChatCommands
{
  public class ArgumentListResult : IEnumerable<string>, IEnumerable
  {
    public static readonly ArgumentListResult Empty = new ArgumentListResult(true);
    public static readonly ArgumentListResult Invalid = new ArgumentListResult(false);
    public readonly bool IsValid;
    private readonly List<string> _results;

    public int Count => this._results.Count;

    public string this[int index] => this._results[index];

    public ArgumentListResult(IEnumerable<string> results)
    {
      this._results = results.ToList<string>();
      this.IsValid = true;
    }

    private ArgumentListResult(bool isValid)
    {
      this._results = new List<string>();
      this.IsValid = isValid;
    }

    public IEnumerator<string> GetEnumerator() => (IEnumerator<string>) this._results.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}
