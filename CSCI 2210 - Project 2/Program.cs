/////////////////////////////////////////////
/// Authors: Luke Berry, berrylp@etsu.edu; Joe Rutherford, rutherfordjd@etsu.edu
/// Course: CSCI - 2210 - 001 - Data Structures
/// Assignment: Project 2 - Sorting Algorithms
/// Description: Create a program that sorts generic objects from a text file
/////////////////////////////////////////////
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Concurrent;
using System.IO.Pipes;

public interface ISort<T> where T : IComparable<T>
{
    public void Sort(List<T> stuff);
}
class MergeSort<T> : ISort<T> where T : IComparable<T>
{
    public List<T> Sort(List<T> stuff)
    {
        if (stuff.Count <= 1)
        {
            return stuff;
        }

        int middle = stuff.Count / 2;
        List<T> left = new List<T>();
        List<T> right = new List<T>();

        for (int i = 0; i < middle; i++)
        {
            left.Add(stuff[i]);
        }

        for (int i = middle; i < stuff.Count; i++)
        {
            right.Add(stuff[i]);
        }

        left = Sort(left);
        right = Sort(right);

        return Merge(left, right);
    }

    private List<T> Merge(List<T> left, List<T> right)
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

    internal class Program
    {
    public class DataFileLoader
    {
        public List<int> LoadIntTestData(string filePath)
        {
            List<int> intData = new List<int>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            intData.Add(number);
                        }
                        else
                        {
                            Console.WriteLine($"Ignoring non-integer data: {line}");
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found at path: {filePath}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while reading the file: {e.Message}");
            }

            return intData;
        }
    }
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

        private List<T> Merge(List<T> left, List<T> right)
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
    static void Main(string[] args)
        {
            /*string filePath = "RandomOrder_100000";
            ISort<int> mySort = new MergeSort<int>();
            List<int> data = LoadIntTestData(filePath);
            mySort.Sort(data);
            */

            DataFileLoader dataLoader = new DataFileLoader();
            string filePath = "RandomOrder_100000";
            List<int> testData = dataLoader.LoadIntTestData(filePath);

            foreach (int number in testData)
            {
                Console.WriteLine(number);
            }
        }
    }
