using System;
using System.IO;
using Registration.Interface;


namespace Registration.DAL
{
    public class FileGenerator : IFileGenerator
    {
        const string cFolderPath = "c:/main/";

        const string cFolderPath1 = "c:/people/spouses/";

        public void CreateFolder() => Directory.CreateDirectory(cFolderPath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void SaveData(string data)
        {

            using (StreamWriter writer = new StreamWriter(Path(cFolderPath, "People"), true))
            {
                writer.WriteLine(data);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="name"></param>
        public void SpouceSaveData(string data, string _path)
        {
            Directory.CreateDirectory(cFolderPath1);

            using (StreamWriter writer = new StreamWriter(_path, true))
            {
                writer.WriteLine(data);
            }
        }

        string Path(string Folder, string Name) => $"{Folder}{Name}.txt";


        public string FilePath() => Path(cFolderPath, "People");
        public string FilePath(string name) => Path(cFolderPath1, name);
    }
}
