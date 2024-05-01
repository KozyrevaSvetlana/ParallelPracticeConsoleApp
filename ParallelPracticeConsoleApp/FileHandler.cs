using System.Diagnostics;

namespace ParallelPracticeConsoleApp
{
    public static class FileHandler
    {
        public static async Task GetParallelFiles(string path)
        {
            var files = Directory.GetFiles(path);
            var tasks = files.Select(file => FileHandler.GetWhiteSpacesFromFile(file)).ToList();
            await Task.WhenAll(tasks);
        }

        public static async Task<int> GetWhiteSpacesFromFile(string path)
        {
            if (File.Exists(path))
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var lines = await File.ReadAllLinesAsync(path);
                var sum = lines.SelectMany(line => line.ToCharArray()).Where(x => char.IsWhiteSpace(x)).Count();
                stopWatch.Stop();
                var ts = stopWatch.Elapsed;
                Console.WriteLine($"Время выполнения: {ts.Milliseconds} мс, количество пробелов - {sum}, путь к файлу {path}");
                return sum;
            }
            else
            {
                throw new NullReferenceException($"По пути {path} файл не найден");
            }
        }
    }
}
