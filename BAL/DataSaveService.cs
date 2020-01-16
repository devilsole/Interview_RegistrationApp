using Registration.Interface;
using Registration.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.BAL
{
    public class DataSaveService: IDataSaveService
    {
        IFileGenerator _FileGenerator;

        public DataSaveService(IFileGenerator FileGenerator)
        {
            

            _FileGenerator = FileGenerator;

            _FileGenerator.CreateFolder();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Save(PersonalInfo data) =>_FileGenerator.SaveData(Parse(data));

        public void SpouceSaveData(PersonalInfo data, string path) => _FileGenerator.SpouceSaveData(Parse(data), path);

        public string FilePath(string name) => _FileGenerator.FilePath(name);

        public string FilePath() => _FileGenerator.FilePath();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string Parse(PersonalInfo data)
        {

            StringBuilder sb = new StringBuilder();

            sb.Append(data.FName).Append("|");
            sb.Append(data.SurName).Append("|");
            sb.Append(data.DOB).Append("|");
            sb.Append(data.Status).Append("|");
            sb.Append(data.Path);

            return sb.ToString();
        }
    }
}
