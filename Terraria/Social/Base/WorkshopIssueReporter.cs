﻿// Decompiled with JetBrains decompiler
// Type: Terraria.Social.Base.WorkshopIssueReporter
// Assembly: Terraria, Version=1.4.3.6, Culture=neutral, PublicKeyToken=null
// MVID: F541F3E5-89DE-4E5D-868F-1B56DAAB46B2
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria.Localization;

namespace Terraria.Social.Base
{
  public class WorkshopIssueReporter : IProvideReports
  {
    private int _maxReports = 1000;
    private List<IssueReport> _reports = new List<IssueReport>();

    public event Action OnNeedToOpenUI;

    public event Action OnNeedToNotifyUI;

    private void AddReport(string reportText)
    {
      this._reports.Add(new IssueReport(reportText));
      while (this._reports.Count > this._maxReports)
        this._reports.RemoveAt(0);
    }

    public List<IssueReport> GetReports() => this._reports;

    private void OpenReportsScreen()
    {
      if (this.OnNeedToOpenUI == null)
        return;
      this.OnNeedToOpenUI();
    }

    private void NotifyReportsScreen()
    {
      if (this.OnNeedToNotifyUI == null)
        return;
      this.OnNeedToNotifyUI();
    }

    public void ReportInstantUploadProblem(string textKey)
    {
      this.AddReport(Language.GetTextValue(textKey));
      this.OpenReportsScreen();
    }

    public void ReportInstantUploadProblemFromValue(string text)
    {
      this.AddReport(text);
      this.OpenReportsScreen();
    }

    public void ReportDelayedUploadProblem(string textKey)
    {
      this.AddReport(Language.GetTextValue(textKey));
      this.NotifyReportsScreen();
    }

    public void ReportDelayedUploadProblemWithoutKnownReason(string textKey, string reasonValue)
    {
      object obj = (object) new{ Reason = reasonValue };
      this.AddReport(Language.GetTextValueWith(textKey, obj));
      this.NotifyReportsScreen();
    }

    public void ReportDownloadProblem(string textKey, string path, Exception exception)
    {
      object obj = (object) new
      {
        FilePath = path,
        Reason = exception.ToString()
      };
      this.AddReport(Language.GetTextValueWith(textKey, obj));
      this.NotifyReportsScreen();
    }

    public void ReportManifestCreationProblem(string textKey, Exception exception)
    {
      object obj = (object) new
      {
        Reason = exception.ToString()
      };
      this.AddReport(Language.GetTextValueWith(textKey, obj));
      this.NotifyReportsScreen();
    }
  }
}
