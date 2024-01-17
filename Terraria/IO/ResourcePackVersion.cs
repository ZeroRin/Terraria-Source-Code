// Decompiled with JetBrains decompiler
// Type: Terraria.IO.ResourcePackVersion
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace Terraria.IO
{
  [DebuggerDisplay("Version {Major}.{Minor}")]
  public struct ResourcePackVersion : IComparable, IComparable<ResourcePackVersion>
  {
    [JsonProperty("major")]
    public int Major { get; private set; }

    [JsonProperty("minor")]
    public int Minor { get; private set; }

    public int CompareTo(object obj)
    {
      if (obj == null)
        return 1;
      if (!(obj is ResourcePackVersion other))
        throw new ArgumentException("A RatingInformation object is required for comparison.", nameof (obj));
      return this.CompareTo(other);
    }

    public int CompareTo(ResourcePackVersion other)
    {
      int num = this.Major.CompareTo(other.Major);
      return num != 0 ? num : this.Minor.CompareTo(other.Minor);
    }

    public static bool operator ==(ResourcePackVersion lhs, ResourcePackVersion rhs) => lhs.CompareTo(rhs) == 0;

    public static bool operator !=(ResourcePackVersion lhs, ResourcePackVersion rhs) => !(lhs == rhs);

    public static bool operator <(ResourcePackVersion lhs, ResourcePackVersion rhs) => lhs.CompareTo(rhs) < 0;

    public static bool operator >(ResourcePackVersion lhs, ResourcePackVersion rhs) => lhs.CompareTo(rhs) > 0;

    public override bool Equals(object obj) => obj is ResourcePackVersion other && this.CompareTo(other) == 0;

    public override int GetHashCode() => ((long) this.Major << 32 | (long) this.Minor).GetHashCode();

    public string GetFormattedVersion() => this.Major.ToString() + "." + (object) this.Minor;
  }
}
