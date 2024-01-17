// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.PlayerMovementAccsCache
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.DataStructures
{
  public struct PlayerMovementAccsCache
  {
    private bool _readyToPaste;
    private bool _mountPreventedFlight;
    private bool _mountPreventedExtraJumps;
    private int rocketTime;
    private float wingTime;
    private int rocketDelay;
    private int rocketDelay2;
    private bool jumpAgainCloud;
    private bool jumpAgainSandstorm;
    private bool jumpAgainBlizzard;
    private bool jumpAgainFart;
    private bool jumpAgainSail;
    private bool jumpAgainUnicorn;

    public void CopyFrom(Player player)
    {
      if (this._readyToPaste)
        return;
      this._readyToPaste = true;
      this._mountPreventedFlight = true;
      this._mountPreventedExtraJumps = player.mount.BlockExtraJumps;
      this.rocketTime = player.rocketTime;
      this.rocketDelay = player.rocketDelay;
      this.rocketDelay2 = player.rocketDelay2;
      this.wingTime = player.wingTime;
      this.jumpAgainCloud = player.canJumpAgain_Cloud;
      this.jumpAgainSandstorm = player.canJumpAgain_Sandstorm;
      this.jumpAgainBlizzard = player.canJumpAgain_Blizzard;
      this.jumpAgainFart = player.canJumpAgain_Fart;
      this.jumpAgainSail = player.canJumpAgain_Sail;
      this.jumpAgainUnicorn = player.canJumpAgain_Unicorn;
    }

    public void PasteInto(Player player)
    {
      if (!this._readyToPaste)
        return;
      this._readyToPaste = false;
      if (this._mountPreventedFlight)
      {
        player.rocketTime = this.rocketTime;
        player.rocketDelay = this.rocketDelay;
        player.rocketDelay2 = this.rocketDelay2;
        player.wingTime = this.wingTime;
      }
      if (!this._mountPreventedExtraJumps)
        return;
      player.canJumpAgain_Cloud = this.jumpAgainCloud;
      player.canJumpAgain_Sandstorm = this.jumpAgainSandstorm;
      player.canJumpAgain_Blizzard = this.jumpAgainBlizzard;
      player.canJumpAgain_Fart = this.jumpAgainFart;
      player.canJumpAgain_Sail = this.jumpAgainSail;
      player.canJumpAgain_Unicorn = this.jumpAgainUnicorn;
    }
  }
}
