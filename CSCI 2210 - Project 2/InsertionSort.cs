using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_2210___Project_2
{
    public class InsertionSort<T> where T : IComparable<T>
    {
        public List<T> Sort(List<T> intdata)
        {
            int n = intdata.Count;

            for (int i = 1; i < n; i++)
            {
                T key = intdata[i];
                int j = i - 1;

                while (j >= 0 && intdata[j].CompareTo(key) > 0)
                {
                    intdata[j + 1] = intdata[j];
                    j = j - 1;
                }

                intdata[j + 1] = key;
            }

            return intdata;
        }
    }
}
