namespace ParallelPracticeConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // 1. Прочитать 3 файла параллельно и вычислить количество пробелов в них (через Task).
            var filePaths = new List<string>()
            {
                @"C:\Users\Света\OneDrive\Рабочий стол\test\test1.doc",
                @"C:\Users\Света\OneDrive\Рабочий стол\test\test2.doc",
                @"C:\Users\Света\OneDrive\Рабочий стол\test\test3.doc",
            };
            var tasks = filePaths.Select(file => FileHandler.GetWhiteSpacesFromFile(file)).ToList();
            await Task.WhenAll(tasks);

            // 2. Написать функцию, принимающую в качестве аргумента путь к папке. Из этой папки параллельно прочитать все файлы и вычислить количество пробелов в них.
            // 3. Замерьте время выполнения кода (класс Stopwatch).
            var path = @"C:\Users\Света\OneDrive\Рабочий стол\test";
            await FileHandler.GetParallelFiles(path);
        }
    }
}
