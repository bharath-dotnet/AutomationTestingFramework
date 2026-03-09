using NUnit.Framework;

// ─── Parallel Execution Configuration ────────────────────────────────────────
// Runs each TestFixture (class) in parallel — 6 browsers simultaneously
// Each class has its own browser instance via OneTimeSetUp in BaseTest
// This reduces total execution time from ~15 mins to ~3 mins
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(3)]
