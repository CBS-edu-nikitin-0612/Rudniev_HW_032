using System;
using System.IO;
using System.IO.Compression;
using System.Collections;

namespace Task3
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write file name for sirch: ");
            string fileName = Console.ReadLine();

            ArrayList files;
            SearchUserFiles(fileName, out files);

            Console.Write("\nSelect the required file from the list and enter its number in the list: ");
            int indexFile = Convert.ToInt32(Console.ReadLine());
            FileInfo fileInfo = files[--indexFile] as FileInfo;

            if (indexFile > 0 && indexFile <= files.Count)
            {
                Console.WriteLine("File contents: ");
                if (fileInfo != null)
                {
                    ReadFile(fileInfo);
                }
                else
                {
                    Console.WriteLine("File could not be read!");
                }
            }
            else
            {
                Console.WriteLine("Wrong files index! ");
            }

            Console.WriteLine("Starting file compression...");

            FileStream fileStream;
            FileStream destination;
            GZipStream compressor = null;

            try
            {
                fileStream = File.OpenRead(fileInfo.FullName);
                destination = File.Create(fileInfo.DirectoryName + @"\test.zip");
                compressor = new GZipStream(destination, CompressionMode.Compress);

                int theByte = fileStream.ReadByte();
                while (theByte != -1)
                {
                    compressor.WriteByte((byte)theByte);
                    theByte = fileStream.ReadByte();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                compressor?.Close();
            }
        }

        static void ReadFile(FileInfo fileInfo)
        {
            FileStream fileStream;
            StreamReader reader = null;
            try
            {
                fileStream = File.OpenRead(fileInfo.FullName);
                reader = new StreamReader(fileStream);
                if (reader != null)
                    Console.WriteLine(reader.ReadToEnd());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        static void SearchUserFiles(string fileName, out ArrayList files)
        {
            files = new ArrayList();
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"\nSearching on drive {drive.Name}: ");
                DirectoryInfo dirInfo = new DirectoryInfo(drive.Name);

                files = FileSearcher.GetFilesInfoOnDrive(dirInfo, fileName);
            }

            if (files.Count > 0)
            {
                Console.WriteLine($"\nFiles searched on drives: ");
                foreach (FileInfo file in files)
                    Console.WriteLine(file.FullName);
            }
            else
            {
                Console.WriteLine("\nFiles not found.");
            }
        }
    }
}
