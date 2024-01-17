// Decompiled with JetBrains decompiler
// Type: Terraria.GameInput.TriggersPack
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Linq;

namespace Terraria.GameInput
{
  public class TriggersPack
  {
    public TriggersSet Current = new TriggersSet();
    public TriggersSet Old = new TriggersSet();
    public TriggersSet JustPressed = new TriggersSet();
    public TriggersSet JustReleased = new TriggersSet();

    public void Initialize()
    {
      this.Current.SetupKeys();
      this.Old.SetupKeys();
      this.JustPressed.SetupKeys();
      this.JustReleased.SetupKeys();
    }

    public void Reset()
    {
      this.Old = this.Current.Clone();
      this.Current.Reset();
    }

    public void Update()
    {
      this.CompareDiffs(this.JustPressed, this.Old, this.Current);
      this.CompareDiffs(this.JustReleased, this.Current, this.Old);
    }

    public void CompareDiffs(TriggersSet Bearer, TriggersSet oldset, TriggersSet newset)
    {
      Bearer.Reset();
      foreach (string key in Bearer.KeyStatus.Keys.ToList<string>())
        Bearer.KeyStatus[key] = newset.KeyStatus[key] && !oldset.KeyStatus[key];
    }
  }
}
