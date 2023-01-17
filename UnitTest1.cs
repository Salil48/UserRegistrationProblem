using UserRegistration;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //validation for first Name
        [TestMethod]
        [DataRow("Salil", "Salil")]
        [DataRow("s", null)]
        [DataRow("Salil05", null)]

        public void ValidateFirstname(string a, string expected)
        {

            var actual = RegexSample.ValidatingFirstName(a);
            Assert.AreEqual(expected, actual);
        }
        //Validating for Last Name
        [TestMethod]
        [DataRow("Aggarwal", "Aggarwal")]
        [DataRow("Ag", null)]
        [DataRow("Agg", "Agg")]
        [DataRow("Aggarwal05", null)]
        public void ValidateUserLastname(string a, string expected)
        {
            var actual = RegexSample.ValidatingLastName(a);
            Assert.AreEqual(expected, actual);
        }
        //Validation for Email
        [TestMethod]
        [DataRow("abc@gmail.com", "abc@gmail.com")]
        [DataRow("abc-100@yahoo.com", "abc-100@yahoo.com")]
        [DataRow("abc.100@yahoo.com", "abc.100@yahoo.com")]
        [DataRow("abc111@yahoo.com", "abc111@yahoo.com")]
        [DataRow("abc111@abc.com", "abc111@abc.com")]
        [DataRow("abc-100@abc.net", "abc-100@abc.net")]
        [DataRow("abc.100@abc.com.au", "abc.100@abc.com.au")]
        [DataRow("abc@1.com", "abc@1.com")]
        [DataRow("abc@gmail.com.com", "abc@gmail.com.com")]
        [DataRow("abc+100@gmail.com", "abc+100@gmail.com")]
        [DataRow("abc", null)]
        [DataRow("abc@.com.my", null)]
        [DataRow("abc123@.com", null)]
        [DataRow("abc123@.com.com", null)]
        [DataRow("abc()*@gmail.com", null)]
        [DataRow(".abc@abc.com", null)]
        [DataRow("abc@%*.com", null)]
        [DataRow("abc..2002@gmail.com", null)]
        [DataRow("abc.@gmail.com", null)]
        [DataRow("abc@abc@gmail.com", null)]
        [DataRow("abc@gmail.com.1a", null)]
        [DataRow("abc@gmail.com.aa.au", null)]

        public void ValidateUserEmail(string a, string expected)
        {
            var actual = RegexSample.ValidatingEmailId(a);
            Assert.AreEqual(expected, actual);
        }

        //Validation for Phone Number
        [TestMethod]
        [DataRow("1 1000987267", "1 1000987267")]
        [DataRow("91 9842905050", "91 9842905050")]
        [DataRow("100 9842905050", "100 9842905050")]
        [DataRow("919842905050", null)]
        [DataRow("919842905", null)]
        [DataRow("91 984290", null)]
        [DataRow("91 984290505000000", null)]
        public void ValidateUserPhoneNumber(string a, string expected)
        {
            var actual = RegexSample.ValidatingPhoneNum(a);
            Assert.AreEqual(expected, actual);
        }

        ////Validation for Password
        [TestMethod]
        [DataRow("Salil@123", "Salil@123")]
        [DataRow("Salil#123", "Salil#123")]
        [DataRow("Salil123*", "Salil123*")]
        [DataRow("@Salil129", "@Salil129")]
        [DataRow("Sa-lil123", "Sa-lil123")]
        [DataRow("salil123)@1234", null)]
        [DataRow("Sha@", null)]
        [DataRow("sha123", null)]
        [DataRow("sha@123", null)]
        [DataRow("@sha#12sha", null)]
        [DataRow(")shal12", null)]
        [DataRow(")sal12", null)]
        [DataRow("sa-l@12S", null)]
        [DataRow("saL@s", null)]

        public void ValidateUserPassword(string a, string expected)
        {
            var actual = RegexSample.ValidatingPassWord(a);
            Assert.AreEqual(expected, actual);
        }



    }
}