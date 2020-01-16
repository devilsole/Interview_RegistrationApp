using Registration.BAL;
using Registration.DAL;
using Registration.Interface;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        private IValidation Validation;
        private IFileGenerator FileGenerator;
        private IDataSaveService DataSaveService;

        public UnitTest1()
        {

            Validation = new DataValdation();
            FileGenerator = new FileGenerator();
            DataSaveService = new DataSaveService(FileGenerator);


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

        [Fact]
        public void ValidationFileName()
        {

            Assert.Equal(DataSaveService.FilePath("abc"), "c:/people/spouses/abc.txt");

            Assert.Equal(DataSaveService.FilePath(), "c:/main/People.txt");

        }






    }





}
