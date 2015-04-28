using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Files_And_Folders
{
    class Folder
    {
        private string name;
        private File[] files;
        private List<Folder> folders;

        public Folder(string name)
        {
            this.name = name;
            this.folders = new List<Folder>();
        }
        public List<Folder> Folders
        {
            get
            {
                return this.folders;
            }
            set
            {
                this.folders = value;
            }
        }
        public File[] Files
        {
            get
            {
                return this.files;
            }
            set
            {
                this.files = value;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public void AddFolder(Folder folder)
        {
            this.folders.Add(folder);
        }

        public BigInteger CalculateFilesSizeSum()
        {
            BigInteger sum = 0;

            DirectoryInfo currentDirectory = new DirectoryInfo(this.Name);
            FileInfo[] filesInDirectory = currentDirectory.GetFiles();

            foreach (var file in filesInDirectory)
            {
                sum += file.Length;
            }

            foreach (var folder in folders)
            {
                sum += folder.CalculateFilesSizeSum();
            }

            return sum;
        }
    }
}
