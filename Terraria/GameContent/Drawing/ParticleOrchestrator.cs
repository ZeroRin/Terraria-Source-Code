﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Drawing.ParticleOrchestrator
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.GameContent.NetModules;
using Terraria.Graphics.Renderers;
using Terraria.Graphics.Shaders;
using Terraria.Net;

namespace Terraria.GameContent.Drawing
{
  public class ParticleOrchestrator
  {
    private static ParticlePool<FadingParticle> _poolFading = new ParticlePool<FadingParticle>(200, new ParticlePool<FadingParticle>.ParticleInstantiator(ParticleOrchestrator.GetNewFadingParticle));
    private static ParticlePool<FlameParticle> _poolFlame = new ParticlePool<FlameParticle>(200, new ParticlePool<FlameParticle>.ParticleInstantiator(ParticleOrchestrator.GetNewFlameParticle));
    private static ParticlePool<RandomizedFrameParticle> _poolRandomizedFrame = new ParticlePool<RandomizedFrameParticle>(200, new ParticlePool<RandomizedFrameParticle>.ParticleInstantiator(ParticleOrchestrator.GetNewRandomizedFrameParticle));
    private static ParticlePool<PrettySparkleParticle> _poolPrettySparkle = new ParticlePool<PrettySparkleParticle>(200, new ParticlePool<PrettySparkleParticle>.ParticleInstantiator(ParticleOrchestrator.GetNewPrettySparkleParticle));

    public static void RequestParticleSpawn(
      bool clientOnly,
      ParticleOrchestraType type,
      ParticleOrchestraSettings settings,
      int? overrideInvokingPlayerIndex = null)
    {
      settings.IndexOfPlayerWhoInvokedThis = (byte) Main.myPlayer;
      if (overrideInvokingPlayerIndex.HasValue)
        settings.IndexOfPlayerWhoInvokedThis = (byte) overrideInvokingPlayerIndex.Value;
      if (clientOnly)
        ParticleOrchestrator.SpawnParticlesDirect(type, settings);
      else
        NetManager.Instance.SendToServerOrLoopback(NetParticlesModule.Serialize(type, settings));
    }

    private static FadingParticle GetNewFadingParticle() => new FadingParticle();

    private static FlameParticle GetNewFlameParticle() => new FlameParticle();

    private static RandomizedFrameParticle GetNewRandomizedFrameParticle() => new RandomizedFrameParticle();

    private static PrettySparkleParticle GetNewPrettySparkleParticle() => new PrettySparkleParticle();

    public static void SpawnParticlesDirect(
      ParticleOrchestraType type,
      ParticleOrchestraSettings settings)
    {
      if (Main.netMode == 2)
        return;
      switch (type)
      {
        case ParticleOrchestraType.Keybrand:
          ParticleOrchestrator.Spawn_Keybrand(settings);
          break;
        case ParticleOrchestraType.FlameWaders:
          ParticleOrchestrator.Spawn_FlameWaders(settings);
          break;
        case ParticleOrchestraType.StellarTune:
          ParticleOrchestrator.Spawn_StellarTune(settings);
          break;
        case ParticleOrchestraType.WallOfFleshGoatMountFlames:
          ParticleOrchestrator.Spawn_WallOfFleshGoatMountFlames(settings);
          break;
        case ParticleOrchestraType.BlackLightningHit:
          ParticleOrchestrator.Spawn_BlackLightningHit(settings);
          break;
        case ParticleOrchestraType.RainbowRodHit:
          ParticleOrchestrator.Spawn_RainbowRodHit(settings);
          break;
        case ParticleOrchestraType.BlackLightningSmall:
          ParticleOrchestrator.Spawn_BlackLightningSmall(settings);
          break;
        case ParticleOrchestraType.StardustPunch:
          ParticleOrchestrator.Spawn_StardustPunch(settings);
          break;
        case ParticleOrchestraType.PrincessWeapon:
          ParticleOrchestrator.Spawn_PrincessWeapon(settings);
          break;
      }
    }

    private static void Spawn_PrincessWeapon(ParticleOrchestraSettings settings)
    {
      float num1 = Main.rand.NextFloat() * 6.28318548f;
      float num2 = 1f;
      for (float num3 = 0.0f; (double) num3 < 1.0; num3 += 1f / num2)
      {
        Vector2 vector2_1 = settings.MovementVector * (float) (0.60000002384185791 + (double) Main.rand.NextFloat() * 0.34999999403953552);
        Vector2 vector2_2 = new Vector2((float) ((double) Main.rand.NextFloat() * 0.40000000596046448 + 0.20000000298023224));
        float f = num1 + Main.rand.NextFloat() * 6.28318548f;
        float num4 = 1.57079637f;
        Vector2 vector2_3 = 0.1f * vector2_2;
        float num5 = 60f;
        Vector2 vector2_4 = Main.rand.NextVector2Circular(8f, 8f) * vector2_2;
        PrettySparkleParticle prettySparkleParticle1 = ParticleOrchestrator._poolPrettySparkle.RequestParticle();
        prettySparkleParticle1.Velocity = f.ToRotationVector2() * vector2_3 + vector2_1;
        prettySparkleParticle1.AccelerationPerFrame = f.ToRotationVector2() * -(vector2_3 / num5) - vector2_1 * 1f / 30f;
        prettySparkleParticle1.AccelerationPerFrame = -vector2_1 * 1f / 60f;
        prettySparkleParticle1.Velocity = vector2_1 * 0.66f;
        prettySparkleParticle1.ColorTint = Main.hslToRgb((float) ((0.92000001668930054 + (double) Main.rand.NextFloat() * 0.019999999552965164) % 1.0), 1f, (float) (0.40000000596046448 + (double) Main.rand.NextFloat() * 0.25));
        prettySparkleParticle1.ColorTint.A = (byte) 0;
        prettySparkleParticle1.LocalPosition = settings.PositionInWorld + vector2_4;
        prettySparkleParticle1.Rotation = num4;
        prettySparkleParticle1.Scale = vector2_2;
        Main.ParticleSystem_World_OverPlayers.Add((IParticle) prettySparkleParticle1);
        PrettySparkleParticle prettySparkleParticle2 = ParticleOrchestrator._poolPrettySparkle.RequestParticle();
        prettySparkleParticle2.Velocity = f.ToRotationVector2() * vector2_3 + vector2_1;
        prettySparkleParticle2.AccelerationPerFrame = f.ToRotationVector2() * -(vector2_3 / num5) - vector2_1 * 1f / 15f;
        prettySparkleParticle2.AccelerationPerFrame = -vector2_1 * 1f / 60f;
        prettySparkleParticle2.Velocity = vector2_1 * 0.66f;
        prettySparkleParticle2.ColorTint = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0);
        prettySparkleParticle2.LocalPosition = settings.PositionInWorld + vector2_4;
        prettySparkleParticle2.Rotation = num4;
        prettySparkleParticle2.Scale = vector2_2 * 0.6f;
        Main.ParticleSystem_World_OverPlayers.Add((IParticle) prettySparkleParticle2);
      }
      for (int index = 0; index < 2; ++index)
      {
        Color rgb = Main.hslToRgb((float) ((0.92000001668930054 + (double) Main.rand.NextFloat() * 0.019999999552965164) % 1.0), 1f, (float) (0.40000000596046448 + (double) Main.rand.NextFloat() * 0.25));
        int dustIndex = Dust.NewDust(settings.PositionInWorld, 0, 0, 267, newColor: rgb);
        Main.dust[dustIndex].velocity = Main.rand.NextVector2Circular(2f, 2f);
        Main.dust[dustIndex].velocity += settings.MovementVector * (float) (0.5 + 0.5 * (double) Main.rand.NextFloat()) * 1.4f;
        Main.dust[dustIndex].noGravity = true;
        Main.dust[dustIndex].scale = 0.1f;
        Main.dust[dustIndex].position += Main.rand.NextVector2Circular(16f, 16f);
        Main.dust[dustIndex].velocity = settings.MovementVector;
        if (dustIndex != 6000)
        {
          Dust dust = Dust.CloneDust(dustIndex);
          dust.scale /= 2f;
          dust.fadeIn *= 0.75f;
          dust.color = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        }
      }
    }

    private static void Spawn_StardustPunch(ParticleOrchestraSettings settings)
    {
      float num1 = Main.rand.NextFloat() * 6.28318548f;
      float num2 = 1f;
      for (float num3 = 0.0f; (double) num3 < 1.0; num3 += 1f / num2)
      {
        Vector2 vector2_1 = settings.MovementVector * (float) (0.30000001192092896 + (double) Main.rand.NextFloat() * 0.34999999403953552);
        Vector2 vector2_2 = new Vector2((float) ((double) Main.rand.NextFloat() * 0.40000000596046448 + 0.40000000596046448));
        float f = num1 + Main.rand.NextFloat() * 6.28318548f;
        float num4 = 1.57079637f;
        Vector2 vector2_3 = 0.1f * vector2_2;
        float num5 = 60f;
        Vector2 vector2_4 = Main.rand.NextVector2Circular(8f, 8f) * vector2_2;
        PrettySparkleParticle prettySparkleParticle1 = ParticleOrchestrator._poolPrettySparkle.RequestParticle();
        prettySparkleParticle1.Velocity = f.ToRotationVector2() * vector2_3 + vector2_1;
        prettySparkleParticle1.AccelerationPerFrame = f.ToRotationVector2() * -(vector2_3 / num5) - vector2_1 * 1f / 60f;
        prettySparkleParticle1.ColorTint = Main.hslToRgb((float) ((0.60000002384185791 + (double) Main.rand.NextFloat() * 0.05000000074505806) % 1.0), 1f, (float) (0.40000000596046448 + (double) Main.rand.NextFloat() * 0.25));
        prettySparkleParticle1.ColorTint.A = (byte) 0;
        prettySparkleParticle1.LocalPosition = settings.PositionInWorld + vector2_4;
        prettySparkleParticle1.Rotation = num4;
        prettySparkleParticle1.Scale = vector2_2;
        Main.ParticleSystem_World_OverPlayers.Add((IParticle) prettySparkleParticle1);
        PrettySparkleParticle prettySparkleParticle2 = ParticleOrchestrator._poolPrettySparkle.RequestParticle();
        prettySparkleParticle2.Velocity = f.ToRotationVector2() * vector2_3 + vector2_1;
        prettySparkleParticle2.AccelerationPerFrame = f.ToRotationVector2() * -(vector2_3 / num5) - vector2_1 * 1f / 30f;
        prettySparkleParticle2.ColorTint = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0);
        prettySparkleParticle2.LocalPosition = settings.PositionInWorld + vector2_4;
        prettySparkleParticle2.Rotation = num4;
        prettySparkleParticle2.Scale = vector2_2 * 0.6f;
        Main.ParticleSystem_World_OverPlayers.Add((IParticle) prettySparkleParticle2);
      }
      for (int index = 0; index < 2; ++index)
      {
        Color rgb = Main.hslToRgb((float) ((0.5899999737739563 + (double) Main.rand.NextFloat() * 0.05000000074505806) % 1.0), 1f, (float) (0.40000000596046448 + (double) Main.rand.NextFloat() * 0.25));
        int dustIndex = Dust.NewDust(settings.PositionInWorld, 0, 0, 267, newColor: rgb);
        Main.dust[dustIndex].velocity = Main.rand.NextVector2Circular(2f, 2f);
        Main.dust[dustIndex].velocity += settings.MovementVector * (float) (0.5 + 0.5 * (double) Main.rand.NextFloat()) * 1.4f;
        Main.dust[dustIndex].noGravity = true;
        Main.dust[dustIndex].scale = (float) (0.60000002384185791 + (double) Main.rand.NextFloat() * 2.0);
        Main.dust[dustIndex].position += Main.rand.NextVector2Circular(16f, 16f);
        if (dustIndex != 6000)
        {
          Dust dust = Dust.CloneDust(dustIndex);
          dust.scale /= 2f;
          dust.fadeIn *= 0.75f;
          dust.color = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        }
      }
    }

    private static void Spawn_RainbowRodHit(ParticleOrchestraSettings settings)
    {
      float num1 = Main.rand.NextFloat() * 6.28318548f;
      float num2 = 6f;
      float num3 = Main.rand.NextFloat();
      for (float num4 = 0.0f; (double) num4 < 1.0; num4 += 1f / num2)
      {
        Vector2 vector2_1 = settings.MovementVector * Main.rand.NextFloatDirection() * 0.15f;
        Vector2 vector2_2 = new Vector2((float) ((double) Main.rand.NextFloat() * 0.40000000596046448 + 0.40000000596046448));
        float f = num1 + Main.rand.NextFloat() * 6.28318548f;
        float num5 = 1.57079637f;
        Vector2 vector2_3 = 1.5f * vector2_2;
        float num6 = 60f;
        Vector2 vector2_4 = Main.rand.NextVector2Circular(8f, 8f) * vector2_2;
        PrettySparkleParticle prettySparkleParticle1 = ParticleOrchestrator._poolPrettySparkle.RequestParticle();
        prettySparkleParticle1.Velocity = f.ToRotationVector2() * vector2_3 + vector2_1;
        prettySparkleParticle1.AccelerationPerFrame = f.ToRotationVector2() * -(vector2_3 / num6) - vector2_1 * 1f / 60f;
        prettySparkleParticle1.ColorTint = Main.hslToRgb((float) (((double) num3 + (double) Main.rand.NextFloat() * 0.33000001311302185) % 1.0), 1f, (float) (0.40000000596046448 + (double) Main.rand.NextFloat() * 0.25));
        prettySparkleParticle1.ColorTint.A = (byte) 0;
        prettySparkleParticle1.LocalPosition = settings.PositionInWorld + vector2_4;
        prettySparkleParticle1.Rotation = num5;
        prettySparkleParticle1.Scale = vector2_2;
        Main.ParticleSystem_World_OverPlayers.Add((IParticle) prettySparkleParticle1);
        PrettySparkleParticle prettySparkleParticle2 = ParticleOrchestrator._poolPrettySparkle.RequestParticle();
        prettySparkleParticle2.Velocity = f.ToRotationVector2() * vector2_3 + vector2_1;
        prettySparkleParticle2.AccelerationPerFrame = f.ToRotationVector2() * -(vector2_3 / num6) - vector2_1 * 1f / 60f;
        prettySparkleParticle2.ColorTint = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, 0);
        prettySparkleParticle2.LocalPosition = settings.PositionInWorld + vector2_4;
        prettySparkleParticle2.Rotation = num5;
        prettySparkleParticle2.Scale = vector2_2 * 0.6f;
        Main.ParticleSystem_World_OverPlayers.Add((IParticle) prettySparkleParticle2);
      }
      for (int index = 0; index < 12; ++index)
      {
        Color rgb = Main.hslToRgb((float) (((double) num3 + (double) Main.rand.NextFloat() * 0.11999999731779099) % 1.0), 1f, (float) (0.40000000596046448 + (double) Main.rand.NextFloat() * 0.25));
        int dustIndex = Dust.NewDust(settings.PositionInWorld, 0, 0, 267, newColor: rgb);
        Main.dust[dustIndex].velocity = Main.rand.NextVector2Circular(1f, 1f);
        Main.dust[dustIndex].velocity += settings.MovementVector * Main.rand.NextFloatDirection() * 0.5f;
        Main.dust[dustIndex].noGravity = true;
        Main.dust[dustIndex].scale = (float) (0.60000002384185791 + (double) Main.rand.NextFloat() * 0.89999997615814209);
        Main.dust[dustIndex].fadeIn = (float) (0.699999988079071 + (double) Main.rand.NextFloat() * 0.800000011920929);
        if (dustIndex != 6000)
        {
          Dust dust = Dust.CloneDust(dustIndex);
          dust.scale /= 2f;
          dust.fadeIn *= 0.75f;
          dust.color = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
        }
      }
    }

    private static void Spawn_BlackLightningSmall(ParticleOrchestraSettings settings)
    {
      float num1 = Main.rand.NextFloat() * 6.28318548f;
      float num2 = (float) Main.rand.Next(1, 3);
      float num3 = 0.7f;
      int i = 916;
      Main.instance.LoadProjectile(i);
      Color color1 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color indigo = Color.Indigo with { A = 0 };
      for (float num4 = 0.0f; (double) num4 < 1.0; num4 += 1f / num2)
      {
        float f = (float) (6.2831854820251465 * (double) num4 + (double) num1 + (double) Main.rand.NextFloatDirection() * 0.25);
        float num5 = (float) ((double) Main.rand.NextFloat() * 4.0 + 0.10000000149011612);
        Vector2 initialLocalPosition = Main.rand.NextVector2Circular(12f, 12f) * num3;
        Color.Lerp(Color.Lerp(Color.Black, indigo, Main.rand.NextFloat() * 0.5f), color1, Main.rand.NextFloat() * 0.6f);
        Color color2 = new Color(0, 0, 0, (int) byte.MaxValue);
        int num6 = Main.rand.Next(4);
        if (num6 == 1)
          color2 = Color.Lerp(new Color(106, 90, 205, (int) sbyte.MaxValue), Color.Black, (float) (0.10000000149011612 + 0.699999988079071 * (double) Main.rand.NextFloat()));
        if (num6 == 2)
          color2 = Color.Lerp(new Color(106, 90, 205, 60), Color.Black, (float) (0.10000000149011612 + 0.800000011920929 * (double) Main.rand.NextFloat()));
        RandomizedFrameParticle randomizedFrameParticle = ParticleOrchestrator._poolRandomizedFrame.RequestParticle();
        randomizedFrameParticle.SetBasicInfo(TextureAssets.Projectile[i], new Rectangle?(), Vector2.Zero, initialLocalPosition);
        randomizedFrameParticle.SetTypeInfo(Main.projFrames[i], 2, 24f);
        randomizedFrameParticle.Velocity = f.ToRotationVector2() * num5 * new Vector2(1f, 0.5f) * 0.2f + settings.MovementVector;
        randomizedFrameParticle.ColorTint = color2;
        randomizedFrameParticle.LocalPosition = settings.PositionInWorld + initialLocalPosition;
        randomizedFrameParticle.Rotation = randomizedFrameParticle.Velocity.ToRotation();
        randomizedFrameParticle.Scale = Vector2.One * 0.5f;
        randomizedFrameParticle.FadeInNormalizedTime = 0.01f;
        randomizedFrameParticle.FadeOutNormalizedTime = 0.5f;
        randomizedFrameParticle.ScaleVelocity = new Vector2(0.025f);
        Main.ParticleSystem_World_OverPlayers.Add((IParticle) randomizedFrameParticle);
      }
    }

    private static void Spawn_BlackLightningHit(ParticleOrchestraSettings settings)
    {
      float num1 = Main.rand.NextFloat() * 6.28318548f;
      float num2 = 7f;
      float num3 = 0.7f;
      int i = 916;
      Main.instance.LoadProjectile(i);
      Color color1 = new Color((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      Color indigo = Color.Indigo with { A = 0 };
      for (float num4 = 0.0f; (double) num4 < 1.0; num4 += 1f / num2)
      {
        float f = (float) (6.2831854820251465 * (double) num4 + (double) num1 + (double) Main.rand.NextFloatDirection() * 0.25);
        float num5 = (float) ((double) Main.rand.NextFloat() * 4.0 + 0.10000000149011612);
        Vector2 initialLocalPosition = Main.rand.NextVector2Circular(12f, 12f) * num3;
        Color.Lerp(Color.Lerp(Color.Black, indigo, Main.rand.NextFloat() * 0.5f), color1, Main.rand.NextFloat() * 0.6f);
        Color color2 = new Color(0, 0, 0, (int) byte.MaxValue);
        int num6 = Main.rand.Next(4);
        if (num6 == 1)
          color2 = Color.Lerp(new Color(106, 90, 205, (int) sbyte.MaxValue), Color.Black, (float) (0.10000000149011612 + 0.699999988079071 * (double) Main.rand.NextFloat()));
        if (num6 == 2)
          color2 = Color.Lerp(new Color(106, 90, 205, 60), Color.Black, (float) (0.10000000149011612 + 0.800000011920929 * (double) Main.rand.NextFloat()));
        RandomizedFrameParticle randomizedFrameParticle = ParticleOrchestrator._poolRandomizedFrame.RequestParticle();
        randomizedFrameParticle.SetBasicInfo(TextureAssets.Projectile[i], new Rectangle?(), Vector2.Zero, initialLocalPosition);
        randomizedFrameParticle.SetTypeInfo(Main.projFrames[i], 2, 24f);
        randomizedFrameParticle.Velocity = f.ToRotationVector2() * num5 * new Vector2(1f, 0.5f);
        randomizedFrameParticle.ColorTint = color2;
        randomizedFrameParticle.LocalPosition = settings.PositionInWorld + initialLocalPosition;
        randomizedFrameParticle.Rotation = f;
        randomizedFrameParticle.Scale = Vector2.One;
        randomizedFrameParticle.FadeInNormalizedTime = 0.01f;
        randomizedFrameParticle.FadeOutNormalizedTime = 0.5f;
        randomizedFrameParticle.ScaleVelocity = new Vector2(0.05f);
        Main.ParticleSystem_World_OverPlayers.Add((IParticle) randomizedFrameParticle);
      }
    }

    private static void Spawn_StellarTune(ParticleOrchestraSettings settings)
    {
      float num1 = Main.rand.NextFloat() * 6.28318548f;
      float num2 = 5f;
      Vector2 vector2_1 = new Vector2(0.7f);
      for (float num3 = 0.0f; (double) num3 < 1.0; num3 += 1f / num2)
      {
        float f = (float) (6.2831854820251465 * (double) num3 + (double) num1 + (double) Main.rand.NextFloatDirection() * 0.25);
        Vector2 vector2_2 = 1.5f * vector2_1;
        float num4 = 60f;
        Vector2 vector2_3 = Main.rand.NextVector2Circular(12f, 12f) * vector2_1;
        Color color = Color.Lerp(Color.Gold, Color.HotPink, Main.rand.NextFloat());
        if (Main.rand.Next(2) == 0)
          color = Color.Lerp(Color.Violet, Color.HotPink, Main.rand.NextFloat());
        PrettySparkleParticle prettySparkleParticle = ParticleOrchestrator._poolPrettySparkle.RequestParticle();
        prettySparkleParticle.Velocity = f.ToRotationVector2() * vector2_2;
        prettySparkleParticle.AccelerationPerFrame = f.ToRotationVector2() * -(vector2_2 / num4);
        prettySparkleParticle.ColorTint = color;
        prettySparkleParticle.LocalPosition = settings.PositionInWorld + vector2_3;
        prettySparkleParticle.Rotation = f;
        prettySparkleParticle.Scale = vector2_1 * (float) ((double) Main.rand.NextFloat() * 0.800000011920929 + 0.20000000298023224);
        Main.ParticleSystem_World_OverPlayers.Add((IParticle) prettySparkleParticle);
      }
    }

    private static void Spawn_Keybrand(ParticleOrchestraSettings settings)
    {
      float num1 = Main.rand.NextFloat() * 6.28318548f;
      float num2 = 3f;
      Vector2 vector2_1 = new Vector2(0.7f);
      for (float num3 = 0.0f; (double) num3 < 1.0; num3 += 1f / num2)
      {
        float f = (float) (6.2831854820251465 * (double) num3 + (double) num1 + (double) Main.rand.NextFloatDirection() * 0.10000000149011612);
        Vector2 vector2_2 = 1.5f * vector2_1;
        float num4 = 60f;
        Vector2 vector2_3 = Main.rand.NextVector2Circular(4f, 4f) * vector2_1;
        PrettySparkleParticle prettySparkleParticle = ParticleOrchestrator._poolPrettySparkle.RequestParticle();
        prettySparkleParticle.Velocity = f.ToRotationVector2() * vector2_2;
        prettySparkleParticle.AccelerationPerFrame = f.ToRotationVector2() * -(vector2_2 / num4);
        prettySparkleParticle.ColorTint = Color.Lerp(Color.Gold, Color.OrangeRed, Main.rand.NextFloat());
        prettySparkleParticle.LocalPosition = settings.PositionInWorld + vector2_3;
        prettySparkleParticle.Rotation = f;
        prettySparkleParticle.Scale = vector2_1 * 0.8f;
        Main.ParticleSystem_World_OverPlayers.Add((IParticle) prettySparkleParticle);
      }
      float num5 = num1 + (float) (1.0 / (double) num2 / 2.0 * 6.2831854820251465);
      float num6 = Main.rand.NextFloat() * 6.28318548f;
      for (float num7 = 0.0f; (double) num7 < 1.0; num7 += 1f / num2)
      {
        float f = (float) (6.2831854820251465 * (double) num7 + (double) num6 + (double) Main.rand.NextFloatDirection() * 0.10000000149011612);
        Vector2 vector2_4 = 1f * vector2_1;
        float timeToLive = 30f;
        Color color = Color.Lerp(Color.White, Color.Lerp(Color.Gold, Color.OrangeRed, Main.rand.NextFloat()), 0.5f) with
        {
          A = 0
        };
        Vector2 vector2_5 = Main.rand.NextVector2Circular(4f, 4f) * vector2_1;
        FadingParticle fadingParticle = ParticleOrchestrator._poolFading.RequestParticle();
        fadingParticle.SetBasicInfo(TextureAssets.Extra[98], new Rectangle?(), Vector2.Zero, Vector2.Zero);
        fadingParticle.SetTypeInfo(timeToLive);
        fadingParticle.Velocity = f.ToRotationVector2() * vector2_4;
        fadingParticle.AccelerationPerFrame = f.ToRotationVector2() * -(vector2_4 / timeToLive);
        fadingParticle.ColorTint = color;
        fadingParticle.LocalPosition = settings.PositionInWorld + f.ToRotationVector2() * vector2_4 * vector2_1 * timeToLive * 0.2f + vector2_5;
        fadingParticle.Rotation = f + 1.57079637f;
        fadingParticle.FadeInNormalizedTime = 0.3f;
        fadingParticle.FadeOutNormalizedTime = 0.4f;
        fadingParticle.Scale = new Vector2(0.5f, 1.2f) * 0.8f * vector2_1;
        Main.ParticleSystem_World_OverPlayers.Add((IParticle) fadingParticle);
      }
      float num8 = 1f;
      float num9 = Main.rand.NextFloat() * 6.28318548f;
      for (float num10 = 0.0f; (double) num10 < 1.0; num10 += 1f / num8)
      {
        float num11 = 6.28318548f * num10 + num9;
        float timeToLive = 30f;
        Color color = Color.Lerp(Color.CornflowerBlue, Color.White, Main.rand.NextFloat()) with
        {
          A = 127
        };
        Vector2 vector2_6 = Main.rand.NextVector2Circular(4f, 4f) * vector2_1;
        Vector2 vector2_7 = Main.rand.NextVector2Square(0.7f, 1.3f);
        FadingParticle fadingParticle = ParticleOrchestrator._poolFading.RequestParticle();
        fadingParticle.SetBasicInfo(TextureAssets.Extra[174], new Rectangle?(), Vector2.Zero, Vector2.Zero);
        fadingParticle.SetTypeInfo(timeToLive);
        fadingParticle.ColorTint = color;
        fadingParticle.LocalPosition = settings.PositionInWorld + vector2_6;
        fadingParticle.Rotation = num11 + 1.57079637f;
        fadingParticle.FadeInNormalizedTime = 0.1f;
        fadingParticle.FadeOutNormalizedTime = 0.4f;
        fadingParticle.Scale = new Vector2(0.1f, 0.1f) * vector2_1;
        fadingParticle.ScaleVelocity = vector2_7 * 1f / 60f;
        fadingParticle.ScaleAcceleration = vector2_7 * -0.0166666675f / 60f;
        Main.ParticleSystem_World_OverPlayers.Add((IParticle) fadingParticle);
      }
    }

    private static void Spawn_FlameWaders(ParticleOrchestraSettings settings)
    {
      float timeToLive = 60f;
      for (int index = -1; index <= 1; ++index)
      {
        int i = (int) Main.rand.NextFromList<short>((short) 326, (short) 327, (short) 328);
        Main.instance.LoadProjectile(i);
        Player player = Main.player[(int) settings.IndexOfPlayerWhoInvokedThis];
        float num = (float) ((double) Main.rand.NextFloat() * 0.89999997615814209 + 0.10000000149011612);
        Vector2 vector2 = settings.PositionInWorld + new Vector2((float) index * 5.33333349f, 0.0f);
        FlameParticle flameParticle = ParticleOrchestrator._poolFlame.RequestParticle();
        flameParticle.SetBasicInfo(TextureAssets.Projectile[i], new Rectangle?(), Vector2.Zero, vector2);
        flameParticle.SetTypeInfo(timeToLive, (int) settings.IndexOfPlayerWhoInvokedThis, player.cShoe);
        flameParticle.FadeOutNormalizedTime = 0.4f;
        flameParticle.ScaleAcceleration = Vector2.One * num * -0.0166666675f / timeToLive;
        flameParticle.Scale = Vector2.One * num;
        Main.ParticleSystem_World_BehindPlayers.Add((IParticle) flameParticle);
        if (Main.rand.Next(16) == 0)
        {
          Dust dust = Dust.NewDustDirect(vector2, 4, 4, 6, Alpha: 100);
          if (Main.rand.Next(2) == 0)
          {
            dust.noGravity = true;
            dust.fadeIn = 1.15f;
          }
          else
            dust.scale = 0.6f;
          dust.velocity *= 0.6f;
          dust.velocity.Y -= 1.2f;
          dust.noLight = true;
          dust.position.Y -= 4f;
          dust.shader = GameShaders.Armor.GetSecondaryShader(player.cShoe, player);
        }
      }
    }

    private static void Spawn_WallOfFleshGoatMountFlames(ParticleOrchestraSettings settings)
    {
      float timeToLive = 50f;
      for (int index = -1; index <= 1; ++index)
      {
        int i = (int) Main.rand.NextFromList<short>((short) 326, (short) 327, (short) 328);
        Main.instance.LoadProjectile(i);
        Player player = Main.player[(int) settings.IndexOfPlayerWhoInvokedThis];
        float num = (float) ((double) Main.rand.NextFloat() * 0.89999997615814209 + 0.10000000149011612);
        Vector2 vector2 = settings.PositionInWorld + new Vector2((float) index * 5.33333349f, 0.0f);
        FlameParticle flameParticle = ParticleOrchestrator._poolFlame.RequestParticle();
        flameParticle.SetBasicInfo(TextureAssets.Projectile[i], new Rectangle?(), Vector2.Zero, vector2);
        flameParticle.SetTypeInfo(timeToLive, (int) settings.IndexOfPlayerWhoInvokedThis, player.cMount);
        flameParticle.FadeOutNormalizedTime = 0.3f;
        flameParticle.ScaleAcceleration = Vector2.One * num * -0.0166666675f / timeToLive;
        flameParticle.Scale = Vector2.One * num;
        Main.ParticleSystem_World_BehindPlayers.Add((IParticle) flameParticle);
        if (Main.rand.Next(8) == 0)
        {
          Dust dust = Dust.NewDustDirect(vector2, 4, 4, 6, Alpha: 100);
          if (Main.rand.Next(2) == 0)
          {
            dust.noGravity = true;
            dust.fadeIn = 1.15f;
          }
          else
            dust.scale = 0.6f;
          dust.velocity *= 0.6f;
          dust.velocity.Y -= 1.2f;
          dust.noLight = true;
          dust.position.Y -= 4f;
          dust.shader = GameShaders.Armor.GetSecondaryShader(player.cMount, player);
        }
      }
    }
  }
}
