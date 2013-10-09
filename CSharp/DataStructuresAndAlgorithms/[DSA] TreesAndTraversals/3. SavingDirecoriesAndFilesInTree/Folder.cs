namespace SavingDirecoriesAndFilesInTree
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;

    public class Folder
    {
        private BigInteger filesSize = 0;

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> ChildFolders { get; set; }

        public BigInteger GetFilesSize()
        {
            this.filesSize = this.GetSize(this);
            this.CalculateChildrenFilesSize(this);
            return this.filesSize;
        }

        private void CalculateChildrenFilesSize(Folder folder)
        {
            foreach (var childFolder in folder.ChildFolders)
            {
                filesSize += GetSize(childFolder);
                CalculateChildrenFilesSize(childFolder);
            }
        }

        private BigInteger GetSize(Folder folder)
        {
            BigInteger sum = 0;
            foreach (var file in folder.Files)
            {
                sum += file.Size;
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Name : " + this.Name + " ; ");

            if (this.Files.Count > 0)
            {
                result.Append("Files {");
                for (int i = 0; i < this.Files.Count; i++)
                {
                    if (i == this.Files.Count - 1)
                    {
                        result.Append(this.Files[i].ToString());
                    }
                    else
                    {
                        result.Append(this.Files[i].ToString() + "; ");
                    }
                }

                result.Append("} ; ");
            }

            if (this.ChildFolders.Count > 0)
            {
                result.Append(" Child Folders {");
                for (int i = 0; i < this.ChildFolders.Count; i++)
                {
                    if (i == this.ChildFolders.Count - 1)
                    {
                        result.Append(this.ChildFolders[i].Name);
                    }
                    else
                    {
                        result.Append(this.ChildFolders[i].Name + "; ");
                    }
                }
              
                result.Append("}");
            }

            return result.ToString();
        }
    }
}
