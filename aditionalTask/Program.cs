using System;
using System.IO;

namespace aditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var directory = new DirectoryInfo(@"C:\TESTDIR");
            directory.Create();
            if (directory.Exists)
            {
                for (int i = 0; i < 100; i++)
                    directory.CreateSubdirectory("Folder_" + i);
            }
            try
            {
                directory.Delete(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
