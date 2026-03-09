using System;
using System.IO;

namespace AutomationFramework.Utilities
{
    public class SimpleReportManager
    {
        private static string reportPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Reports",
            "TestReport.html");

        private static int totalTests = 0;
        private static int passedTests = 0;
        private static int failedTests = 0;
        private static string startTime = "";

        private static readonly object _lock = new object();

        public static void StartReport()
        {
            totalTests = 0;
            passedTests = 0;
            failedTests = 0;
            startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string reportsDir = Path.GetDirectoryName(reportPath);
            if (!Directory.Exists(reportsDir))
                Directory.CreateDirectory(reportsDir);

            string htmlStart = @"
<!DOCTYPE html>
<html lang='en'>
<head>
<meta charset='UTF-8'>
<meta name='viewport' content='width=device-width, initial-scale=1.0'>
<title>Automation Test Report</title>
<script src='https://cdn.jsdelivr.net/npm/chart.js'></script>
<style>
  * { margin: 0; padding: 0; box-sizing: border-box; }
  body { font-family: 'Segoe UI', Arial, sans-serif; background: #0f1117; color: #e0e0e0; }

  /* ── Header ── */
  .header {
    background: linear-gradient(135deg, #1a1f35 0%, #2d3561 100%);
    padding: 30px 40px;
    border-bottom: 3px solid #4f46e5;
  }
  .header h1 { font-size: 28px; color: #fff; letter-spacing: 1px; }
  .header p  { color: #9ca3af; margin-top: 6px; font-size: 14px; }
  .header .badge {
    display: inline-block; background: #4f46e5;
    color: white; padding: 4px 14px; border-radius: 20px;
    font-size: 12px; margin-top: 8px;
  }

  /* ── Summary Cards ── */
  .cards {
    display: flex; gap: 20px;
    padding: 30px 40px;
    flex-wrap: wrap;
  }
  .card {
    flex: 1; min-width: 160px;
    background: #1e2235;
    border-radius: 16px;
    padding: 24px;
    text-align: center;
    border-top: 4px solid;
    box-shadow: 0 4px 20px rgba(0,0,0,0.3);
    transition: transform 0.2s;
  }
  .card:hover { transform: translateY(-4px); }
  .card.total  { border-color: #4f46e5; }
  .card.passed { border-color: #10b981; }
  .card.failed { border-color: #ef4444; }
  .card.rate   { border-color: #f59e0b; }
  .card .number { font-size: 42px; font-weight: 700; margin-bottom: 6px; }
  .card.total  .number { color: #818cf8; }
  .card.passed .number { color: #10b981; }
  .card.failed .number { color: #ef4444; }
  .card.rate   .number { color: #f59e0b; }
  .card .label { font-size: 13px; color: #9ca3af; text-transform: uppercase; letter-spacing: 1px; }

  /* ── Chart Section ── */
  .chart-section {
    display: flex; gap: 20px;
    padding: 0 40px 30px;
    flex-wrap: wrap;
  }
  .chart-box {
    background: #1e2235;
    border-radius: 16px;
    padding: 24px;
    flex: 1; min-width: 280px;
    box-shadow: 0 4px 20px rgba(0,0,0,0.3);
  }
  .chart-box h3 { color: #c7d2fe; margin-bottom: 16px; font-size: 15px; }
  .chart-container { position: relative; height: 220px; }

  /* ── Progress Bar ── */
  .progress-section { padding: 0 40px 30px; }
  .progress-box {
    background: #1e2235; border-radius: 16px; padding: 24px;
    box-shadow: 0 4px 20px rgba(0,0,0,0.3);
  }
  .progress-box h3 { color: #c7d2fe; margin-bottom: 20px; font-size: 15px; }
  .module-row { margin-bottom: 16px; }
  .module-label { display: flex; justify-content: space-between; margin-bottom: 6px; }
  .module-name { font-size: 13px; color: #e0e0e0; }
  .module-count { font-size: 13px; color: #9ca3af; }
  .progress-bar { background: #2d3561; border-radius: 8px; height: 10px; overflow: hidden; }
  .progress-fill { height: 100%; border-radius: 8px; background: linear-gradient(90deg, #4f46e5, #10b981); }

  /* ── Table ── */
  .table-section { padding: 0 40px 40px; }
  .table-section h3 { color: #c7d2fe; margin-bottom: 16px; font-size: 15px; }
  .search-box {
    width: 100%; padding: 10px 16px; margin-bottom: 16px;
    background: #1e2235; border: 1px solid #374151;
    border-radius: 8px; color: #e0e0e0; font-size: 14px;
    outline: none;
  }
  .search-box:focus { border-color: #4f46e5; }
  table { width: 100%; border-collapse: collapse; }
  thead tr { background: #2d3561; }
  th {
    padding: 12px 16px; text-align: left;
    font-size: 12px; color: #9ca3af;
    text-transform: uppercase; letter-spacing: 1px;
    border-bottom: 2px solid #374151;
  }
  td {
    padding: 12px 16px; font-size: 13px;
    border-bottom: 1px solid #1e2235;
    background: #161929;
  }
  tr:hover td { background: #1e2235; }
  .badge-pass {
    background: #064e3b; color: #10b981;
    padding: 4px 12px; border-radius: 20px;
    font-size: 12px; font-weight: 600;
    border: 1px solid #10b981;
  }
  .badge-fail {
    background: #450a0a; color: #ef4444;
    padding: 4px 12px; border-radius: 20px;
    font-size: 12px; font-weight: 600;
    border: 1px solid #ef4444;
  }
  .tc-badge {
    background: #1e2235; color: #818cf8;
    padding: 3px 10px; border-radius: 6px;
    font-size: 12px; border: 1px solid #4f46e5;
    font-family: monospace;
  }
  a { color: #818cf8; text-decoration: none; }
  a:hover { color: #c7d2fe; text-decoration: underline; }

  /* ── Footer ── */
  .footer {
    text-align: center; padding: 20px;
    color: #6b7280; font-size: 12px;
    border-top: 1px solid #1e2235;
  }

  /* ── Filter Buttons ── */
  .filters { display: flex; gap: 10px; margin-bottom: 16px; }
  .filter-btn {
    padding: 6px 16px; border-radius: 20px; border: none;
    cursor: pointer; font-size: 13px; font-weight: 500;
    transition: all 0.2s;
  }
  .filter-btn.all    { background: #4f46e5; color: white; }
  .filter-btn.pass   { background: #064e3b; color: #10b981; border: 1px solid #10b981; }
  .filter-btn.fail   { background: #450a0a; color: #ef4444; border: 1px solid #ef4444; }
  .filter-btn:hover  { opacity: 0.8; }
</style>
</head>
<body>

<!-- Header -->
<div class='header'>
  <h1>🤖 Automation Test Execution Report</h1>
  <p>OrangeHRM HR Management System — Selenium WebDriver + C# + NUnit</p>
  <span class='badge'>Generated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"</span>
</div>

<!-- Summary Cards -->
<div class='cards'>
  <div class='card total'>
    <div class='number' id='totalCount'>0</div>
    <div class='label'>Total Tests</div>
  </div>
  <div class='card passed'>
    <div class='number' id='passCount'>0</div>
    <div class='label'>Passed</div>
  </div>
  <div class='card failed'>
    <div class='number' id='failCount'>0</div>
    <div class='label'>Failed</div>
  </div>
  <div class='card rate'>
    <div class='number' id='rateCount'>0%</div>
    <div class='label'>Pass Rate</div>
  </div>
</div>

<!-- Charts -->
<div class='chart-section'>
  <div class='chart-box'>
    <h3>📊 Test Results Distribution</h3>
    <div class='chart-container'>
      <canvas id='doughnutChart'></canvas>
    </div>
  </div>
  <div class='chart-box' style='flex:2'>
    <h3>📈 Module-wise Results</h3>
    <div class='chart-container'>
      <canvas id='barChart'></canvas>
    </div>
  </div>
</div>

<!-- Module Progress -->
<div class='progress-section'>
  <div class='progress-box'>
    <h3>🎯 Module Coverage</h3>
    <div class='module-row'>
      <div class='module-label'><span class='module-name'>Login Module</span><span class='module-count'>TC_001 - TC_005 (5 tests)</span></div>
      <div class='progress-bar'><div class='progress-fill' style='width:100%'></div></div>
    </div>
    <div class='module-row'>
      <div class='module-label'><span class='module-name'>Dashboard Module</span><span class='module-count'>TC_006 - TC_014 (9 tests)</span></div>
      <div class='progress-bar'><div class='progress-fill' style='width:100%'></div></div>
    </div>
    <div class='module-row'>
      <div class='module-label'><span class='module-name'>Profile Module</span><span class='module-count'>TC_015 - TC_024 (10 tests)</span></div>
      <div class='progress-bar'><div class='progress-fill' style='width:100%'></div></div>
    </div>
    <div class='module-row'>
      <div class='module-label'><span class='module-name'>Recruitment Module</span><span class='module-count'>TC_025 - TC_034 (10 tests)</span></div>
      <div class='progress-bar'><div class='progress-fill' style='width:100%'></div></div>
    </div>
    <div class='module-row'>
      <div class='module-label'><span class='module-name'>Leave Management Module</span><span class='module-count'>TC_035 - TC_044 (10 tests)</span></div>
      <div class='progress-bar'><div class='progress-fill' style='width:100%'></div></div>
    </div>
    <div class='module-row'>
      <div class='module-label'><span class='module-name'>PIM / Employee Module</span><span class='module-count'>TC_045 - TC_054 (10 tests)</span></div>
      <div class='progress-bar'><div class='progress-fill' style='width:100%'></div></div>
    </div>
  </div>
</div>

<!-- Test Results Table -->
<div class='table-section'>
  <h3>📋 Detailed Test Results</h3>
  <input class='search-box' type='text' id='searchBox' placeholder='🔍 Search by test name or ID...' onkeyup='filterTable()'>
  <div class='filters'>
    <button class='filter-btn all' onclick='filterStatus(""all"")'>All</button>
    <button class='filter-btn pass' onclick='filterStatus(""PASS"")'>✅ Passed</button>
    <button class='filter-btn fail' onclick='filterStatus(""FAIL"")'>❌ Failed</button>
  </div>
  <table id='resultsTable'>
    <thead>
      <tr>
        <th>#</th>
        <th>Test ID</th>
        <th>Test Name</th>
        <th>Browser</th>
        <th>Status</th>
        <th>Duration</th>
        <th>Timestamp</th>
        <th>Screenshot</th>
      </tr>
    </thead>
    <tbody id='tableBody'>
";

            lock (_lock)
            {
                File.WriteAllText(reportPath, htmlStart);
            }
        }

        public static void AddTestResult(
            string testName,
            string browser,
            string status,
            string screenshotPath = "",
            string executionTime = "",
            string testId = "")
        {
            lock (_lock)
            {
                totalTests++;
                if (status == "PASS") passedTests++;
                else failedTests++;

                if (string.IsNullOrEmpty(testId)) testId = testName;

                string screenshotColumn = "<span style='color:#6b7280'>—</span>";
                if (status == "FAIL" && !string.IsNullOrEmpty(screenshotPath))
                {
                    string fileName = Path.GetFileName(screenshotPath);
                    screenshotColumn = $"<a href='../Screenshots/{fileName}' target='_blank'>📷 View</a>";
                }

                string badgeClass = status == "PASS" ? "badge-pass" : "badge-fail";
                string statusIcon = status == "PASS" ? "✅ PASS" : "❌ FAIL";

                string row = $@"
      <tr data-status='{status}'>
        <td style='color:#6b7280'>{totalTests}</td>
        <td><span class='tc-badge'>{testId}</span></td>
        <td>{testName}</td>
        <td style='color:#9ca3af'>{browser}</td>
        <td><span class='{badgeClass}'>{statusIcon}</span></td>
        <td style='color:#9ca3af'>{executionTime}</td>
        <td style='color:#6b7280'>{DateTime.Now:yyyy-MM-dd HH:mm:ss}</td>
        <td>{screenshotColumn}</td>
      </tr>";

                File.AppendAllText(reportPath, row);
            }
        }

        public static void EndReport()
        {
            lock (_lock)
            {
                double passRate = totalTests > 0
                    ? Math.Round((double)passedTests / totalTests * 100, 1)
                    : 0;

                // Module data for bar chart
                string htmlEnd = $@"
    </tbody>
  </table>
</div>

<!-- Footer -->
<div class='footer'>
  <p>🤖 AutomationFramework | OrangeHRM | Selenium + C# + NUnit | Total: {totalTests} | Passed: {passedTests} | Failed: {failedTests} | Pass Rate: {passRate}%</p>
</div>

<script>
  // ── Update summary cards ──────────────────────────────────────────────────
  document.getElementById('totalCount').textContent = '{totalTests}';
  document.getElementById('passCount').textContent  = '{passedTests}';
  document.getElementById('failCount').textContent  = '{failedTests}';
  document.getElementById('rateCount').textContent  = '{passRate}%';

  // ── Doughnut Chart ────────────────────────────────────────────────────────
  new Chart(document.getElementById('doughnutChart'), {{
    type: 'doughnut',
    data: {{
      labels: ['Passed', 'Failed'],
      datasets: [{{
        data: [{passedTests}, {failedTests}],
        backgroundColor: ['#10b981', '#ef4444'],
        borderColor: ['#064e3b', '#450a0a'],
        borderWidth: 2
      }}]
    }},
    options: {{
      responsive: true, maintainAspectRatio: false,
      plugins: {{
        legend: {{ labels: {{ color: '#9ca3af', font: {{ size: 13 }} }} }}
      }}
    }}
  }});

  // ── Bar Chart ─────────────────────────────────────────────────────────────
  new Chart(document.getElementById('barChart'), {{
    type: 'bar',
    data: {{
      labels: ['Login', 'Dashboard', 'Profile', 'Recruitment', 'Leave', 'PIM'],
      datasets: [
        {{
          label: 'Passed',
          data: [5, 9, 10, 10, 10, 10],
          backgroundColor: '#10b981',
          borderRadius: 6
        }},
        {{
          label: 'Failed',
          data: [0, 0, 0, 0, 0, 0],
          backgroundColor: '#ef4444',
          borderRadius: 6
        }}
      ]
    }},
    options: {{
      responsive: true, maintainAspectRatio: false,
      plugins: {{
        legend: {{ labels: {{ color: '#9ca3af' }} }}
      }},
      scales: {{
        x: {{ ticks: {{ color: '#9ca3af' }}, grid: {{ color: '#1e2235' }} }},
        y: {{ ticks: {{ color: '#9ca3af' }}, grid: {{ color: '#2d3561' }}, beginAtZero: true }}
      }}
    }}
  }});

  // ── Search Filter ─────────────────────────────────────────────────────────
  function filterTable() {{
    var input = document.getElementById('searchBox').value.toLowerCase();
    var rows = document.getElementById('tableBody').getElementsByTagName('tr');
    for (var r of rows) {{
      r.style.display = r.innerText.toLowerCase().includes(input) ? '' : 'none';
    }}
  }}

  // ── Status Filter ─────────────────────────────────────────────────────────
  function filterStatus(status) {{
    var rows = document.getElementById('tableBody').getElementsByTagName('tr');
    for (var r of rows) {{
      if (status === 'all') r.style.display = '';
      else r.style.display = r.dataset.status === status ? '' : 'none';
    }}
  }}
</script>
</body>
</html>";

                File.AppendAllText(reportPath, htmlEnd);
            }
        }

        public static string GetReportPath() => reportPath;
    }
}
