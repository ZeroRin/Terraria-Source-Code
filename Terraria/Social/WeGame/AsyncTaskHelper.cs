// Decompiled with JetBrains decompiler
// Type: Terraria.Social.WeGame.AsyncTaskHelper
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
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
