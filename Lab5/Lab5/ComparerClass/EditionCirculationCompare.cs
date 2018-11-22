using System.Collections.Generic;
using Lab5.Models;

namespace Lab5.ComparerClass
{
    internal class EditionCirculationCompare:IComparer<Edition>
    {
        public int Compare(Edition x, Edition y)
        {
            if (x.EditionCirculation.CompareTo(y.EditionCirculation) != 0)
            {
                return x.EditionCirculation.CompareTo(y.EditionCirculation);
            }

            return 0;
        }
    }
}