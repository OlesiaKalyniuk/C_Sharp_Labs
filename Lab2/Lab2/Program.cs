using System;
using System.Collections;

namespace Lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Edition first = new Edition();
            Edition second = new Edition();
            
            Console.WriteLine("First task equals : ");
            Console.WriteLine(" == : " + (first == second));
            Console.WriteLine(" Equals : " + first.Equals(second));
            Console.WriteLine(" Hash : " + first.GetHashCode() + " " + second.GetHashCode());

            Console.WriteLine("\nSecond task exception : ");
            try
            {
                first.EditionCirculation = -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }
            
            Console.WriteLine("\nThird task add Articles and Editors : ");
            Magazine magazine = new Magazine();
            magazine.AddArticles(new Article(), new Article());
            magazine.AddEditors(new Person(), new Person());
            Console.WriteLine(magazine);
            
            Console.WriteLine("\nFourth task show Edition from Magazine : ");
            Console.WriteLine(magazine.EditionBase);
            
            Console.WriteLine("\nFifth task DeepCopy : ");
            Magazine magazineCopy = (Magazine)magazine.DeepCopy();
            magazine.MagazineName = "Original";
            Console.WriteLine(magazine.MagazineName + " != " + magazineCopy.MagazineName);

            double moreThan = 10;
            Console.WriteLine("\nSixth task foreach ArticleRage more than " + moreThan + " : " );
            ((Article) magazine.ArticleList[0]).ArticleRage = 12;
            foreach (var article in magazine.GetArticlesMoreThan(moreThan))
            {
                Console.WriteLine(article);
            }

            string searchText = "New";
            Console.WriteLine("\nSeventh task foreach ArticleName with " + searchText + " : ");
            foreach (var article in magazine.GetArticlesWithText(searchText))
            {
                Console.WriteLine(article);
            }

            Console.ReadKey();
        }
    }
}