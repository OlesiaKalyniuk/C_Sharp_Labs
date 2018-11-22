using System;
using System.Linq;
using Lab4.Collections;
using Lab4.DelegateClass;

namespace Lab4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MagazineCollection mag1 = new MagazineCollection();
            MagazineCollection mag2 = new MagazineCollection();
            mag1.CollectionName = "mag1";
            mag2.CollectionName = "mag2";
            
            Listener lis1 = new Listener();
            mag1.MagazineAdded += lis1.AddEvent;
            mag1.MagazineReplaced += lis1.AddEvent;
            
            Listener lis2 = new Listener();
            mag1.MagazineAdded += lis2.AddEvent;
            mag2.MagazineAdded += lis2.AddEvent;
            mag1.MagazineReplaced += lis2.AddEvent;
            mag2.MagazineReplaced += lis2.AddEvent;
            
            mag1.AddMagazines(new Magazine());
            mag2.AddMagazines(new Magazine());
            mag1.AddDefaults();
            mag2.AddDefaults();
            
            mag1.Magazines.Remove(mag1[2]);
            mag2.Magazines.Remove(mag2[2]);
            
            mag1.AddDefaults();
            mag2.AddDefaults();
            
            mag1[2] = new Magazine();
            mag1.Replace(1, new Magazine());
            mag2[2] = new Magazine();
            mag2.Replace(1, new Magazine());
            
            Console.WriteLine("-------------LISTENER-1-------------");
            Console.WriteLine(lis1);
            Console.WriteLine("-------------LISTENER-2-------------");
            Console.WriteLine(lis2);
            
        }
    }
}