using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSCI_2210___Project_2
{
    public class DataFileLoader
    {
        public List<int> LoadIntTestData(string fileName)
        {
            List<int> intData = new List<int>();

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
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
                Console.WriteLine($"File not found at path: {fileName}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An error occurred while reading the file: {e.Message}");
            }

            return intData;
        }
    }
}
