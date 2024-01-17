// Decompiled with JetBrains decompiler
// Type: Terraria.Graphics.Effects.CustomSky
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Terraria.Graphics.Effects
{
  public abstract class CustomSky : GameEffect
  {
    public abstract void Update(GameTime gameTime);

    public abstract void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth);

    public abstract bool IsActive();

    public abstract void Reset();

    public virtual Color OnTileColor(Color inColor) => inColor;

    public virtual float GetCloudAlpha() => 1f;

    public override bool IsVisible() => true;
  }
}
