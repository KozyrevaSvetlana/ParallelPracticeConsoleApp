namespace ParallelPracticeConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var path = @"C:\Users\Света\OneDrive\Рабочий стол\test";
            await FileHandler.GetParallelFiles(path);
        }
    }
}
