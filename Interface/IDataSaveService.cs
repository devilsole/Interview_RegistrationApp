using Registration.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Interface
{
    public interface IDataSaveService
    {


        void Save(PersonalInfo data);

        string FilePath(string name);

        string FilePath();

        void SpouceSaveData(PersonalInfo data, string path);


    }
}
