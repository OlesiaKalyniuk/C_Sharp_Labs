using System;

namespace Lab1
{
    internal class Program
    {
        public static void Main(string[] args)
        {            
            Person vasiaIvanov = new Person("Vasia", "Ivanov", new DateTime(1998, 12, 12));
            Article firstArtucle = new Article(vasiaIvanov, "First", 10);
            Magazine firstMagazine = new Magazine();

            Console.WriteLine("First task is (toShortString):\n" + firstMagazine.ToShortString());
            Console.WriteLine("Second task is (Frequency):\n" + Frequency.Monthly + " " + Frequency.Weekly + " " + Frequency.Yearly);

            firstMagazine = new Magazine("My magazine", Frequency.Monthly, DateTime.Today, 10, new[] { firstArtucle });
            Console.WriteLine("Third task is (toString + magazine all params):\n" + firstMagazine);

            firstMagazine.AddArticles(firstArtucle, firstArtucle);
            Console.WriteLine("Fourth task is (toString + AddArticles):\n" + firstMagazine.ToString());

            Console.WriteLine("Fifth task is (timer in massifs):\n");
            string inputText = Console.ReadLine();
            
            int nRows = Int32.Parse(inputText.Split(' ')[0]);
            int mColumns = Int32.Parse(inputText.Split(' ')[1]);

            int sum = 0;
            int size = 0;
            while (sum < nRows * mColumns) {
                sum += ++size;
            }

            Article[] oneDimension = new Article[nRows*mColumns];
            Article[,] twoDimension = new Article[nRows,mColumns];
            Article[][] cogged = new Article[size][];

            var timeStart = Environment.TickCount;
            for (int i = 0; i < nRows*mColumns; i++)
            {
                oneDimension[i] = firstArtucle;
            }
            var timeEnd = Environment.TickCount;
            Console.WriteLine("\nOne dimension is: " + (timeEnd - timeStart));

            timeStart = Environment.TickCount;
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < mColumns; j++)
                {
                    twoDimension[i, j] = firstArtucle;
                }
            }
            timeEnd = Environment.TickCount;
            Console.WriteLine("\nTwo dimension is: " + (timeEnd - timeStart));
            
            for (int i = 0; i < size; i++)
            {
                if(i == size-1) {
                    cogged[i] = new Article[ nRows*mColumns - (sum - size) ];
                    break;
                }
                cogged[i] = new Article[i + 1];
            }
            
            timeStart = Environment.TickCount;
            foreach (var lineArray in cogged)
            {
                for (var j = 0; j < lineArray.Length; j++)
                {
                    lineArray[j] = firstArtucle;
                }
            }
            timeEnd = Environment.TickCount;
            Console.WriteLine("\nTwo dimension2 is: " + (timeEnd - timeStart));

            Console.Read();
        }
    }
}