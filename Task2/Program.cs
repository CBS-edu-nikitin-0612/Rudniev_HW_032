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
            
            StreamReader streamReader = file.OpenText();
            Console.WriteLine(streamReader.ReadToEnd());
            streamReader.Close();
        }
    }
}
