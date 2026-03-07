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

        private static readonly object _lock = new object();

        // START REPORT
        public static void StartReport()
        {
            totalTests = 0;
            passedTests = 0;
            failedTests = 0;

            string reportsDir = Path.GetDirectoryName(reportPath);
            if (!Directory.Exists(reportsDir))
                Directory.CreateDirectory(reportsDir);

            string htmlStart = @"
<!DOCTYPE html>
<html>
<head>
<title>Automation Test Execution Report</title>
<style>
body{font-family:Arial;background:#f4f6f9;padding:20px;}
h2{text-align:center;color:#2c3e50;}
table{width:100%;border-collapse:collapse;margin-top:20px;}
th,td{border:1px solid #ddd;padding:10px;text-align:center;}
th{background:#2c3e50;color:white;}
.pass{color:green;font-weight:bold;}
.fail{color:red;font-weight:bold;}
.summary{font-weight:bold;background:#ecf0f1;font-size:15px;}
tr:hover{background:#f0f4f8;}
.badge-pass{background:#27ae60;color:white;padding:3px 10px;border-radius:12px;}
.badge-fail{background:#e74c3c;color:white;padding:3px 10px;border-radius:12px;}
</style>
</head>
<body>
<h2>Automation Test Execution Report</h2>
<p style='text-align:center;color:#666;'>Generated: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + @"</p>

<table>
<tr>
<th>#</th>
<th>Test ID</th>
<th>Test Name</th>
<th>Browser</th>
<th>Status</th>
<th>Execution Time</th>
<th>Execution Date</th>
<th>Screenshot</th>
</tr>";

            lock (_lock)
            {
                File.WriteAllText(reportPath, htmlStart);
            }
        }

        // ADD TEST RESULT
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

                if (status == "PASS")
                    passedTests++;
                else
                    failedTests++;

                if (string.IsNullOrEmpty(testId))
                    testId = testName;

                string screenshotColumn = "-";

                if (status == "FAIL" && !string.IsNullOrEmpty(screenshotPath))
                {
                    string fileName = Path.GetFileName(screenshotPath);
                    screenshotColumn = $"<a href='../Screenshots/{fileName}' target='_blank'>View</a>";
                }

                string badgeClass = status == "PASS" ? "badge-pass" : "badge-fail";

                string row = $@"
<tr>
<td>{totalTests}</td>
<td>{testId}</td>
<td style='text-align:left'>{testName}</td>
<td>{browser}</td>
<td><span class='{badgeClass}'>{status}</span></td>
<td>{executionTime}</td>
<td>{DateTime.Now:yyyy-MM-dd HH:mm:ss}</td>
<td>{screenshotColumn}</td>
</tr>";

                File.AppendAllText(reportPath, row);
            }
        }

        // END REPORT
        public static void EndReport()
        {
            lock (_lock)
            {
                double passRate = totalTests > 0
                    ? Math.Round((double)passedTests / totalTests * 100, 1)
                    : 0;

                string summaryRow = $@"
<tr class='summary'>
<td colspan='8' style='text-align:left;padding:14px'>
Total Tests: {totalTests} |
Passed: {passedTests} |
Failed: {failedTests} |
Pass Rate: {passRate}%
</td>
</tr>";

                string htmlEnd = @"
</table>
</body>
</html>";

                File.AppendAllText(reportPath, summaryRow);
                File.AppendAllText(reportPath, htmlEnd);
            }
        }

        public static string GetReportPath() => reportPath;
    }
}