
static class GarbageCollector
{
    public static void execute()
    {
        System.GC.Collect();
        System.GC.WaitForPendingFinalizers();
    }
}
