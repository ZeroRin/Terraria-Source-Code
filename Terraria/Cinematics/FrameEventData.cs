﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Cinematics.FrameEventData
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.Cinematics
{
  public struct FrameEventData
  {
    private int _absoluteFrame;
    private int _start;
    private int _duration;

    public int AbsoluteFrame => this._absoluteFrame;

    public int Start => this._start;

    public int Duration => this._duration;

    public int Frame => this._absoluteFrame - this._start;

    public bool IsFirstFrame => this._start == this._absoluteFrame;

    public bool IsLastFrame => this.Remaining == 0;

    public int Remaining => this._start + this._duration - this._absoluteFrame - 1;

    public FrameEventData(int absoluteFrame, int start, int duration)
    {
      this._absoluteFrame = absoluteFrame;
      this._start = start;
      this._duration = duration;
    }
  }
}
