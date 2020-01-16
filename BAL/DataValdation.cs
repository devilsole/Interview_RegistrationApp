using System;
using System.Text.RegularExpressions;
using Registration.DAL;
using Registration.Interface;

namespace Registration.BAL
{
    public class DataValdation : IValidation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public int GetAge(string datetime)
        {
            var dateOfBirth = Convert.ToDateTime(datetime);
            var age = DateTime.Now.Year - dateOfBirth.Year;
            return (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                ? age - 1
                : age;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public bool IsValidDate(string datetime) => Regex.IsMatch(datetime , @"[0-9]{2}-[0-9]{2}-[0-9]{4}");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsValidName(string name) => Regex.IsMatch(name, @"^[a-zA-Z]+$");
    }
}
