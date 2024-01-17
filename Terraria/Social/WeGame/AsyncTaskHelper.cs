// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.AsyncTaskHelper
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Threading.Tasks;

namespace Terraria.Social.WeGame
{
  public class AsyncTaskHelper
  {
    private CurrentThreadRunner _currentThreadRunner;

    private AsyncTaskHelper() => this._currentThreadRunner = new CurrentThreadRunner();

    public void RunAsyncTaskAndReply(Action task, Action replay) => Task.Factory.StartNew((Action) (() =>
    {
      task();
      this._currentThreadRunner.Run(replay);
    }));

    public void RunAsyncTask(Action task) => Task.Factory.StartNew(task);
  }
}
