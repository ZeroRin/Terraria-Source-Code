﻿// Decompiled with JetBrains decompiler
// Type: Terraria.GameContent.RGB.VirtualKeyboard
// Assembly: Terraria, Version=1.4.4.9, Culture=neutral, PublicKeyToken=null
// MVID: CD1A926A-5330-4A76-ABC1-173FBEBCC76B
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ReLogic.Peripherals.RGB;
using System.Collections.Generic;

namespace Terraria.GameContent.RGB
{
  public class VirtualKeyboard : RgbKeyboard
  {
    private Dictionary<Keys, int> _keyCodeMap = new Dictionary<Keys, int>();

    private VirtualKeyboard(Fragment fragment, Keys[] keyMap)
      : base((RgbDeviceVendor) 4, fragment, new DeviceColorProfile())
    {
      for (int index = 0; index < keyMap.Length; ++index)
      {
        if (keyMap[index] != Keys.None)
          this._keyCodeMap.Add(keyMap[index], index);
      }
    }

    public static VirtualKeyboard Create()
    {
      Point[] pointArray = new Point[133]
      {
        new Point(2, 6),
        new Point(7, 0),
        new Point(1, 4),
        new Point(2, 4),
        new Point(0, 5),
        new Point(1, 5),
        new Point(2, 5),
        new Point(0, 6),
        new Point(1, 6),
        new Point(1, 3),
        new Point(2, 3),
        new Point(0, 4),
        new Point(4, 0),
        new Point(5, 0),
        new Point(6, 0),
        new Point(19, 3),
        new Point(20, 3),
        new Point(21, 3),
        new Point(17, 5),
        new Point(17, 6),
        new Point(20, 5),
        new Point(19, 6),
        new Point(20, 6),
        new Point(16, 3),
        new Point(17, 3),
        new Point(17, 4),
        new Point(16, 2),
        new Point(17, 2),
        new Point(19, 0),
        new Point(18, 1),
        new Point(19, 1),
        new Point(20, 1),
        new Point(21, 1),
        new Point(19, 2),
        new Point(20, 2),
        new Point(21, 2),
        new Point(10, 6),
        new Point(14, 6),
        new Point(15, 6),
        new Point(16, 6),
        new Point(24, 6),
        new Point(0, 1),
        new Point(1, 1),
        new Point(2, 1),
        new Point(0, 2),
        new Point(1, 2),
        new Point(2, 2),
        new Point(0, 3),
        new Point(22, 4),
        new Point(23, 4),
        new Point(24, 4),
        new Point(22, 5),
        new Point(23, 5),
        new Point(24, 5),
        new Point(23, 6),
        new Point(23, 2),
        new Point(24, 2),
        new Point(25, 2),
        new Point(25, 3),
        new Point(25, 5),
        new Point(22, 3),
        new Point(23, 3),
        new Point(24, 3),
        new Point(21, 6),
        new Point(20, 0),
        new Point(23, 0),
        new Point(22, 1),
        new Point(23, 1),
        new Point(24, 1),
        new Point(25, 1),
        new Point(22, 2),
        new Point(15, 2),
        new Point(4, 3),
        new Point(5, 3),
        new Point(6, 3),
        new Point(7, 3),
        new Point(8, 3),
        new Point(9, 3),
        new Point(10, 3),
        new Point(7, 2),
        new Point(8, 2),
        new Point(9, 2),
        new Point(10, 2),
        new Point(11, 2),
        new Point(12, 2),
        new Point(13, 2),
        new Point(14, 2),
        new Point(12, 1),
        new Point(13, 1),
        new Point(15, 1),
        new Point(16, 1),
        new Point(17, 1),
        new Point(4, 2),
        new Point(5, 2),
        new Point(6, 2),
        new Point(4, 1),
        new Point(5, 1),
        new Point(6, 1),
        new Point(7, 1),
        new Point(8, 1),
        new Point(10, 1),
        new Point(11, 1),
        new Point(11, 5),
        new Point(12, 5),
        new Point(13, 5),
        new Point(14, 5),
        new Point(15, 5),
        new Point(4, 6),
        new Point(5, 6),
        new Point(6, 6),
        new Point(15, 4),
        new Point(4, 5),
        new Point(6, 5),
        new Point(7, 5),
        new Point(8, 5),
        new Point(9, 5),
        new Point(10, 5),
        new Point(7, 4),
        new Point(8, 4),
        new Point(9, 4),
        new Point(10, 4),
        new Point(11, 4),
        new Point(12, 4),
        new Point(13, 4),
        new Point(14, 4),
        new Point(11, 3),
        new Point(12, 3),
        new Point(13, 3),
        new Point(14, 3),
        new Point(15, 3),
        new Point(4, 4),
        new Point(5, 4),
        new Point(6, 4)
      };
      Vector2[] vector2Array = new Vector2[133]
      {
        new Vector2(0.4365079f, 1f),
        new Vector2(1.123016f, 0.007936508f),
        new Vector2(0.2857143f, 0.6666667f),
        new Vector2(0.4365079f, 0.6666667f),
        new Vector2(0.1349206f, 0.8571429f),
        new Vector2(0.2857143f, 0.8571429f),
        new Vector2(0.4365079f, 0.8571429f),
        new Vector2(0.1349206f, 1f),
        new Vector2(0.2857143f, 1f),
        new Vector2(0.2857143f, 0.515873f),
        new Vector2(0.4365079f, 0.515873f),
        new Vector2(0.1349206f, 0.6666667f),
        new Vector2(0.6428571f, 0.007936508f),
        new Vector2(0.8015873f, 0.007936508f),
        new Vector2(0.9603174f, 0.007936508f),
        new Vector2(3.06746f, 0.515873f),
        new Vector2(3.226191f, 0.515873f),
        new Vector2(3.384921f, 0.515873f),
        new Vector2(2.730159f, 0.8412699f),
        new Vector2(2.829365f, 0.9920635f),
        new Vector2(3.226191f, 0.8412699f),
        new Vector2(3.071429f, 0.9920635f),
        new Vector2(3.226191f, 0.9920635f),
        new Vector2(2.630952f, 0.515873f),
        new Vector2(2.829365f, 0.515873f),
        new Vector2(2.769841f, 0.6825397f),
        new Vector2(2.551587f, 0.3650794f),
        new Vector2(2.789683f, 0.3650794f),
        new Vector2(3.075397f, 0.0f),
        new Vector2(2.869048f, 0.1904762f),
        new Vector2(3.06746f, 0.1904762f),
        new Vector2(3.226191f, 0.1904762f),
        new Vector2(3.384921f, 0.1904762f),
        new Vector2(3.06746f, 0.3650794f),
        new Vector2(3.226191f, 0.3650794f),
        new Vector2(3.384921f, 0.3650794f),
        new Vector2(1.674603f, 0.9920635f),
        new Vector2(2.289683f, 0.9920635f),
        new Vector2(2.472222f, 0.9920635f),
        new Vector2(2.630952f, 0.9920635f),
        new Vector2(3.904762f, 0.9920635f),
        new Vector2(0.1349206f, 0.1825397f),
        new Vector2(0.2857143f, 0.1825397f),
        new Vector2(0.4365079f, 0.1825397f),
        new Vector2(0.1349206f, 0.3333333f),
        new Vector2(0.2857143f, 0.3333333f),
        new Vector2(0.4365079f, 0.3333333f),
        new Vector2(0.1349206f, 0.515873f),
        new Vector2(3.59127f, 0.6825397f),
        new Vector2(3.75f, 0.6825397f),
        new Vector2(3.90873f, 0.6825397f),
        new Vector2(3.59127f, 0.8412699f),
        new Vector2(3.75f, 0.8412699f),
        new Vector2(3.90873f, 0.8412699f),
        new Vector2(3.670635f, 0.9920635f),
        new Vector2(3.75f, 0.3650794f),
        new Vector2(3.90873f, 0.3650794f),
        new Vector2(4.063492f, 0.3650794f),
        new Vector2(4.063492f, 0.515873f),
        new Vector2(4.063492f, 0.8412699f),
        new Vector2(3.59127f, 0.515873f),
        new Vector2(3.75f, 0.515873f),
        new Vector2(3.90873f, 0.515873f),
        new Vector2(3.384921f, 0.9920635f),
        new Vector2(3.234127f, 0.0f),
        new Vector2(3.75f, 0.0f),
        new Vector2(3.595238f, 0.1904762f),
        new Vector2(3.75f, 0.1904762f),
        new Vector2(3.900794f, 0.1904762f),
        new Vector2(4.059524f, 0.1904762f),
        new Vector2(3.59127f, 0.3650794f),
        new Vector2(2.392857f, 0.3650794f),
        new Vector2(0.6785714f, 0.515873f),
        new Vector2(0.8849207f, 0.515873f),
        new Vector2(1.043651f, 0.515873f),
        new Vector2(1.194444f, 0.515873f),
        new Vector2(1.361111f, 0.515873f),
        new Vector2(1.519841f, 0.515873f),
        new Vector2(1.678571f, 0.515873f),
        new Vector2(1.123016f, 0.3650794f),
        new Vector2(1.281746f, 0.3650794f),
        new Vector2(1.440476f, 0.3650794f),
        new Vector2(1.599206f, 0.3650794f),
        new Vector2(1.757936f, 0.3650794f),
        new Vector2(1.916667f, 0.3650794f),
        new Vector2(2.075397f, 0.3650794f),
        new Vector2(2.234127f, 0.3650794f),
        new Vector2(1.964286f, 0.1904762f),
        new Vector2(2.130952f, 0.1904762f),
        new Vector2(2.392857f, 0.1904762f),
        new Vector2(2.551587f, 0.1904762f),
        new Vector2(2.710317f, 0.1904762f),
        new Vector2(0.6388889f, 0.3650794f),
        new Vector2(0.8055556f, 0.3650794f),
        new Vector2(0.9642857f, 0.3650794f),
        new Vector2(0.6388889f, 0.1904762f),
        new Vector2(0.9087301f, 0.1904762f),
        new Vector2(1.06746f, 0.1904762f),
        new Vector2(1.22619f, 0.1904762f),
        new Vector2(1.384921f, 0.1904762f),
        new Vector2(1.654762f, 0.1904762f),
        new Vector2(1.805556f, 0.1904762f),
        new Vector2(1.797619f, 0.8412699f),
        new Vector2(1.956349f, 0.8412699f),
        new Vector2(2.115079f, 0.8412699f),
        new Vector2(2.273809f, 0.8412699f),
        new Vector2(2.43254f, 0.8412699f),
        new Vector2(0.6785714f, 0.9920635f),
        new Vector2(0.8849207f, 0.9920635f),
        new Vector2(1.063492f, 0.9920635f),
        new Vector2(2.511905f, 0.6825397f),
        new Vector2(0.7380952f, 0.8412699f),
        new Vector2(1.003968f, 0.8412699f),
        new Vector2(1.162698f, 0.8412699f),
        new Vector2(1.321429f, 0.8412699f),
        new Vector2(1.480159f, 0.8412699f),
        new Vector2(1.638889f, 0.8412699f),
        new Vector2(1.242064f, 0.6825397f),
        new Vector2(1.400794f, 0.6825397f),
        new Vector2(1.559524f, 0.6825397f),
        new Vector2(1.718254f, 0.6825397f),
        new Vector2(1.876984f, 0.6825397f),
        new Vector2(2.035714f, 0.6825397f),
        new Vector2(2.194444f, 0.6825397f),
        new Vector2(2.353175f, 0.6825397f),
        new Vector2(1.837302f, 0.515873f),
        new Vector2(1.996032f, 0.515873f),
        new Vector2(2.154762f, 0.515873f),
        new Vector2(2.313492f, 0.515873f),
        new Vector2(2.472222f, 0.515873f),
        new Vector2(0.6984127f, 0.6825397f),
        new Vector2(0.9166667f, 0.6825397f),
        new Vector2(1.083333f, 0.6825397f)
      };
      Keys[] keyMap = new Keys[133]
      {
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.Delete,
        Keys.End,
        Keys.PageDown,
        Keys.RightShift,
        Keys.RightControl,
        Keys.Up,
        Keys.Left,
        Keys.Down,
        Keys.OemCloseBrackets,
        Keys.OemBackslash,
        Keys.Enter,
        Keys.OemPlus,
        Keys.Back,
        Keys.None,
        Keys.F12,
        Keys.PrintScreen,
        Keys.Scroll,
        Keys.Pause,
        Keys.Insert,
        Keys.Home,
        Keys.PageUp,
        Keys.Space,
        Keys.RightAlt,
        Keys.None,
        Keys.None,
        Keys.Decimal,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.None,
        Keys.NumPad4,
        Keys.NumPad5,
        Keys.NumPad6,
        Keys.NumPad1,
        Keys.NumPad2,
        Keys.NumPad3,
        Keys.NumPad0,
        Keys.Divide,
        Keys.Multiply,
        Keys.Subtract,
        Keys.Add,
        Keys.None,
        Keys.NumPad7,
        Keys.NumPad8,
        Keys.NumPad9,
        Keys.Right,
        Keys.None,
        Keys.VolumeMute,
        Keys.MediaStop,
        Keys.MediaPreviousTrack,
        Keys.MediaPlayPause,
        Keys.MediaNextTrack,
        Keys.NumLock,
        Keys.OemMinus,
        Keys.Tab,
        Keys.Q,
        Keys.W,
        Keys.E,
        Keys.R,
        Keys.T,
        Keys.Y,
        Keys.D3,
        Keys.D4,
        Keys.D5,
        Keys.D6,
        Keys.D7,
        Keys.D8,
        Keys.D9,
        Keys.D0,
        Keys.F7,
        Keys.F8,
        Keys.F9,
        Keys.F10,
        Keys.F11,
        Keys.OemTilde,
        Keys.D1,
        Keys.D2,
        Keys.Escape,
        Keys.F1,
        Keys.F2,
        Keys.F3,
        Keys.F4,
        Keys.F5,
        Keys.F6,
        Keys.N,
        Keys.M,
        Keys.OemComma,
        Keys.OemPeriod,
        Keys.OemQuestion,
        Keys.LeftControl,
        Keys.None,
        Keys.LeftAlt,
        Keys.OemQuotes,
        Keys.LeftShift,
        Keys.Z,
        Keys.X,
        Keys.C,
        Keys.V,
        Keys.B,
        Keys.D,
        Keys.F,
        Keys.G,
        Keys.H,
        Keys.J,
        Keys.K,
        Keys.L,
        Keys.OemSemicolon,
        Keys.U,
        Keys.I,
        Keys.O,
        Keys.P,
        Keys.OemOpenBrackets,
        Keys.CapsLock,
        Keys.A,
        Keys.S
      };
      return new VirtualKeyboard(Fragment.FromCustom(pointArray, vector2Array), keyMap);
    }

    public virtual void Present()
    {
    }

    public virtual void Render(IEnumerable<RgbKey> keys)
    {
      foreach (RgbKey key in keys)
      {
        int num;
        if (this._keyCodeMap.TryGetValue(key.Key, out num))
          ((RgbDevice) this).SetLedColor(num, key.CurrentColor.ToVector4());
      }
    }
  }
}
