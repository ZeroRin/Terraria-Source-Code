﻿// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.WorldGenerator
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;
using System.Diagnostics;
using Terraria.Utilities;

namespace Terraria.WorldBuilding
{
  public class WorldGenerator
  {
    private readonly List<GenPass> _passes = new List<GenPass>();
    private float _totalLoadWeight;
    private readonly int _seed;
    private readonly WorldGenConfiguration _configuration;
    public static GenerationProgress CurrentGenerationProgress;

    public WorldGenerator(int seed, WorldGenConfiguration configuration)
    {
      this._seed = seed;
      this._configuration = configuration;
    }

    public void Append(GenPass pass)
    {
      this._passes.Add(pass);
      this._totalLoadWeight += pass.Weight;
    }

    public void GenerateWorld(GenerationProgress progress = null)
    {
      Stopwatch stopwatch = new Stopwatch();
      float num = 0.0f;
      foreach (GenPass pass in this._passes)
        num += pass.Weight;
      if (progress == null)
        progress = new GenerationProgress();
      WorldGenerator.CurrentGenerationProgress = progress;
      progress.TotalWeight = num;
      foreach (GenPass pass in this._passes)
      {
        WorldGen._genRand = new UnifiedRandom(this._seed);
        Main.rand = new UnifiedRandom(this._seed);
        stopwatch.Start();
        progress.Start(pass.Weight);
        pass.Apply(progress, this._configuration.GetPassConfiguration(pass.Name));
        progress.End();
        stopwatch.Reset();
      }
      WorldGenerator.CurrentGenerationProgress = (GenerationProgress) null;
    }
  }
}
