namespace FileFin1
{
    internal class Program
    {
        const double timelimit = 30;
        static void Main(string[] args)
        {
            Console.Write("Введите путь до папки: ");
            string path = Console.ReadLine();
            DirFileDelete(path);
        }
        static void DirFileDelete(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                try
                {
                    string[] dirs = Directory.GetDirectories(dirName);
                    foreach (string d in dirs)
                    {
                        bool rez = (DateTime.Now - File.GetLastWriteTime(d)).TotalMinutes >= timelimit;
                        Console.WriteLine(d + " Время: " + File.GetLastWriteTime(d) + " разница: " + rez);
                        if (rez == true) Directory.Delete(d, true);
                        DirFileDelete(d);
                    }
                    string[] files = Directory.GetFiles(dirName);
                    foreach (string s in files)
                    {
                        bool rez = (DateTime.Now - File.GetLastWriteTime(s)).TotalMinutes >= timelimit;
                        Console.WriteLine(s + " Время: " + File.GetLastWriteTime(s) + " разница: " + rez);
                        if (rez == true) File.Delete(s);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex}");
                }
            }
        }
    }
}