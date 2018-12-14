using System; 
using System.Threading;

namespace Lab7
{       
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\SteamLibrary";

            new DirectoriesSize(path).getAllFiles();

            new Thread(WatchDogs.Watch).Start();

            Console.Read();
        }
    }
}
