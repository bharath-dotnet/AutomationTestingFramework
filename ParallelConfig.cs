using NUnit.Framework;

// ─── Sequential Execution (Stable for OrangeHRM) ─────────────────────────────
// Parallel execution disabled because OrangeHRM demo server has rate limiting
// Tests run sequentially to ensure stability and reliability
[assembly: Parallelizable(ParallelScope.None)]
