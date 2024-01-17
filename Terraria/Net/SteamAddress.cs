// Decompiled with JetBrains decompiler
// Type: Terraria.Net.SteamAddress
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Steamworks;

namespace Terraria.Net
{
  public class SteamAddress : RemoteAddress
  {
    public readonly CSteamID SteamId;
    private string _friendlyName;

    public SteamAddress(CSteamID steamId)
    {
      this.Type = AddressType.Steam;
      this.SteamId = steamId;
    }

    public override string ToString() => "STEAM_0:" + (this.SteamId.m_SteamID % 2UL).ToString() + ":" + ((this.SteamId.m_SteamID - (76561197960265728UL + this.SteamId.m_SteamID % 2UL)) / 2UL).ToString();

    public override string GetIdentifier() => this.ToString();

    public override bool IsLocalHost() => Program.LaunchParameters.ContainsKey("-localsteamid") && Program.LaunchParameters["-localsteamid"].Equals(this.SteamId.m_SteamID.ToString());

    public override string GetFriendlyName()
    {
      if (this._friendlyName == null)
        this._friendlyName = SteamFriends.GetFriendPersonaName(this.SteamId);
      return this._friendlyName;
    }
  }
}
