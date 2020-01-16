using System;
using Microsoft.Extensions.DependencyInjection;
using Registration.BAL;
using Registration.DAL;
using Registration.Interface;

namespace RegistrationApp
{
    class Program
    {
        static void Main(string[] args)
        {


            //setup our DI
            var services = new ServiceCollection();
            services.AddSingleton<IFileGenerator, FileGenerator>();
            services.AddSingleton<IDataSaveService, DataSaveService>();
            services.AddSingleton<IValidation, DataValdation>();
            services.AddSingleton<IUserInput, UserInput>();

            var provider = services.BuildServiceProvider();



            var bar = provider.GetService<IUserInput>();
            bar.RegisterUser();



          
           
        }
    }
}
