﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Metadata.TileGolfPhysics
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Newtonsoft.Json;

namespace Terraria.GameContent.Metadata
{
  public class TileGolfPhysics
  {
    [JsonProperty]
    public float DirectImpactDampening { get; private set; }

    [JsonProperty]
    public float SideImpactDampening { get; private set; }

    [JsonProperty]
    public float ClubImpactDampening { get; private set; }

    [JsonProperty]
    public float PassThroughDampening { get; private set; }

    [JsonProperty]
    public float ImpactDampeningResistanceEfficiency { get; private set; }
  }
}
