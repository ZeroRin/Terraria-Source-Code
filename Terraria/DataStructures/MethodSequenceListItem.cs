// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.MethodSequenceListItem
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Collections.Generic;

namespace Terraria.DataStructures
{
  public class MethodSequenceListItem
  {
    public string Name;
    public MethodSequenceListItem Parent;
    public Func<bool> Method;
    public bool Skip;

    public MethodSequenceListItem(string name, Func<bool> method, MethodSequenceListItem parent = null)
    {
      this.Name = name;
      this.Method = method;
      this.Parent = parent;
    }

    public bool ShouldAct(List<MethodSequenceListItem> sequence)
    {
      if (this.Skip || !sequence.Contains(this))
        return false;
      return this.Parent == null || this.Parent.ShouldAct(sequence);
    }

    public bool Act() => this.Method();

    public static void ExecuteSequence(List<MethodSequenceListItem> sequence)
    {
      foreach (MethodSequenceListItem sequenceListItem in sequence)
      {
        if (sequenceListItem.ShouldAct(sequence) && !sequenceListItem.Act())
          break;
      }
    }

    public override string ToString() => "name: " + this.Name + " skip: " + this.Skip.ToString() + " parent: " + (object) this.Parent;
  }
}
