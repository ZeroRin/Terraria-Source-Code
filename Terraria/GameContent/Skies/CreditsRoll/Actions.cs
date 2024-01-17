﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.Skies.CreditsRoll.Actions
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;

namespace Terraria.GameContent.Skies.CreditsRoll
{
  public class Actions
  {
    public class Players
    {
      public interface IPlayerAction : ICreditsRollSegmentAction<Player>
      {
      }

      public class Fade : Actions.Players.IPlayerAction, ICreditsRollSegmentAction<Player>
      {
        private int _duration;
        private float _opacityTarget;
        private float _delay;

        public Fade(float opacityTarget)
        {
          this._duration = 0;
          this._opacityTarget = opacityTarget;
        }

        public Fade(float opacityTarget, int duration)
        {
          this._duration = duration;
          this._opacityTarget = opacityTarget;
        }

        public void BindTo(Player obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(Player obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          if (this._duration == 0)
          {
            obj.opacityForCreditsRoll = this._opacityTarget;
          }
          else
          {
            float t = localTimeForObj - this._delay;
            if ((double) t > (double) this._duration)
              t = (float) this._duration;
            obj.opacityForCreditsRoll = MathHelper.Lerp(obj.opacityForCreditsRoll, this._opacityTarget, Utils.GetLerpValue(0.0f, (float) this._duration, t, true));
          }
        }
      }

      public class Wait : Actions.Players.IPlayerAction, ICreditsRollSegmentAction<Player>
      {
        private int _duration;
        private float _delay;

        public Wait(int durationInFrames) => this._duration = durationInFrames;

        public void BindTo(Player obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void ApplyTo(Player obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          obj.velocity = Vector2.Zero;
        }

        public void SetDelay(float delay) => this._delay = delay;
      }

      public class LookAt : Actions.Players.IPlayerAction, ICreditsRollSegmentAction<Player>
      {
        private int _direction;
        private float _delay;

        public LookAt(int direction) => this._direction = direction;

        public void BindTo(Player obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => 0;

        public void ApplyTo(Player obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          obj.direction = this._direction;
        }

        public void SetDelay(float delay) => this._delay = delay;
      }

      public class MoveWithAcceleration : 
        Actions.Players.IPlayerAction,
        ICreditsRollSegmentAction<Player>
      {
        private Vector2 _offsetPerFrame;
        private Vector2 _accelerationPerFrame;
        private int _duration;
        private float _delay;

        public MoveWithAcceleration(
          Vector2 offsetPerFrame,
          Vector2 accelerationPerFrame,
          int durationInFrames)
        {
          this._accelerationPerFrame = accelerationPerFrame;
          this._offsetPerFrame = offsetPerFrame;
          this._duration = durationInFrames;
        }

        public void BindTo(Player obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(Player obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          float num = localTimeForObj - this._delay;
          if ((double) num > (double) this._duration)
            num = (float) this._duration;
          Vector2 vector2 = this._offsetPerFrame * num + this._accelerationPerFrame * (float) ((double) num * (double) num * 0.5);
          Player player = obj;
          player.position = player.position + vector2;
          obj.velocity = this._offsetPerFrame + this._accelerationPerFrame * num;
          if ((double) this._offsetPerFrame.X == 0.0)
            return;
          obj.direction = (double) this._offsetPerFrame.X > 0.0 ? 1 : -1;
        }
      }
    }

    public class NPCs
    {
      public interface INPCAction : ICreditsRollSegmentAction<NPC>
      {
      }

      public class Fade : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private int _duration;
        private int _alphaPerFrame;
        private float _delay;

        public Fade(int alphaPerFrame)
        {
          this._duration = 0;
          this._alphaPerFrame = alphaPerFrame;
        }

        public Fade(int alphaPerFrame, int duration)
        {
          this._duration = duration;
          this._alphaPerFrame = alphaPerFrame;
        }

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          if (this._duration == 0)
          {
            obj.alpha = Utils.Clamp<int>(obj.alpha + this._alphaPerFrame, 0, (int) byte.MaxValue);
          }
          else
          {
            float num = localTimeForObj - this._delay;
            if ((double) num > (double) this._duration)
              num = (float) this._duration;
            obj.alpha = Utils.Clamp<int>(obj.alpha + (int) num * this._alphaPerFrame, 0, (int) byte.MaxValue);
          }
        }
      }

      public class ShowItem : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private int _itemIdToShow;
        private int _duration;
        private float _delay;

        public ShowItem(int durationInFrames, int itemIdToShow)
        {
          this._duration = durationInFrames;
          this._itemIdToShow = itemIdToShow;
        }

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          float num = localTimeForObj - this._delay;
          if ((double) num > (double) this._duration)
          {
            this.FixNPCIfWasHoldingItem(obj);
          }
          else
          {
            obj.velocity = Vector2.Zero;
            obj.frameCounter = (double) num;
            obj.ai[0] = 23f;
            obj.ai[1] = (float) this._duration - num;
            obj.ai[2] = (float) this._itemIdToShow;
          }
        }

        private void FixNPCIfWasHoldingItem(NPC obj)
        {
          if ((double) obj.ai[0] != 23.0)
            return;
          obj.frameCounter = 0.0;
          obj.ai[0] = 0.0f;
          obj.ai[1] = 0.0f;
          obj.ai[2] = 0.0f;
        }
      }

      public class Move : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private Vector2 _offsetPerFrame;
        private int _duration;
        private float _delay;

        public Move(Vector2 offsetPerFrame, int durationInFrames)
        {
          this._offsetPerFrame = offsetPerFrame;
          this._duration = durationInFrames;
        }

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          float num = localTimeForObj - this._delay;
          if ((double) num > (double) this._duration)
            num = (float) this._duration;
          NPC npc = obj;
          npc.position = npc.position + this._offsetPerFrame * num;
          obj.velocity = this._offsetPerFrame;
          if ((double) this._offsetPerFrame.X == 0.0)
            return;
          obj.direction = obj.spriteDirection = (double) this._offsetPerFrame.X > 0.0 ? 1 : -1;
        }
      }

      public class MoveWithAcceleration : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private Vector2 _offsetPerFrame;
        private Vector2 _accelerationPerFrame;
        private int _duration;
        private float _delay;

        public MoveWithAcceleration(
          Vector2 offsetPerFrame,
          Vector2 accelerationPerFrame,
          int durationInFrames)
        {
          this._accelerationPerFrame = accelerationPerFrame;
          this._offsetPerFrame = offsetPerFrame;
          this._duration = durationInFrames;
        }

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          float num = localTimeForObj - this._delay;
          if ((double) num > (double) this._duration)
            num = (float) this._duration;
          Vector2 vector2 = this._offsetPerFrame * num + this._accelerationPerFrame * (float) ((double) num * (double) num * 0.5);
          NPC npc = obj;
          npc.position = npc.position + vector2;
          obj.velocity = this._offsetPerFrame + this._accelerationPerFrame * num;
          if ((double) this._offsetPerFrame.X == 0.0)
            return;
          obj.direction = obj.spriteDirection = (double) this._offsetPerFrame.X > 0.0 ? 1 : -1;
        }
      }

      public class MoveWithRotor : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private Vector2 _offsetPerFrame;
        private Vector2 _resultMultiplier;
        private float _radialOffset;
        private int _duration;
        private float _delay;

        public MoveWithRotor(
          Vector2 radialOffset,
          float rotationPerFrame,
          Vector2 resultMultiplier,
          int durationInFrames)
        {
          this._radialOffset = rotationPerFrame;
          this._offsetPerFrame = radialOffset;
          this._resultMultiplier = resultMultiplier;
          this._duration = durationInFrames;
        }

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          float num = localTimeForObj - this._delay;
          if ((double) num > (double) this._duration)
            num = (float) this._duration;
          Vector2 vector2 = this._offsetPerFrame.RotatedBy((double) this._radialOffset * (double) num) * this._resultMultiplier;
          NPC npc = obj;
          npc.position = npc.position + vector2;
        }
      }

      public class DoBunnyRestAnimation : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private int _duration;
        private float _delay;

        public DoBunnyRestAnimation(int durationInFrames) => this._duration = durationInFrames;

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          float num1 = localTimeForObj - this._delay;
          if ((double) num1 > (double) this._duration)
            num1 = (float) this._duration;
          Rectangle frame = obj.frame;
          int num2 = 10;
          int num3 = (int) num1;
          while (num3 > 4)
          {
            num3 -= 4;
            ++num2;
            if (num2 > 13)
              num2 = 13;
          }
          obj.ai[0] = 21f;
          obj.ai[1] = 31f;
          obj.frameCounter = (double) num3;
          obj.frame.Y = num2 * frame.Height;
        }
      }

      public class Wait : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private int _duration;
        private float _delay;

        public Wait(int durationInFrames) => this._duration = durationInFrames;

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          obj.velocity = Vector2.Zero;
        }

        public void SetDelay(float delay) => this._delay = delay;
      }

      public class Blink : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private int _duration;
        private float _delay;

        public Blink(int durationInFrames) => this._duration = durationInFrames;

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          obj.velocity = Vector2.Zero;
          obj.ai[0] = 0.0f;
          if ((double) localTimeForObj > (double) this._delay + (double) this._duration)
            return;
          obj.ai[0] = 1001f;
        }

        public void SetDelay(float delay) => this._delay = delay;
      }

      public class LookAt : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private int _direction;
        private float _delay;

        public LookAt(int direction) => this._direction = direction;

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => 0;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          obj.direction = obj.spriteDirection = this._direction;
        }

        public void SetDelay(float delay) => this._delay = delay;
      }

      public class PartyHard : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        public void BindTo(NPC obj)
        {
          obj.ForcePartyHatOn = true;
          obj.UpdateAltTexture();
        }

        public int ExpectedLengthOfActionInFrames => 0;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
        }

        public void SetDelay(float delay)
        {
        }
      }

      public class ForceAltTexture : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private int _altTexture;

        public ForceAltTexture(int altTexture) => this._altTexture = altTexture;

        public void BindTo(NPC obj) => obj.altTexture = this._altTexture;

        public int ExpectedLengthOfActionInFrames => 0;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
        }

        public void SetDelay(float delay)
        {
        }
      }

      public class Variant : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private int _variant;

        public Variant(int variant) => this._variant = variant;

        public void BindTo(NPC obj) => obj.townNpcVariationIndex = this._variant;

        public int ExpectedLengthOfActionInFrames => 0;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
        }

        public void SetDelay(float delay)
        {
        }
      }

      public class ZombieKnockOnDoor : Actions.NPCs.INPCAction, ICreditsRollSegmentAction<NPC>
      {
        private int _duration;
        private float _delay;
        private Vector2 bumpOffset = new Vector2(-1f, 0.0f);
        private Vector2 bumpVelocity = new Vector2(0.75f, 0.0f);

        public ZombieKnockOnDoor(int durationInFrames) => this._duration = durationInFrames;

        public void BindTo(NPC obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(NPC obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          float num = localTimeForObj - this._delay;
          if ((double) num > (double) this._duration)
            num = (float) this._duration;
          if ((int) num % 60 / 4 <= 3)
          {
            NPC npc = obj;
            npc.position = npc.position + this.bumpOffset;
            obj.velocity = this.bumpVelocity;
          }
          else
          {
            NPC npc = obj;
            npc.position = npc.position - this.bumpOffset;
            obj.velocity = Vector2.Zero;
          }
        }
      }
    }

    public class Sprites
    {
      public interface ISpriteAction : ICreditsRollSegmentAction<Segments.LooseSprite>
      {
      }

      public class Fade : 
        Actions.Sprites.ISpriteAction,
        ICreditsRollSegmentAction<Segments.LooseSprite>
      {
        private int _duration;
        private float _opacityTarget;
        private float _delay;

        public Fade(float opacityTarget)
        {
          this._duration = 0;
          this._opacityTarget = opacityTarget;
        }

        public Fade(float opacityTarget, int duration)
        {
          this._duration = duration;
          this._opacityTarget = opacityTarget;
        }

        public void BindTo(Segments.LooseSprite obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(Segments.LooseSprite obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          if (this._duration == 0)
          {
            obj.CurrentOpacity = this._opacityTarget;
          }
          else
          {
            float t = localTimeForObj - this._delay;
            if ((double) t > (double) this._duration)
              t = (float) this._duration;
            obj.CurrentOpacity = MathHelper.Lerp(obj.CurrentOpacity, this._opacityTarget, Utils.GetLerpValue(0.0f, (float) this._duration, t, true));
          }
        }
      }

      public class Wait : 
        Actions.Sprites.ISpriteAction,
        ICreditsRollSegmentAction<Segments.LooseSprite>
      {
        private int _duration;
        private float _delay;

        public Wait(int durationInFrames) => this._duration = durationInFrames;

        public void BindTo(Segments.LooseSprite obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void ApplyTo(Segments.LooseSprite obj, float localTimeForObj)
        {
          double delay = (double) this._delay;
        }

        public void SetDelay(float delay) => this._delay = delay;
      }

      public class SimulateGravity : 
        Actions.Sprites.ISpriteAction,
        ICreditsRollSegmentAction<Segments.LooseSprite>
      {
        private int _duration;
        private float _delay;
        private Vector2 _initialVelocity;
        private Vector2 _gravityPerFrame;
        private float _rotationPerFrame;

        public SimulateGravity(
          Vector2 initialVelocity,
          Vector2 gravityPerFrame,
          float rotationPerFrame,
          int duration)
        {
          this._duration = duration;
          this._initialVelocity = initialVelocity;
          this._gravityPerFrame = gravityPerFrame;
          this._rotationPerFrame = rotationPerFrame;
        }

        public void BindTo(Segments.LooseSprite obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(Segments.LooseSprite obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          float num = localTimeForObj - this._delay;
          if ((double) num > (double) this._duration)
            num = (float) this._duration;
          Vector2 vector2 = this._initialVelocity * num + this._gravityPerFrame * (num * num);
          obj.CurrentDrawData.position += vector2;
          obj.CurrentDrawData.rotation += this._rotationPerFrame * num;
        }
      }

      public class SetFrame : 
        Actions.Sprites.ISpriteAction,
        ICreditsRollSegmentAction<Segments.LooseSprite>
      {
        private int _targetFrameX;
        private int _targetFrameY;
        private int _paddingX;
        private int _paddingY;
        private float _delay;

        public SetFrame(int frameX, int frameY, int paddingX = 2, int paddingY = 2)
        {
          this._targetFrameX = frameX;
          this._targetFrameY = frameY;
          this._paddingX = paddingX;
          this._paddingY = paddingY;
        }

        public void BindTo(Segments.LooseSprite obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => 0;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(Segments.LooseSprite obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          Rectangle rectangle = obj.CurrentDrawData.sourceRect.Value;
          rectangle.X = (rectangle.Width + this._paddingX) * this._targetFrameX;
          rectangle.Y = (rectangle.Height + this._paddingY) * this._targetFrameY;
          obj.CurrentDrawData.sourceRect = new Rectangle?(rectangle);
        }
      }

      public class SetFrameSequence : 
        Actions.Sprites.ISpriteAction,
        ICreditsRollSegmentAction<Segments.LooseSprite>
      {
        private Point[] _frameIndices;
        private int _timePerFrame;
        private int _paddingX;
        private int _paddingY;
        private float _delay;
        private int _duration;
        private bool _loop;

        public SetFrameSequence(
          int duration,
          Point[] frameIndices,
          int timePerFrame,
          int paddingX = 2,
          int paddingY = 2)
          : this(frameIndices, timePerFrame, paddingX, paddingY)
        {
          this._duration = duration;
          this._loop = true;
        }

        public SetFrameSequence(
          Point[] frameIndices,
          int timePerFrame,
          int paddingX = 2,
          int paddingY = 2)
        {
          this._frameIndices = frameIndices;
          this._timePerFrame = timePerFrame;
          this._paddingX = paddingX;
          this._paddingY = paddingY;
          this._duration = this._timePerFrame * this._frameIndices.Length;
        }

        public void BindTo(Segments.LooseSprite obj)
        {
        }

        public int ExpectedLengthOfActionInFrames => this._duration;

        public void SetDelay(float delay) => this._delay = delay;

        public void ApplyTo(Segments.LooseSprite obj, float localTimeForObj)
        {
          if ((double) localTimeForObj < (double) this._delay)
            return;
          Rectangle rectangle = obj.CurrentDrawData.sourceRect.Value;
          int index;
          if (this._loop)
          {
            int length = this._frameIndices.Length;
            index = (int) ((double) localTimeForObj % (double) (this._timePerFrame * length)) / this._timePerFrame;
            if (index >= length)
              index = length - 1;
          }
          else
          {
            float num = localTimeForObj - this._delay;
            if ((double) num > (double) this._duration)
              num = (float) this._duration;
            index = (int) ((double) num / (double) this._timePerFrame);
            if (index >= this._frameIndices.Length)
              index = this._frameIndices.Length - 1;
          }
          Point frameIndex = this._frameIndices[index];
          rectangle.X = (rectangle.Width + this._paddingX) * frameIndex.X;
          rectangle.Y = (rectangle.Height + this._paddingY) * frameIndex.Y;
          obj.CurrentDrawData.sourceRect = new Rectangle?(rectangle);
        }
      }
    }
  }
}
