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
using System.Diagnostics;

namespace CSCI_2210___Project_2
{

    public interface ISort<T> where T : IComparable<T>
    {
        public void Sort(List<T> stuff);
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> testFiles = new List<string>
        {
            "./Test Data/RandomOrder_10.txt",
            "./Test Data/RandomOrder_100.txt",
            "./Test Data/RandomOrder_1000.txt",
            "./Test Data/RandomOrder_10000.txt",
            "./Test Data/RandomOrder_100000.txt",
            "./Test Data/ReverseOrder_10.txt",
            "./Test Data/ReverseOrder_100.txt",
            "./Test Data/ReverseOrder_1000.txt",
            "./Test Data/ReverseOrder_10000.txt",
            "./Test Data/ReverseOrder_100000.txt",
            "./Test Data/InOrder_10.txt",
            "./Test Data/InOrder_100.txt",
            "./Test Data/InOrder_1000.txt",
            "./Test Data/InOrder_10000.txt",
            "./Test Data/InOrder_100000.txt",
            "./Test Data/AlmostInOrder_10.txt",
            "./Test Data/AlmostInOrder_100.txt",
            "./Test Data/AlmostInOrder_1000.txt",
            "./Test Data/AlmostInOrder_10000.txt",
            "./Test Data/AlmostInOrder_100000.txt"
        };

            DataFileLoader fileLoader = new DataFileLoader();

            foreach (string fileName in testFiles)
            {
                Console.WriteLine($"File Name: {fileName}");
                List<int> loadedData = fileLoader.LoadIntTestData(fileName);

                Console.WriteLine($"Loaded {loadedData.Count} integers from the file.");
                Console.WriteLine();
            }

            List<int> intdata = new List<int>();

            // switch
            Console.WriteLine("Which sorting method would you like to see? (INSERTION or MERGE or BOOK)");
            string answer = Console.ReadLine().ToUpper();
            switch (answer)
            {
                case "INSERTION":
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    InsertionSort<int> insertionSort = new InsertionSort<int>();
                    
                    List<int> sortedStuffIns = insertionSort.Sort(intdata);

                    Console.WriteLine("Sorted Stuff:");
                    foreach (int item in sortedStuffIns)
                    {
                        Console.WriteLine(item);
                    }

                    stopwatch.Stop();
                    long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
                    long accumulator = 0;
                    accumulator += elapsedMilliseconds;

                    Console.WriteLine($"Elapsed Time: {elapsedMilliseconds} milliseconds");
                    Console.WriteLine($"Accumulator Value: {accumulator}");
                    break;
                case "MERGE":

                    Stopwatch stopwatch1 = new Stopwatch();
                    stopwatch1.Start();
                    MergeSort<int> mergeSort = new MergeSort<int>();
                    
                    mergeSort.Sort(intdata);

                    Console.WriteLine("Sorted Stuff:");
                    foreach (int item in intdata)
                    {
                        Console.WriteLine(item);
                    }
                    stopwatch1.Stop();
                    long elapsedMilliseconds1 = stopwatch1.ElapsedMilliseconds;
                    long accumulator1 = 0;
                    accumulator1 += elapsedMilliseconds1;
                    Console.WriteLine($"Elapsed Time: {elapsedMilliseconds1} milliseconds");
                    Console.WriteLine($"Accumulator Value: {accumulator1}");
                    break;
                case "BOOK":
                    Console.WriteLine("Enter book data here.");
                    break;
                default:
                    Console.WriteLine("Incorrect input.");
                    break;
            }
        }
    }
}