// Decompiled with JetBrains decompiler
// Type: Terraria.DataStructures.GeneralIssueReporter
// Assembly: Terraria, Version=1.4.2.3, Culture=neutral, PublicKeyToken=null
// MVID: CC2A2C63-7DF6-46E1-B671-4B1A62E8F2AC
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using System.Collections.Generic;

namespace Terraria.DataStructures
{
  public class GeneralIssueReporter : IProvideReports
  {
    private List<IssueReport> _reports = new List<IssueReport>();

    public void AddReport(string textToShow) => this._reports.Add(new IssueReport(textToShow));

    public List<IssueReport> GetReports() => this._reports;
  }
}
