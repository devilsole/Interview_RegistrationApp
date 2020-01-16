
using Newtonsoft.Json;
using Registration.BAL;
using Registration.Interface;
using Registration.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        private IValidation Validation;

        public UnitTest1()
        {

            Validation = new DataValdation();

        }

        [Fact]
        public void ValidFName()
        {            
            Assert.True(Validation.IsValidName("abc"));
            Assert.True(Validation.IsValidName("ABC"));
            Assert.True(Validation.IsValidName("abcAB"));
            Assert.False(Validation.IsValidName("ab1"));
            Assert.False(Validation.IsValidName("1"));
            Assert.False(Validation.IsValidName("!@#"));
            Assert.False(Validation.IsValidName("__"));

        }

        [Fact]
        public void ValidSurName()
        {
            Assert.True(Validation.IsValidName("abc"));
            Assert.True(Validation.IsValidName("ABC"));
            Assert.True(Validation.IsValidName("abcAB"));
            Assert.False(Validation.IsValidName("ab1"));
            Assert.False(Validation.IsValidName("1"));
            Assert.False(Validation.IsValidName("!@#"));
            Assert.False(Validation.IsValidName("__"));

        }

        [Fact]
        public void ValidDateOFBirth()
        {
            Assert.False(Validation.IsValidDate("12"));
            Assert.False(Validation.IsValidDate("12-12"));
            Assert.False(Validation.IsValidDate("12-1"));
            Assert.False(Validation.IsValidDate("12-12-12"));
            Assert.False(Validation.IsValidDate("12-123-12"));
            Assert.False(Validation.IsValidDate("12-asd-12"));
            Assert.True(Validation.IsValidDate("12-12-1212"));

        }





    }





}
