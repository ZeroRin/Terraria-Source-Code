﻿// Decompiled with JetBrains decompiler
// Type: Terraria.PopupText
// Assembly: Terraria, Version=1.4.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F541F3E5-89DE-4E5D-868F-1B56DAAB46B2
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.Localization;

namespace Terraria
{
  public class PopupText
  {
    public Vector2 position;
    public Vector2 velocity;
    public float alpha;
    public int alphaDir = 1;
    public string name;
    public int stack;
    public float scale = 1f;
    public float rotation;
    public Color color;
    public bool active;
    public int lifeTime;
    public static int activeTime = 60;
    public static int numActive;
    public bool NoStack;
    public bool coinText;
    public int coinValue;
    public static int sonarText = -1;
    public bool expert;
    public bool master;
    public bool sonar;
    public PopupTextContext context;
    public int npcNetID;
    public bool freeAdvanced;

    public bool notActuallyAnItem => this.npcNetID != 0 || this.freeAdvanced;

    public static float TargetScale => Main.UIScale / Main.GameViewMatrix.Zoom.X;

    public static void ClearSonarText()
    {
      if (PopupText.sonarText < 0 || !Main.popupText[PopupText.sonarText].sonar)
        return;
      Main.popupText[PopupText.sonarText].active = false;
      PopupText.sonarText = -1;
    }

    public static void ResetText(PopupText text)
    {
      text.NoStack = false;
      text.coinText = false;
      text.coinValue = 0;
      text.sonar = false;
      text.npcNetID = 0;
      text.expert = false;
      text.master = false;
      text.freeAdvanced = false;
      text.scale = 0.0f;
      text.rotation = 0.0f;
      text.alpha = 1f;
      text.alphaDir = -1;
    }

    public static int NewText(AdvancedPopupRequest request, Vector2 position)
    {
      if (!Main.showItemText || Main.netMode == 2)
        return -1;
      int nextItemTextSlot = PopupText.FindNextItemTextSlot();
      if (nextItemTextSlot >= 0)
      {
        string text1 = request.Text;
        Vector2 vector2 = FontAssets.MouseText.Value.MeasureString(text1);
        PopupText text2 = Main.popupText[nextItemTextSlot];
        PopupText.ResetText(text2);
        text2.active = true;
        text2.position = position - vector2 / 2f;
        text2.name = text1;
        text2.stack = 1;
        text2.velocity = request.Velocity;
        text2.lifeTime = request.DurationInFrames;
        text2.context = PopupTextContext.Advanced;
        text2.freeAdvanced = true;
        text2.color = request.Color;
      }
      return nextItemTextSlot;
    }

    public static int NewText(
      PopupTextContext context,
      int npcNetID,
      Vector2 position,
      bool stay5TimesLonger)
    {
      if (!Main.showItemText || npcNetID == 0 || Main.netMode == 2)
        return -1;
      int nextItemTextSlot = PopupText.FindNextItemTextSlot();
      if (nextItemTextSlot >= 0)
      {
        NPC npc = new NPC();
        npc.SetDefaults(npcNetID);
        string typeName = npc.TypeName;
        Vector2 vector2 = FontAssets.MouseText.Value.MeasureString(typeName);
        PopupText text = Main.popupText[nextItemTextSlot];
        PopupText.ResetText(text);
        text.active = true;
        text.position = position - vector2 / 2f;
        text.name = typeName;
        text.stack = 1;
        text.velocity.Y = -7f;
        text.lifeTime = 60;
        text.context = context;
        if (stay5TimesLonger)
          text.lifeTime *= 5;
        text.npcNetID = npcNetID;
        text.color = Color.White;
        if (context == PopupTextContext.SonarAlert)
          text.color = Color.Lerp(Color.White, Color.Crimson, 0.5f);
      }
      return nextItemTextSlot;
    }

    public static int NewText(
      PopupTextContext context,
      Item newItem,
      int stack,
      bool noStack = false,
      bool longText = false)
    {
      if (!Main.showItemText || newItem.Name == null || !newItem.active || Main.netMode == 2)
        return -1;
      bool flag = newItem.type >= 71 && newItem.type <= 74;
      for (int index = 0; index < 20; ++index)
      {
        PopupText popupText = Main.popupText[index];
        if (popupText.active && !popupText.notActuallyAnItem && (popupText.name == newItem.AffixName() || flag && popupText.coinText) && !popupText.NoStack && !noStack)
        {
          string str1 = newItem.Name + " (" + (popupText.stack + stack).ToString() + ")";
          string str2 = newItem.Name;
          if (popupText.stack > 1)
            str2 = str2 + " (" + popupText.stack.ToString() + ")";
          FontAssets.MouseText.Value.MeasureString(str2);
          Vector2 vector2 = FontAssets.MouseText.Value.MeasureString(str1);
          if (popupText.lifeTime < 0)
            popupText.scale = 1f;
          if (popupText.lifeTime < 60)
            popupText.lifeTime = 60;
          if (flag && popupText.coinText)
          {
            int num = 0;
            if (newItem.type == 71)
              num += stack;
            else if (newItem.type == 72)
              num += 100 * stack;
            else if (newItem.type == 73)
              num += 10000 * stack;
            else if (newItem.type == 74)
              num += 1000000 * stack;
            popupText.coinValue += num;
            string name = PopupText.ValueToName(popupText.coinValue);
            vector2 = FontAssets.MouseText.Value.MeasureString(name);
            popupText.name = name;
            if (popupText.coinValue >= 1000000)
            {
              if (popupText.lifeTime < 300)
                popupText.lifeTime = 300;
              popupText.color = new Color(220, 220, 198);
            }
            else if (popupText.coinValue >= 10000)
            {
              if (popupText.lifeTime < 240)
                popupText.lifeTime = 240;
              popupText.color = new Color(224, 201, 92);
            }
            else if (popupText.coinValue >= 100)
            {
              if (popupText.lifeTime < 180)
                popupText.lifeTime = 180;
              popupText.color = new Color(181, 192, 193);
            }
            else if (popupText.coinValue >= 1)
            {
              if (popupText.lifeTime < 120)
                popupText.lifeTime = 120;
              popupText.color = new Color(246, 138, 96);
            }
          }
          popupText.stack += stack;
          popupText.scale = 0.0f;
          popupText.rotation = 0.0f;
          popupText.position.X = (float) ((double) newItem.position.X + (double) newItem.width * 0.5 - (double) vector2.X * 0.5);
          popupText.position.Y = (float) ((double) newItem.position.Y + (double) newItem.height * 0.25 - (double) vector2.Y * 0.5);
          popupText.velocity.Y = -7f;
          popupText.context = context;
          popupText.npcNetID = 0;
          if (popupText.coinText)
            popupText.stack = 1;
          return index;
        }
      }
      int nextItemTextSlot = PopupText.FindNextItemTextSlot();
      if (nextItemTextSlot >= 0)
      {
        string str = newItem.AffixName();
        if (stack > 1)
          str = str + " (" + stack.ToString() + ")";
        Vector2 vector2 = FontAssets.MouseText.Value.MeasureString(str);
        PopupText text = Main.popupText[nextItemTextSlot];
        PopupText.ResetText(text);
        text.active = true;
        text.position.X = (float) ((double) newItem.position.X + (double) newItem.width * 0.5 - (double) vector2.X * 0.5);
        text.position.Y = (float) ((double) newItem.position.Y + (double) newItem.height * 0.25 - (double) vector2.Y * 0.5);
        text.color = Color.White;
        if (newItem.rare == 1)
          text.color = new Color(150, 150, (int) byte.MaxValue);
        else if (newItem.rare == 2)
          text.color = new Color(150, (int) byte.MaxValue, 150);
        else if (newItem.rare == 3)
          text.color = new Color((int) byte.MaxValue, 200, 150);
        else if (newItem.rare == 4)
          text.color = new Color((int) byte.MaxValue, 150, 150);
        else if (newItem.rare == 5)
          text.color = new Color((int) byte.MaxValue, 150, (int) byte.MaxValue);
        else if (newItem.rare == -13)
          text.master = true;
        else if (newItem.rare == -11)
          text.color = new Color((int) byte.MaxValue, 175, 0);
        else if (newItem.rare == -1)
          text.color = new Color(130, 130, 130);
        else if (newItem.rare == 6)
          text.color = new Color(210, 160, (int) byte.MaxValue);
        else if (newItem.rare == 7)
          text.color = new Color(150, (int) byte.MaxValue, 10);
        else if (newItem.rare == 8)
          text.color = new Color((int) byte.MaxValue, (int) byte.MaxValue, 10);
        else if (newItem.rare == 9)
          text.color = new Color(5, 200, (int) byte.MaxValue);
        else if (newItem.rare == 10)
          text.color = new Color((int) byte.MaxValue, 40, 100);
        else if (newItem.rare >= 11)
          text.color = new Color(180, 40, (int) byte.MaxValue);
        text.expert = newItem.expert;
        text.name = newItem.AffixName();
        text.stack = stack;
        text.velocity.Y = -7f;
        text.lifeTime = 60;
        text.context = context;
        if (longText)
          text.lifeTime *= 5;
        text.coinValue = 0;
        text.coinText = newItem.type >= 71 && newItem.type <= 74;
        if (text.coinText)
        {
          if (newItem.type == 71)
            text.coinValue += text.stack;
          else if (newItem.type == 72)
            text.coinValue += 100 * text.stack;
          else if (newItem.type == 73)
            text.coinValue += 10000 * text.stack;
          else if (newItem.type == 74)
            text.coinValue += 1000000 * text.stack;
          text.ValueToName();
          text.stack = 1;
          if (text.coinValue >= 1000000)
          {
            if (text.lifeTime < 300)
              text.lifeTime = 300;
            text.color = new Color(220, 220, 198);
          }
          else if (text.coinValue >= 10000)
          {
            if (text.lifeTime < 240)
              text.lifeTime = 240;
            text.color = new Color(224, 201, 92);
          }
          else if (text.coinValue >= 100)
          {
            if (text.lifeTime < 180)
              text.lifeTime = 180;
            text.color = new Color(181, 192, 193);
          }
          else if (text.coinValue >= 1)
          {
            if (text.lifeTime < 120)
              text.lifeTime = 120;
            text.color = new Color(246, 138, 96);
          }
        }
      }
      return nextItemTextSlot;
    }

    private static int FindNextItemTextSlot()
    {
      int nextItemTextSlot = -1;
      for (int index = 0; index < 20; ++index)
      {
        if (!Main.popupText[index].active)
        {
          nextItemTextSlot = index;
          break;
        }
      }
      if (nextItemTextSlot == -1)
      {
        double num = (double) Main.bottomWorld;
        for (int index = 0; index < 20; ++index)
        {
          if (num > (double) Main.popupText[index].position.Y)
          {
            nextItemTextSlot = index;
            num = (double) Main.popupText[index].position.Y;
          }
        }
      }
      return nextItemTextSlot;
    }

    public static void AssignAsSonarText(int sonarTextIndex)
    {
      PopupText.sonarText = sonarTextIndex;
      if (PopupText.sonarText <= -1)
        return;
      Main.popupText[PopupText.sonarText].sonar = true;
    }

    public static string ValueToName(int coinValue)
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int num5 = coinValue;
      while (num5 > 0)
      {
        if (num5 >= 1000000)
        {
          num5 -= 1000000;
          ++num1;
        }
        else if (num5 >= 10000)
        {
          num5 -= 10000;
          ++num2;
        }
        else if (num5 >= 100)
        {
          num5 -= 100;
          ++num3;
        }
        else if (num5 >= 1)
        {
          --num5;
          ++num4;
        }
      }
      string name = "";
      if (num1 > 0)
        name = name + num1.ToString() + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Platinum"));
      if (num2 > 0)
        name = name + num2.ToString() + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Gold"));
      if (num3 > 0)
        name = name + num3.ToString() + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Silver"));
      if (num4 > 0)
        name = name + num4.ToString() + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Copper"));
      if (name.Length > 1)
        name = name.Substring(0, name.Length - 1);
      return name;
    }

    private void ValueToName()
    {
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      int num4 = 0;
      int coinValue = this.coinValue;
      while (coinValue > 0)
      {
        if (coinValue >= 1000000)
        {
          coinValue -= 1000000;
          ++num1;
        }
        else if (coinValue >= 10000)
        {
          coinValue -= 10000;
          ++num2;
        }
        else if (coinValue >= 100)
        {
          coinValue -= 100;
          ++num3;
        }
        else if (coinValue >= 1)
        {
          --coinValue;
          ++num4;
        }
      }
      this.name = "";
      if (num1 > 0)
        this.name = this.name + num1.ToString() + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Platinum"));
      if (num2 > 0)
        this.name = this.name + num2.ToString() + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Gold"));
      if (num3 > 0)
        this.name = this.name + num3.ToString() + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Silver"));
      if (num4 > 0)
        this.name = this.name + num4.ToString() + string.Format(" {0} ", (object) Language.GetTextValue("Currency.Copper"));
      if (this.name.Length <= 1)
        return;
      this.name = this.name.Substring(0, this.name.Length - 1);
    }

    public void Update(int whoAmI)
    {
      if (!this.active)
        return;
      float targetScale = PopupText.TargetScale;
      this.alpha += (float) this.alphaDir * 0.01f;
      if ((double) this.alpha <= 0.7)
      {
        this.alpha = 0.7f;
        this.alphaDir = 1;
      }
      if ((double) this.alpha >= 1.0)
      {
        this.alpha = 1f;
        this.alphaDir = -1;
      }
      if (this.expert)
        this.color = new Color((int) (byte) Main.DiscoR, (int) (byte) Main.DiscoG, (int) (byte) Main.DiscoB, (int) Main.mouseTextColor);
      else if (this.master)
        this.color = new Color((int) byte.MaxValue, (int) (byte) ((double) Main.masterColor * 200.0), 0, (int) Main.mouseTextColor);
      bool flag = false;
      Vector2 textHitbox1 = this.GetTextHitbox();
      Rectangle rectangle1 = new Rectangle((int) ((double) this.position.X - (double) textHitbox1.X / 2.0), (int) ((double) this.position.Y - (double) textHitbox1.Y / 2.0), (int) textHitbox1.X, (int) textHitbox1.Y);
      for (int index = 0; index < 20; ++index)
      {
        PopupText popupText = Main.popupText[index];
        if (popupText.active && index != whoAmI)
        {
          Vector2 textHitbox2 = popupText.GetTextHitbox();
          Rectangle rectangle2 = new Rectangle((int) ((double) popupText.position.X - (double) textHitbox2.X / 2.0), (int) ((double) popupText.position.Y - (double) textHitbox2.Y / 2.0), (int) textHitbox2.X, (int) textHitbox2.Y);
          if (rectangle1.Intersects(rectangle2) && ((double) this.position.Y < (double) popupText.position.Y || (double) this.position.Y == (double) popupText.position.Y && whoAmI < index))
          {
            flag = true;
            int num = PopupText.numActive;
            if (num > 3)
              num = 3;
            popupText.lifeTime = PopupText.activeTime + 15 * num;
            this.lifeTime = PopupText.activeTime + 15 * num;
          }
        }
      }
      if (!flag)
      {
        this.velocity.Y *= 0.86f;
        if ((double) this.scale == (double) targetScale)
          this.velocity.Y *= 0.4f;
      }
      else if ((double) this.velocity.Y > -6.0)
        this.velocity.Y -= 0.2f;
      else
        this.velocity.Y *= 0.86f;
      this.velocity.X *= 0.93f;
      this.position += this.velocity;
      --this.lifeTime;
      if (this.lifeTime <= 0)
      {
        this.scale -= 0.03f * targetScale;
        if ((double) this.scale < 0.1 * (double) targetScale)
        {
          this.active = false;
          if (PopupText.sonarText == whoAmI)
            PopupText.sonarText = -1;
        }
        this.lifeTime = 0;
      }
      else
      {
        if ((double) this.scale < (double) targetScale)
          this.scale += 0.1f * targetScale;
        if ((double) this.scale <= (double) targetScale)
          return;
        this.scale = targetScale;
      }
    }

    private Vector2 GetTextHitbox()
    {
      string str = this.name;
      if (this.stack > 1)
        str = str + " (" + this.stack.ToString() + ")";
      Vector2 textHitbox = FontAssets.MouseText.Value.MeasureString(str) * this.scale;
      textHitbox.Y *= 0.8f;
      return textHitbox;
    }

    public static void UpdateItemText()
    {
      int num = 0;
      for (int whoAmI = 0; whoAmI < 20; ++whoAmI)
      {
        if (Main.popupText[whoAmI].active)
        {
          ++num;
          Main.popupText[whoAmI].Update(whoAmI);
        }
      }
      PopupText.numActive = num;
    }
  }
}
