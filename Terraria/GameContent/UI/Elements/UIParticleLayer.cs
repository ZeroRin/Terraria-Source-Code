// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.UI.Elements.UIParticleLayer
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Renderers;
using Terraria.UI;

namespace Terraria.GameContent.UI.Elements
{
  public class UIParticleLayer : UIElement
  {
    public ParticleRenderer ParticleSystem;
    public Vector2 AnchorPositionOffsetByPercents;
    public Vector2 AnchorPositionOffsetByPixels;

    public UIParticleLayer()
    {
      this.IgnoresMouseInteraction = true;
      this.ParticleSystem = new ParticleRenderer();
      this.OnUpdate += new UIElement.ElementEvent(this.ParticleSystemUpdate);
    }

    private void ParticleSystemUpdate(UIElement affectedElement) => this.ParticleSystem.Update();

    public override void Recalculate()
    {
      base.Recalculate();
      Rectangle rectangle = this.GetDimensions().ToRectangle();
      this.ParticleSystem.Settings.AnchorPosition = rectangle.TopLeft() + this.AnchorPositionOffsetByPercents * rectangle.Size() + this.AnchorPositionOffsetByPixels;
    }

    protected override void DrawSelf(SpriteBatch spriteBatch) => this.ParticleSystem.Draw(spriteBatch);

    public void AddParticle(IParticle particle) => this.ParticleSystem.Add(particle);
  }
}
