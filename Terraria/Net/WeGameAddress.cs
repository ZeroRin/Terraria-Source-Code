// Decompiled with JetBrains decompiler
// Type: Terraria.Net.WeGameAddress
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using rail;

namespace Terraria.Net
{
  public class WeGameAddress : RemoteAddress
  {
    public readonly RailID rail_id;
    private string nickname;

    public WeGameAddress(RailID id, string name)
    {
      this.Type = AddressType.WeGame;
      this.rail_id = id;
      this.nickname = name;
    }

    public override string ToString() => "WEGAME_0:" + ((RailComparableID) this.rail_id).id_.ToString();

    public override string GetIdentifier() => this.ToString();

    public override bool IsLocalHost() => Program.LaunchParameters.ContainsKey("-localwegameid") && Program.LaunchParameters["-localwegameid"].Equals(((RailComparableID) this.rail_id).id_.ToString());

    public override string GetFriendlyName() => this.nickname;
  }
}
