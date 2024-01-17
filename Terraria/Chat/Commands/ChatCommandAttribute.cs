// Decompiled with JetBrains decompiler
// Type: Terraria.Chat.Commands.ChatCommandAttribute
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;

namespace Terraria.Chat.Commands
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, Inherited = false)]
  public sealed class ChatCommandAttribute : Attribute
  {
    public readonly string Name;

    public ChatCommandAttribute(string name) => this.Name = name;
  }
}
