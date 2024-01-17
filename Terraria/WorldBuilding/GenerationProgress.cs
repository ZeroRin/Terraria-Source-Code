﻿// Decompiled with JetBrains decompiler
// Type: Terraria.WorldBuilding.GenerationProgress
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
