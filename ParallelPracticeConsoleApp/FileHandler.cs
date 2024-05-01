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

        private static async Task<int> GetWhiteSpacesFromFile(string path)
        {
            if (File.Exists(path))
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                var lines = await File.ReadAllLinesAsync(path);
                var sum = lines.SelectMany(line => line.ToCharArray()).Where(x => char.IsWhiteSpace(x)).Count();
                stopWatch.Stop();
                Console.WriteLine($"для файла {path} количество пробелов - {sum}");
                var ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}", ts.Seconds, ts.Milliseconds / 10);
                Console.WriteLine($"Время выполнения: {elapsedTime}");
                return sum;
            }
            else
            {
                throw new NullReferenceException($"По пути {path} файл не найден");
            }
        }
    }
}
