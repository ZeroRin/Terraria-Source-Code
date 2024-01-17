// Decompiled with JetBrains decompiler
// Type: Terraria.IO.GameConfiguration
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Newtonsoft.Json.Linq;

namespace Terraria.IO
{
  public class GameConfiguration
  {
    private readonly JObject _root;

    public GameConfiguration(JObject configurationRoot) => this._root = configurationRoot;

    public T Get<T>(string entry) => this._root[entry].ToObject<T>();
  }
}
