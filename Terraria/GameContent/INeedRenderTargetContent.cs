﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.INeedRenderTargetContent
// Assembly: Terraria, Version=1.4.0.5, Culture=neutral, PublicKeyToken=null
// MVID: 67F9E73E-0A81-4937-A22C-5515CD405A83
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework.Graphics;

namespace Terraria.GameContent
{
  public interface INeedRenderTargetContent
  {
    bool IsReady { get; }

    void PrepareRenderTarget(GraphicsDevice device, SpriteBatch spriteBatch);
  }
}