using System;
using System.IO;

namespace AutomationFramework.Utilities
{
    /// <summary>
    /// LoggerManager - Writes execution logs to log files for debugging and traceability.
    /// Logs are saved to the /Logs/execution.log file with timestamp, level, and message.
    /// </summary>
    public static class LoggerManager
    {
        private static readonly string LogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private static readonly string LogFilePath = Path.Combine(LogDirectory, "execution.log");
        private static readonly object _lock = new object();

        static LoggerManager()
        {
            // Ensure Logs directory exists on first use
            if (!Directory.Exists(LogDirectory))
                Directory.CreateDirectory(LogDirectory);
        }

        // ─── Public Logging Methods ───────────────────────────────────────────────

        /// <summary>Logs an informational message.</summary>
        public static void Info(string message)
        {
            WriteLog("INFO", message);
        }

        /// <summary>Logs a warning message.</summary>
        public static void Warn(string message)
        {
            WriteLog("WARN", message);
        }

        /// <summary>Logs an error message.</summary>
        public static void Error(string message)
        {
            WriteLog("ERROR", message);
        }

        /// <summary>Logs an error message with exception details.</summary>
        public static void Error(string message, Exception ex)
        {
            WriteLog("ERROR", $"{message} | Exception: {ex.Message} | StackTrace: {ex.StackTrace}");
        }

        /// <summary>Logs a debug message (detailed tracing).</summary>
        public static void Debug(string message)
        {
            WriteLog("DEBUG", message);
        }

        /// <summary>Logs a test start event.</summary>
        public static void TestStart(string testName)
        {
            WriteLog("INFO", $"===== TEST STARTED: {testName} =====");
        }

        /// <summary>Logs a test pass event.</summary>
        public static void TestPass(string testName)
        {
            WriteLog("PASS", $"===== TEST PASSED: {testName} =====");
        }

        /// <summary>Logs a test fail event.</summary>
        public static void TestFail(string testName, string reason = "")
        {
            WriteLog("FAIL", $"===== TEST FAILED: {testName} {(string.IsNullOrEmpty(reason) ? "" : "| Reason: " + reason)} =====");
        }

        // ─── Core Write Method ────────────────────────────────────────────────────

        private static void WriteLog(string level, string message)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level,-5}] {message}";

            // Thread-safe file write
            lock (_lock)
            {
                File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
            }

            // Also print to console for real-time visibility during test runs
            Console.WriteLine(logEntry);
        }

        // ─── Utility Methods ──────────────────────────────────────────────────────

        /// <summary>Clears the log file (call at start of new test run if needed).</summary>
        public static void ClearLog()
        {
            lock (_lock)
            {
                File.WriteAllText(LogFilePath, string.Empty);
            }
        }

        /// <summary>Returns the full path to the current log file.</summary>
        public static string GetLogFilePath() => LogFilePath;
    }
}