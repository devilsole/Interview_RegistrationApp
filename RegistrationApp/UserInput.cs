using System;
using System.Collections.Generic;
using System.Text;
using Registration.POCO;
using Registration.BAL;
using Registration.Interface;

namespace RegistrationApp
{
    public  class UserInput :IUserInput
    {
        IDataSaveService DataSave;

       
        public UserInput(IDataSaveService  dataSave)
        {
            this.DataSave = dataSave;
        }


        public void RegisterUser()
        {


            Console.WriteLine("------------------------\n");

            // Ask the user to choose an option.
            Console.WriteLine("Choose an option from the following list Marrige Status:");
            Console.WriteLine("\t1 - Single");
            Console.WriteLine("\t2 - Married");
            Console.Write("Your option? ");
            var Status = Convert.ToInt32(Console.ReadLine());

            // Making Sure user input only the option required
            while ((Status == 1 || Status == 2) != true)
            {
                Console.WriteLine("Choose an option from the following list Marrige Status and then press Enter");
                Status = Convert.ToInt32(Console.ReadLine());
            }
            try
            {
                if (Status == 1)
                {
                    //Save Data
                    DataSave.Save(UserData(Status));
                    Console.WriteLine("Data Saving Completed");

                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter Husband Information");

                    var Husband = UserData(Status);

                    Console.WriteLine();
                    Console.WriteLine("Enter Wife Information");

                    var Wife = UserData(Status);

                    Husband.Path = DataSave.FilePath(Wife.FName);
                    Wife.Path = DataSave.FilePath();




                    //Saving Data
                    DataSave.Save(Husband);
                    DataSave.SpouceSaveData(Wife, Husband.Path);

                    Console.WriteLine();
                    Console.WriteLine("Data Saving Completed");

                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("******* ExCeption *******");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Kindly Input Correct Information ");

                Console.WriteLine("******* ExCeption *******");

            }
        }

         

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public PersonalInfo UserData(int status)
        {
            var Data = new PersonalInfo();

            var DataValidation = new DataValdation();

            bool Authorize = false;

            
                // Ask the user to type the first number.
                Console.WriteLine("Type First Name and then press Enter");
                Data.FName = Console.ReadLine();

                if (!DataValidation.IsValidName(Data.FName))
                    throw new Exception("First Name is not Alphabet");

            // Ask the user to type the second number.
                Console.WriteLine("Type SurName, and then press Enter");
                Data.SurName = Console.ReadLine();

            if (!DataValidation.IsValidName(Data.SurName))
                throw new Exception("SurName  is not Alphabet");



            // Ask the user to type Date of Birth.
                Console.WriteLine("Type Date of Birth in following format days-Months-year ( 13-01-1888), and then press Enter");
                var DOB = Console.ReadLine();


                if (DataValidation.IsValidDate(DOB) != true)
                    throw new Exception("Date of Birth is in wrong Format");

                var age = DataValidation.GetAge(DOB);

                if (age < 18 && age > 16)
                {
                    Console.WriteLine("The age is between 16- 18 years kindly Authorize and Type yes to allow Registration Else Type NO and then press Enter");

                    Authorize = (Console.ReadLine().ToLower() == "yes");
                }
                else if (age < 16)
                    Authorize = false;
                else
                    Authorize = true;



                if (!Authorize)
                    throw new Exception("Un Authorize to Register");


                // Add Value to DateTime
                Data.DOB = DOB;
                Data.Status = MarrigeStatus(status);
                Data.Path = "null";



            return Data;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public PersonalInfo UserDataSpouse(int status)
        {
            var Data = new PersonalInfo();

            var DataValidation = new DataValdation();

            bool Authorize = false;


            // Ask the user to type the first number.
            Console.WriteLine("Type First Name and then press Enter");
            Data.FName = Console.ReadLine();

            if (!DataValidation.IsValidName(Data.FName))
                throw new Exception("First Name is not Alphabet");

            // Ask the user to type the second number.
            Console.WriteLine("Type SurName, and then press Enter");
            Data.SurName = Console.ReadLine();

            if (!DataValidation.IsValidName(Data.SurName))
                throw new Exception("SurName  is not Alphabet");



            // Ask the user to type Date of Birth.
            Console.WriteLine("Type Date of Birth in following format days-Months-year ( 13-01-1888), and then press Enter");
            var DOB = Console.ReadLine();


            if (DataValidation.IsValidDate(DOB) != true)
                throw new Exception("Date of Birth is in wrong Format");

            var age = DataValidation.GetAge(DOB);

            if (age < 18 && age > 16)
            {
                Console.WriteLine("The age is between 16- 18 years kindly Authorize and Type yes to allow Registration Else Type NO and then press Enter");

                Authorize = (Console.ReadLine().ToLower() == "yes");
            }
            else if (age < 16)
                Authorize = false;
            else
                Authorize = true;



            if (!Authorize)
                throw new Exception("Un Authorize to Register");


            // Add Value to DateTime
            Data.DOB = DOB;
            Data.Status = MarrigeStatus(status);

           



            return Data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string MarrigeStatus(int value) => value == 2 ? "Married" : "Single";
   
    }
}
