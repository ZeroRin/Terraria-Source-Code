// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Shaders.ArmorShaderDataSet
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;
using Terraria.DataStructures;

namespace Terraria.Graphics.Shaders
{
  public class ArmorShaderDataSet
  {
    protected List<ArmorShaderData> _shaderData = new List<ArmorShaderData>();
    protected Dictionary<int, int> _shaderLookupDictionary = new Dictionary<int, int>();
    protected int _shaderDataCount;

    public T BindShader<T>(int itemId, T shaderData) where T : ArmorShaderData
    {
      this._shaderLookupDictionary[itemId] = ++this._shaderDataCount;
      this._shaderData.Add((ArmorShaderData) shaderData);
      return shaderData;
    }

    public void Apply(int shaderId, Entity entity, DrawData? drawData = null)
    {
      if (shaderId >= 1 && shaderId <= this._shaderDataCount)
        this._shaderData[shaderId - 1].Apply(entity, drawData);
      else
        Main.pixelShader.CurrentTechnique.Passes[0].Apply();
    }

    public void ApplySecondary(int shaderId, Entity entity, DrawData? drawData = null)
    {
      if (shaderId >= 1 && shaderId <= this._shaderDataCount)
        this._shaderData[shaderId - 1].GetSecondaryShader(entity).Apply(entity, drawData);
      else
        Main.pixelShader.CurrentTechnique.Passes[0].Apply();
    }

    public ArmorShaderData GetShaderFromItemId(int type) => this._shaderLookupDictionary.ContainsKey(type) ? this._shaderData[this._shaderLookupDictionary[type] - 1] : (ArmorShaderData) null;

    public int GetShaderIdFromItemId(int type) => this._shaderLookupDictionary.ContainsKey(type) ? this._shaderLookupDictionary[type] : 0;

    public ArmorShaderData GetSecondaryShader(int id, Player player) => id != 0 && id <= this._shaderDataCount && this._shaderData[id - 1] != null ? this._shaderData[id - 1].GetSecondaryShader((Entity) player) : (ArmorShaderData) null;
  }
}
