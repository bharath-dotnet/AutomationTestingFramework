using NUnit.Framework;

// ─── Execution Configuration ──────────────────────────────────────────────────
// Sequential execution — browser reused within each class via OneTimeSetUp
// 6 browser launches total instead of 54 → ~3x faster execution
[assembly: Parallelizable(ParallelScope.None)]
