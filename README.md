# 🤖 Automation Testing Framework
### Full Stack Web Automation Framework for OrangeHRM using Selenium WebDriver & C#

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![Selenium](https://img.shields.io/badge/Selenium-WebDriver-green)
![NUnit](https://img.shields.io/badge/NUnit-Test%20Framework-blue)
![Docker](https://img.shields.io/badge/Docker-Enabled-blue)
![CI/CD](https://img.shields.io/badge/CI%2FCD-GitHub%20Actions-orange)

---

## 📌 Project Overview

This project is a **full-stack automation testing framework** built using **C# and Selenium WebDriver** to automate testing of **OrangeHRM** — a real-world enterprise HR Management System used by companies worldwide.

The framework follows the **Page Object Model (POM)** design pattern and covers **34 automated test cases** across 4 critical modules of the OrangeHRM application.

> 🎯 **Target Application:** [OrangeHRM Live Demo](https://opensource-demo.orangehrmlive.com/web/index.php/auth/login)

---

## 🏗️ Framework Architecture

```
AutomationFramework/
├── Base/
│   ├── BaseTest.cs          → Setup & TearDown for every test
│   └── TestRunHook.cs       → One-time report initialization
├── Pages/
│   ├── BasePage.cs          → Common Selenium methods
│   ├── LoginPage.cs         → Login page locators & actions
│   ├── DashboardPage.cs     → Dashboard locators & actions
│   ├── ProfilePage.cs       → My Info page locators & actions
│   └── RecruitmentPage.cs   → Recruitment locators & actions
├── Tests/
│   ├── LoginTests.cs        → TC_001 to TC_005
│   ├── DashboardTests.cs    → TC_006 to TC_014
│   ├── ProfileTests.cs      → TC_015 to TC_024
│   └── RecruitmentTests.cs  → TC_025 to TC_034
├── Utilities/
│   ├── BrowserFactory.cs    → Chrome/Edge browser setup
│   ├── ConfigReader.cs      → Read appsettings.json
│   ├── TestDataReader.cs    → Read JSON test data
│   ├── ScreenshotHelper.cs  → Auto screenshot on failure
│   ├── SimpleReportManager.cs → HTML report generation
│   └── LoggerManager.cs     → Execution logging
├── Testdata/
│   └── LoginTestData.json   → Test input data
├── Docker/
│   └── Dockerfile           → Docker container setup
├── .github/
│   └── workflows/
│       └── github-actions.yml → CI/CD pipeline
└── appsettings.json         → Browser & URL configuration
```

---

## 🛠️ Technology Stack

| Technology | Version | Purpose |
|-----------|---------|---------|
| C# | Latest | Programming language |
| Selenium WebDriver | 4.x | Browser automation |
| NUnit | 3.x | Test framework |
| .NET | 8.0 | Runtime platform |
| ChromeDriver | Latest | Chrome browser driver |
| Docker | 28.x | Containerization |
| GitHub Actions | - | CI/CD pipeline |

---

## 📋 Test Cases

### Module 1 — Login (TC_001 to TC_005)
| Test ID | Test Name | Status |
|---------|-----------|--------|
| TC_001 | Valid Login | ✅ Pass |
| TC_002 | Invalid Username | ✅ Pass |
| TC_003 | Invalid Password | ✅ Pass |
| TC_004 | Empty Fields | ✅ Pass |
| TC_005 | Special Characters | ✅ Pass |

### Module 2 — Dashboard (TC_006 to TC_014)
| Test ID | Test Name | Status |
|---------|-----------|--------|
| TC_006 | Dashboard Loads | ✅ Pass |
| TC_007 | Dashboard Header Text | ✅ Pass |
| TC_008 | Dashboard URL | ✅ Pass |
| TC_009 | Sidebar Menu Visible | ✅ Pass |
| TC_010 | Admin Menu Visible | ✅ Pass |
| TC_011 | PIM Menu Visible | ✅ Pass |
| TC_012 | User Dropdown Visible | ✅ Pass |
| TC_013 | Time At Work Widget | ✅ Pass |
| TC_014 | Logout Redirects To Login | ✅ Pass |

### Module 3 — Profile / My Info (TC_015 to TC_024)
| Test ID | Test Name | Status |
|---------|-----------|--------|
| TC_015 | Profile Page Loaded | ✅ Pass |
| TC_016 | Profile Header Text | ✅ Pass |
| TC_017 | Profile URL Contains | ✅ Pass |
| TC_018 | First Name Field Visible | ✅ Pass |
| TC_019 | Last Name Field Visible | ✅ Pass |
| TC_020 | Save Button Visible | ✅ Pass |
| TC_021 | Personal Details Tab Visible | ✅ Pass |
| TC_022 | Contact Details Tab Visible | ✅ Pass |
| TC_023 | Emergency Contacts Tab Visible | ✅ Pass |
| TC_024 | Profile Logout Redirects To Login | ✅ Pass |

### Module 4 — Recruitment (TC_025 to TC_034)
| Test ID | Test Name | Status |
|---------|-----------|--------|
| TC_025 | Vacancies Page Loads | ✅ Pass |
| TC_026 | Vacancies URL Contains | ✅ Pass |
| TC_027 | Vacancy Table Displayed | ✅ Pass |
| TC_028 | Add Vacancy Page Loads | ✅ Pass |
| TC_029 | Vacancy Name Field Visible | ✅ Pass |
| TC_030 | Job Title Dropdown Visible | ✅ Pass |
| TC_031 | Save Button Visible | ✅ Pass |
| TC_032 | Cancel Button Visible | ✅ Pass |
| TC_033 | Save Without Fields Shows Error | ✅ Pass |
| TC_034 | Cancel Redirects To Vacancies | ✅ Pass |

---

## ⚙️ How To Run Tests

### Prerequisites
- .NET 8.0 SDK
- Google Chrome browser
- Visual Studio 2022

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

Every push to `main` branch automatically:
1. ✅ Installs .NET 8 and Chrome
2. ✅ Restores NuGet packages
3. ✅ Builds the project
4. ✅ Runs all 34 test cases
5. ✅ Uploads test results as artifact

---

## 📊 Key Features

- ✅ **Page Object Model** — clean separation of locators and test logic
- ✅ **Data Driven Testing** — test data stored in JSON files
- ✅ **Auto Screenshots** — captures browser state on test failure
- ✅ **HTML Reports** — professional test execution report
- ✅ **Execution Logs** — detailed logs for every test step
- ✅ **Headless Mode** — runs without browser UI in CI/CD
- ✅ **Docker Support** — runs on any machine without setup
- ✅ **GitHub Actions** — automated testing on every code push

---

## 👨‍💻 Author

**Bharath**
Department of Information Technology
Prathyusha Engineering College, Thiruvallur

---

## 📄 License
This project is for educational purposes.
