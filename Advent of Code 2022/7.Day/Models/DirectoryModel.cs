using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2022._7.Day.Objects
{
    public  record DirectoryModel
    {
        public string Name { get; }
        public DirectoryModel ParentDirectory { get; }


        private List<DirectoryModel> _childDirectories = new();
        private List<FileModel> _fileList = new();

        public void AddFileToList(FileModel file)
        {
            this._fileList.Add(file);
        }
        public DirectoryModel(string name, DirectoryModel parentDirectory)
        {
            this.Name = name;
            this.ParentDirectory = parentDirectory;
            if(parentDirectory != null)
            {
                ParentDirectory._childDirectories.Add(this);
            }
        }

        public DirectoryModel? FindChildModel(string name)
        {
            foreach(DirectoryModel child in this._childDirectories)
            {
                if(child.Name == name)
                {
                    return child;
                }
            }
            return null;
        }
        public long Size()
        {
            long size = 0;
            foreach (FileModel file in this._fileList)
            {
                size += file.Size;
            }

            foreach (DirectoryModel child in this._childDirectories)
            {
                size += child.Size();
            }

            return size;
        }

        public List<DirectoryModel> Children()
        {
            return this._childDirectories.ToList();
        }

        public List<FileModel> Files()
        {
            return this._fileList.ToList();
        }

    }
}
