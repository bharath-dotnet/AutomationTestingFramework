# 🤖 Modular UI Test Automation Framework for OrangeHRM using Selenium WebDriver & C#

![.NET](https://img.shields.io/badge/.NET-8.0-purple?style=for-the-badge&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-12.0-blue?style=for-the-badge&logo=csharp)
![Selenium](https://img.shields.io/badge/Selenium-4.x-green?style=for-the-badge&logo=selenium)
![NUnit](https://img.shields.io/badge/NUnit-3.x-orange?style=for-the-badge)
![Docker](https://img.shields.io/badge/Docker-Ready-blue?style=for-the-badge&logo=docker)
![CI/CD](https://img.shields.io/badge/CI%2FCD-GitHub_Actions-black?style=for-the-badge&logo=githubactions)

---

## 📌 Project Overview

This project is a **Modular UI Test Automation Framework** built using **C# and Selenium WebDriver** to automate testing of **OrangeHRM**, a real-world enterprise HR management system used by companies worldwide.
The framework follows the **Page Object Model (POM)** design pattern and covers **30 automated test cases** across **6 critical modules** of the OrangeHRM application. It includes a custom **dark theme HTML report** with charts and graphs, auto screenshots on failure, detailed execution logs, Docker support, and a full CI/CD pipeline via GitHub Actions.

🎯 **Target Application:** [OrangeHRM Live Demo](https://opensource-demo.orangehrmlive.com)

---

## 🏗️ Framework Architecture

```
AutomationFramework/
├── Base/
│   ├── BaseTest.cs              → Browser lifecycle, reporting, logging
│   └── TestRunHook.cs           → One-time report initialization
├── Pages/
│   ├── BasePage.cs              → Reusable Selenium helper methods
│   ├── LoginPage.cs             → Login page locators & actions
│   ├── DashboardPage.cs         → Dashboard locators & actions
│   ├── ProfilePage.cs           → My Info page locators & actions
│   ├── RecruitmentPage.cs       → Recruitment locators & actions
│   ├── LeavePage.cs             → Leave Management locators & actions
│   └── PimPage.cs               → PIM/Employee locators & actions
├── Tests/
│   ├── LoginTests.cs            → TC_001 to TC_005
│   ├── DashboardTests.cs        → TC_006 to TC_010
│   ├── ProfileTests.cs          → TC_011 to TC_015
│   ├── RecruitmentTests.cs      → TC_016 to TC_020
│   ├── LeaveTests.cs            → TC_021 to TC_025
│   └── PimTests.cs              → TC_026 to TC_030
├── Utilities/
│   ├── BrowserFactory.cs        → Chrome/Edge browser factory
│   ├── ConfigReader.cs          → Read appsettings.json
│   ├── TestDataReader.cs        → Read JSON test data
│   ├── ScreenshotHelper.cs      → Auto screenshot on failure
│   ├── SimpleReportManager.cs   → Dark theme HTML report + charts
│   └── LoggerManager.cs         → Timestamped execution logging
├── Testdata/
│   └── LoginTestData.json       → Test input data
├── Docker/
│   └── Dockerfile               → Docker container setup
├── .github/
│   └── workflows/
│       └── github-actions.yml   → CI/CD pipeline
├── ParallelConfig.cs            → Execution configuration
└── appsettings.json             → Browser & URL configuration
```

---

## 🛠️ Technology Stack

| Technology | Version | Purpose |
|------------|---------|---------|
| C# | 12.0 | Primary programming language |
| Selenium WebDriver | 4.x | Browser automation |
| NUnit | 3.x | Test framework |
| .NET | 8.0 | Runtime platform |
| ChromeDriver | Latest | Chrome browser driver |
| Docker | 28.x | Containerization |
| GitHub Actions | - | CI/CD pipeline |

---

## 📋 Test Cases

### Module 1 — Login (TC_001 to TC_005)

| Test ID | Test Name | Type | Status |
|---------|-----------|------|--------|
| TC_001 | Valid Login | Positive | ✅ Pass |
| TC_002 | Invalid Username | Negative | ✅ Pass |
| TC_003 | Invalid Password | Negative | ✅ Pass |
| TC_004 | Empty Fields | Negative | ✅ Pass |
| TC_005 | Login Page Displayed | UI | ✅ Pass |

### Module 2 — Dashboard (TC_006 to TC_010)

| Test ID | Test Name | Type | Status |
|---------|-----------|------|--------|
| TC_006 | Dashboard Loads | Positive | ✅ Pass |
| TC_007 | Dashboard URL Contains | UI | ✅ Pass |
| TC_008 | Sidebar Menu Visible | UI | ✅ Pass |
| TC_009 | Admin Menu Visible | UI | ✅ Pass |
| TC_010 | Logout Redirects To Login | Positive | ✅ Pass |

### Module 3 — Profile / My Info (TC_011 to TC_015)

| Test ID | Test Name | Type | Status |
|---------|-----------|------|--------|
| TC_011 | Profile Page Loaded | Positive | ✅ Pass |
| TC_012 | Profile URL Contains | UI | ✅ Pass |
| TC_013 | First Name Field Visible | UI | ✅ Pass |
| TC_014 | Last Name Field Visible | UI | ✅ Pass |
| TC_015 | Save Button Visible | UI | ✅ Pass |

### Module 4 — Recruitment (TC_016 to TC_020)

| Test ID | Test Name | Type | Status |
|---------|-----------|------|--------|
| TC_016 | Vacancies Page Loads | Positive | ✅ Pass |
| TC_017 | Vacancies URL Contains | UI | ✅ Pass |
| TC_018 | Vacancy Table Displayed | UI | ✅ Pass |
| TC_019 | Add Vacancy Page Loads | Positive | ✅ Pass |
| TC_020 | Save Without Fields Shows Error | Negative | ✅ Pass |

### Module 5 — Leave Management (TC_021 to TC_025)

| Test ID | Test Name | Type | Status |
|---------|-----------|------|--------|
| TC_021 | My Leave Page Loads | Positive | ✅ Pass |
| TC_022 | My Leave URL Contains | UI | ✅ Pass |
| TC_023 | Leave Table Displayed | UI | ✅ Pass |
| TC_024 | Apply Leave Page Loads | Positive | ✅ Pass |
| TC_025 | Apply Leave URL Contains | UI | ✅ Pass |

### Module 6 — PIM / Employee Management (TC_026 to TC_030)

| Test ID | Test Name | Type | Status |
|---------|-----------|------|--------|
| TC_026 | Employee List Page Loads | Positive | ✅ Pass |
| TC_027 | Employee List URL Contains | UI | ✅ Pass |
| TC_028 | Employee Table Displayed | UI | ✅ Pass |
| TC_029 | Add Button Displayed | UI | ✅ Pass |
| TC_030 | Add Employee Page Loads | Positive | ✅ Pass |

**Total: 30 Test Cases | 6 Modules | Positive + Negative + UI Tests**

---

## ⚙️ How To Run Tests

### Prerequisites
```
- .NET 8.0 SDK
- Google Chrome browser
- Visual Studio 2022
```

### Clone the Repository
```bash
git clone https://github.com/bharath-dotnet/AutomationTestingFramework.git
cd AutomationTestingFramework/AutomationFramework
```

### Restore Packages
```bash
dotnet restore
```

### Run All Tests
```bash
dotnet test
```

### Run Specific Module
```bash
dotnet test --filter TestCategory=TC_001
```

---

## 🐳 Run With Docker

```bash
# Build Docker image
docker build -t automation-framework -f Docker/Dockerfile .

# Run tests in container
docker run automation-framework
```

---

## 🔄 CI/CD Pipeline

Every push to main branch automatically:

- ✅ Installs .NET 8 and Chrome
- ✅ Restores NuGet packages
- ✅ Builds the project
- ✅ Runs all 30 test cases
- ✅ Uploads test results as artifact

---

## 📊 Key Features

- ✅ **Page Object Model** — clean separation of locators and test logic
- ✅ **Dark Theme HTML Report** — charts, graphs, pass/fail badges, search and filter
- ✅ **Auto Screenshots** — captures browser state on every test failure
- ✅ **Execution Logs** — timestamped logs for every test step in `/Logs/execution.log`
- ✅ **Data Driven Testing** — test data stored in JSON files
- ✅ **Browser Factory** — supports Chrome and Edge from configuration
- ✅ **Docker Support** — runs on any machine without manual setup
- ✅ **GitHub Actions** — automated testing on every code push

---

## 🎨 Test Report

After execution, open `bin/Debug/net8.0/Reports/TestReport.html` in Chrome to view:

- 📊 Summary cards — Total, Passed, Failed, Pass Rate
- 🍩 Doughnut chart — Pass vs Fail visualization
- 📈 Bar chart — Module wise results
- 📋 Progress bars — Module coverage
- 🔍 Search and filter — filter by test name or status
- 📷 Screenshot links — click to view failure screenshots

---

## 🎨 Design Patterns Used

| Pattern | Implementation |
|---------|---------------|
| Page Object Model | Each page = one class in Pages/ folder |
| Factory Pattern | BrowserFactory creates Chrome or Edge driver |
| Singleton Pattern | LoggerManager static thread-safe logging class |

---

## 👨‍💻 Author

**Bharath kumar N**
Department of Information Technology,
Prathyusha Engineering College, Thiruvallur

---

## 📄 License

This project is for educational purposes.

