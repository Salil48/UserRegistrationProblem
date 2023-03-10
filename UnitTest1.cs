using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            try
            {

                var actual = RegexSample.ValidatingFirstName(a);
                Assert.AreEqual(expected, actual);
            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.message);
            }
        }
        //Validating for Last Name
        [TestMethod]

        [DataRow("Aggarwal", "Aggarwal")]
        [DataRow("Ag", null)]
        [DataRow("Agg", "Agg")]
        [DataRow("Aggarwal05", null)]
        public void ValidateUserLastname(string a, string expected)
        {
            try
            {
                var actual = RegexSample.ValidatingLastName(a);
                Assert.AreEqual(expected, actual);
            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.message);
            }
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
            try
            {
                var actual = RegexSample.ValidatingEmailId(a);
                Assert.AreEqual(expected, actual);
            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.message);
            }
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
            try
            {
                var actual = RegexSample.ValidatingPhoneNum(a);
                Assert.AreEqual(expected, actual);
            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.message);
            }
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
            try
            {
                var actual = RegexSample.ValidatingPassWord(a);
                Assert.AreEqual(expected, actual);
            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.message);
            }
        }
        [TestMethod]
        public void Test_Method_Object_Creation_RegexSample()
        {
            object expected = new RegexSample();
            UserRegistrationFactory factory = new UserRegistrationFactory();
            object actual = factory.CreateObjectForRegexSample("UserRegistration.RegexSample", "RegexSample");
            expected.Equals(actual);

        }
        //Test for parameterconstructor invoked using object created
        [TestMethod]
        public void Test_Method_Parameteized_Constructor()
        {
            object expected = new RegexSample("RegularExpression");
            UserRegistrationFactory factory = new UserRegistrationFactory();
            object actual = factory.CreateParameterizedConstructor("UserRegistration.RegexSample", "RegexSample", "RegularExpression");
            actual.Equals(expected);
        }

        [TestMethod]
        public void Reflection_Return_Default_Constructor_No_Constructor_Found()
        {
            string expected = "No constructor found";
            object obj = null;
            try
            {
                UserRegistrationFactory factory = new UserRegistrationFactory();
                obj = factory.CreateObjectForRegexSample("UserRegistration.RegexSample", "RegexSam");

            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        [TestMethod]
        public void Reflection_Return_Default_Constructor_No_Class_Found()
        {
            string expected = "No class found";
            object obj = null;
            try
            {
                UserRegistrationFactory factory = new UserRegistrationFactory();
                obj = factory.CreateObjectForRegexSample("UserRegistration.RegexSae", "RegexSample");

            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        [TestMethod]
        public void Reflection_Return_Parameterized_Class_Invalid()
        {
            string message = "Regular Expression";
            string expected = "No class found";
            object actual = null;
            try
            {
                UserRegistrationFactory factory = new UserRegistrationFactory();
                actual = factory.CreateParameterizedConstructor("UserRegistration.RegexSae", "RegexSample", message);

            }
            catch (CustomException actual1)
            {
                Assert.AreEqual(expected, actual1.Message);
            }
        }
        [TestMethod]
        public void Reflection_Return_Parameterized_Constructor_Invalid()
        {
            string message = "Regular Expression";
            string expected = "No constructor found";
            object actual = null;
            try
            {
                UserRegistrationFactory factory = new UserRegistrationFactory();
                actual = factory.CreateParameterizedConstructor("UserRegistration.RegexSample", "RegexSam", message);

            }
            catch (CustomException actual1)
            {
                Assert.AreEqual(expected, actual1.Message);
            }
        }



    }
}