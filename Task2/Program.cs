using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new FileInfo(@"D:\test.txt");
            
            StreamWriter streamWriter = file.CreateText();
            streamWriter.Write("hello world!");
            streamWriter.Close();

            using (StreamReader streamReader = file.OpenText())
                Console.WriteLine(streamReader.ReadToEnd());
        }
    }
}
