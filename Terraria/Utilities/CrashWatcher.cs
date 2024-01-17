// Decompiled with JetBrains decompiler
// Type: Terraria.Utilities.CrashWatcher
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Threading;

namespace Terraria.Utilities
{
  public static class CrashWatcher
  {
    public static bool LogAllExceptions { get; set; }

    public static bool DumpOnException { get; set; }

    public static bool DumpOnCrash { get; private set; }

    public static CrashDump.Options CrashDumpOptions { get; private set; }

    private static string DumpPath => Path.Combine(Main.SavePath, "Dumps");

    public static void Inititialize()
    {
      Console.WriteLine("Error Logging Enabled.");
      AppDomain.CurrentDomain.FirstChanceException += (EventHandler<FirstChanceExceptionEventArgs>) ((sender, exceptionArgs) =>
      {
        if (!CrashWatcher.LogAllExceptions)
          return;
        Console.Write("================\r\n" + string.Format("{0}: First-Chance Exception\r\nThread: {1} [{2}]\r\nCulture: {3}\r\nException: {4}\r\n", (object) DateTime.Now, (object) Thread.CurrentThread.ManagedThreadId, (object) Thread.CurrentThread.Name, (object) Thread.CurrentThread.CurrentCulture.Name, (object) exceptionArgs.Exception.ToString()) + "================\r\n\r\n");
      });
      AppDomain.CurrentDomain.UnhandledException += (UnhandledExceptionEventHandler) ((sender, exceptionArgs) =>
      {
        Console.Write("================\r\n" + string.Format("{0}: Unhandled Exception\r\nThread: {1} [{2}]\r\nCulture: {3}\r\nException: {4}\r\n", (object) DateTime.Now, (object) Thread.CurrentThread.ManagedThreadId, (object) Thread.CurrentThread.Name, (object) Thread.CurrentThread.CurrentCulture.Name, (object) exceptionArgs.ExceptionObject.ToString()) + "================\r\n");
        if (!CrashWatcher.DumpOnCrash)
          return;
        CrashDump.WriteException(CrashWatcher.CrashDumpOptions, CrashWatcher.DumpPath);
      });
    }

    public static void EnableCrashDumps(CrashDump.Options options)
    {
      CrashWatcher.DumpOnCrash = true;
      CrashWatcher.CrashDumpOptions = options;
    }

    public static void DisableCrashDumps() => CrashWatcher.DumpOnCrash = false;

    [Conditional("DEBUG")]
    private static void HookDebugExceptionDialog()
    {
    }
  }
}
