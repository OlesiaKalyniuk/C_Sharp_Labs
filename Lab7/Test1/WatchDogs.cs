using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Lab7
{
    internal class WatchDogs
    {
        protected static List<Thread> Threads = new List<Thread>();

        public static void Watch()
        {
            for (int i = 0; i < Threads.Count; i++)
            {
                Threads[i].Join();
            }

            Console.WriteLine($"----------- Full size is ({DirectoriesSize.FullSize.ToString("N0")}) bytes -----------");
        }

    }
}
