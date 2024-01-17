// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenerationProgress
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

namespace Terraria.WorldBuilding
{
  public class GenerationProgress
  {
    private string _message = "";
    private float _value;
    private float _totalProgress;
    public float TotalWeight;
    public float CurrentPassWeight = 1f;

    public string Message
    {
      get => string.Format(this._message, (object) this.Value);
      set => this._message = value.Replace("%", "{0:0.0%}");
    }

    public float Value
    {
      set => this._value = Utils.Clamp<float>(value, 0.0f, 1f);
      get => this._value;
    }

    public float TotalProgress => (double) this.TotalWeight == 0.0 ? 0.0f : (this.Value * this.CurrentPassWeight + this._totalProgress) / this.TotalWeight;

    public void Set(float value) => this.Value = value;

    public void Start(float weight)
    {
      this.CurrentPassWeight = weight;
      this._value = 0.0f;
    }

    public void End()
    {
      this._totalProgress += this.CurrentPassWeight;
      this._value = 0.0f;
    }
  }
}
