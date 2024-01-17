// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Capture.CaptureSettings
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System;

namespace Terraria.Graphics.Capture
{
  public class CaptureSettings
  {
    public Rectangle Area;
    public bool UseScaling = true;
    public string OutputName;
    public bool CaptureEntities = true;
    public CaptureBiome Biome = CaptureBiome.DefaultPurity;
    public bool CaptureMech;
    public bool CaptureBackground;

    public CaptureSettings()
    {
      DateTime localTime = DateTime.Now.ToLocalTime();
      this.OutputName = "Capture " + localTime.Year.ToString("D4") + "-" + localTime.Month.ToString("D2") + "-" + localTime.Day.ToString("D2") + " " + localTime.Hour.ToString("D2") + "_" + localTime.Minute.ToString("D2") + "_" + localTime.Second.ToString("D2");
    }
  }
}
