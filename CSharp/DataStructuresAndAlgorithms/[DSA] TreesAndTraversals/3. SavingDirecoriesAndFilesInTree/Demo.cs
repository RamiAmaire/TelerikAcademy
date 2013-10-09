namespace SavingDirecoriesAndFilesInTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Demo
    {
        public static void SaveData(DirectoryInfo directory, Folder folder)
        {
            try
            {
                FileInfo[] files = directory.GetFiles();
                SaveFiles(files, folder.Files);
                DirectoryInfo[] directories = directory.GetDirectories();
                SaveFolders(directories, folder.ChildFolders);

                foreach (var dir in directory.GetDirectories())
                {
                    foreach (var childFolder in folder.ChildFolders)
                    {
                        if (dir.Name == childFolder.Name)
                        {
                            SaveData(dir, childFolder);
                        } 
                    }
                }
            }

            catch (UnauthorizedAccessException)
            {
            }
        }

        private static void SaveFiles(FileInfo[] files, List<File> folderFiles)
        {
            foreach (var file in files)
            {
                File currentFile = new File(file.Name, file.Length);
                folderFiles.Add(currentFile);
            }
        }

        private static void SaveFolders(DirectoryInfo[] directories, List<Folder> subFolders)
        {
            foreach (var directory in directories)
            {
                Folder currentFolder = new Folder(directory.Name);
                subFolders.Add(currentFolder);
            }
        }

        public static void Main()
        {
            string path = @"E:\Pictures";
            DirectoryInfo directory = new DirectoryInfo(path);
            Folder folder = new Folder(directory.Name);
            SaveData(directory, folder);
            Console.WriteLine(folder.GetFilesSize());
        }
    }
}
