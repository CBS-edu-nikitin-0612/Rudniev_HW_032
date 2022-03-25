using System;
using System.IO;
using System.Collections;

namespace Task3
{
    class FileSearcher
    {
        public static ArrayList GetFilesInfoOnDrive(DirectoryInfo dirInfo, string fileName)
        {
            FileInfo[] files = null;
            ArrayList filesList = new ArrayList();
            DirectoryInfo[] directories = null;
            try
            {
                files = dirInfo.GetFiles(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            if (files != null)
            {
                filesList = new ArrayList(files);
            }

            try
            {
                directories = dirInfo.GetDirectories();
            }
            catch
            {

            }
            if (directories != null)
            {
                if (directories.Length != 0)
                {
                    foreach (DirectoryInfo element in directories)
                    {
                        filesList.Add(GetFilesInfoOnDrive(element, fileName));
                    }
                }
            }
            return filesList;
        }
    }
}
