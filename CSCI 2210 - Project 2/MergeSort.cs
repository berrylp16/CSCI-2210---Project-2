using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_2210___Project_2
{
    class MergeSort<T> : ISort<T> where T : IComparable<T>
    {
        public List<T> Sort(List<T> intdata)
        {
            if (intdata.Count <= 1)
            {
                return intdata;
            }

            int middle = intdata.Count / 2;
            List<T> left = new List<T>();
            List<T> right = new List<T>();

            for (int i = 0; i < middle; i++)
            {
                left.Add(intdata[i]);
            }

            for (int i = middle; i < intdata.Count; i++)
            {
                right.Add(intdata[i]);
            }

            left = Sort(left);
            right = Sort(right);

            return Merge(left, right);
        }

        public List<T> Merge(List<T> left, List<T> right)
        {
            List<T> result = new List<T>();
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) <= 0)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            while (leftIndex < left.Count)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }

            while (rightIndex < right.Count)
            {
                result.Add(right[rightIndex]);
                rightIndex++;
            }

            return result;
        }

        void ISort<T>.Sort(List<T> stuff)
        {
            throw new NotImplementedException();
        }
    }
}
