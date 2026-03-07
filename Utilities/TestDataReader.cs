using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace AutomationFramework.Utilities
{
    public class TestDataReader
    {
        // ─── Login Data ───────────────────────────────────────────────────────────
        private static string loginFilePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "TestData",
            "LoginTestData.json");

        public static (string Username, string Password) GetLoginData(string key)
        {
            var jsonData = File.ReadAllText(loginFilePath);
            var jsonObject = JObject.Parse(jsonData);
            var userData = jsonObject[key];
            return (
                userData["Username"].ToString(),
                userData["Password"].ToString()
            );
        }

        // ─── Payment Data ─────────────────────────────────────────────────────────
        private static string paymentFilePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "TestData",
            "PaymentData.json");

        public static (string FirstName, string LastName, string PostalCode) GetPaymentData(string key)
        {
            var jsonData = File.ReadAllText(paymentFilePath);
            var jsonObject = JObject.Parse(jsonData);
            var paymentData = jsonObject[key];
            return (
                paymentData["FirstName"].ToString(),
                paymentData["LastName"].ToString(),
                paymentData["PostalCode"].ToString()
            );
        }
    }
}
