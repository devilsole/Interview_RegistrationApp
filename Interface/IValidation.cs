using System;

namespace Registration.Interface
{
    public interface IValidation
    {

        bool IsValidDate(string value );

        int GetAge(string datetime);

        bool IsValidName(string name);



    }
}