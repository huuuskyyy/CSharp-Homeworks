using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_And_Folders
{
    class Program
    {
        static void Main(string[] args)
        {
            string startDirectory = "C:\\Users\\Angel\\Downloads";
            List<Folder> folders = new List<Folder>();

            TraverseDirectories(startDirectory, null, ref folders);

            foreach (var folder in folders)
            {
                Console.WriteLine(folder.Name + " Files size " + folder.CalculateFilesSizeSum()); 
            }

        }

        public static void TraverseDirectories(string startDirectory, Folder parent, ref List<Folder> folders)
        {
            try
            {
                Folder folder = new Folder(startDirectory);
                
                string[] directories = Directory.GetDirectories(startDirectory);
                
                folder.Files = GetFilesInDirectory(startDirectory);
                

                foreach (var directory in directories)
                {
                    TraverseDirectories(directory, folder, ref folders);
                }
                
                if (parent != null)
                {
                    parent.AddFolder(folder);
                }
                
                folders.Add(folder);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static File[] GetFilesInDirectory(string startDirectory)
        {
            
            DirectoryInfo currentDirectory = new DirectoryInfo(startDirectory);
            FileInfo[] filesInDirectory = currentDirectory.GetFiles();

            File[] files = new File[filesInDirectory.Length];

            for (int i = 0; i < filesInDirectory.Length; i++)
            {
                files[i] = new File(filesInDirectory[i].Name, filesInDirectory[i].Length);
            }

            return files;
        }

    }
}
