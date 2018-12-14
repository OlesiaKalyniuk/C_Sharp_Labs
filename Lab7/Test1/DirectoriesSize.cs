using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab7
{
    internal class DirectoriesSize : WatchDogs
    {
        #region Fields
        private string Path { get; set; }
        private string Space { get; set; }
        public static long FullSize { get; private set; }

        protected static object locker = new object();
        #endregion 

        public DirectoriesSize(string newPath)
        {
            Path = newPath;
            Space = "";
        }

        public void getAllFiles()
        {
            lock (locker)
            {
                StringBuilder sp = new StringBuilder(Space).Append("   ");

                string[] dirs = Directory.GetDirectories(Path);
                string[] files = Directory.GetFiles(Path);

                FullSize += files.Select(file => new FileInfo(file).Length).Sum();
                //Console.WriteLine("this fullSize is {0}", FullSize);

                foreach (var dir in dirs)
                {
                    Console.WriteLine(Space + dir);

                    DirectoriesSize dr = new DirectoriesSize(dir)
                    {
                        Space = sp.ToString(),
                    };

                    Thread thread = new Thread(dr.getAllFiles);
                    //Console.WriteLine("{0}New thread was starter at directory {1}",
                    //sp.ToString().Replace(' ', '-'), new DirectoryInfo(dir).Name);
                    thread.Start();
                    WatchDogs.Threads.Add(thread);
                }

                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    Console.WriteLine(Space + fileInfo.Name);
                }
            }
        }
    }
}
