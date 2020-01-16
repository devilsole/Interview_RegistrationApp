using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Interface
{
    public interface IFileGenerator
    {

        void CreateFolder();

        void SaveData(string data);

        void SpouceSaveData(string data, string _path);
        string FilePath(string name);

        string FilePath();

    }
}
