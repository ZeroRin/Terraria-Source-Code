// Decompiled with JetBrains decompiler
// Type: Terraria.Cinematics.FrameEventData
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
