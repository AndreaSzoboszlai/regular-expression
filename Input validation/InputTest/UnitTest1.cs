using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Input_validation;
using System.Windows.Forms;

namespace InputTest
{
    [TestClass]
    public class UnitTest1
    {
        private inputValidator newForm;

        [TestInitialize]
        public void SetUp()
        {
            newForm = new inputValidator();
        }

        [TestMethod]
        public void TestNameInput()
        {
            string name1 = "Jane Doe";
            string name2 = "jane";
            string name3 = "jane5";

            Assert.AreEqual(true, newForm.ValidName(name1));
            Assert.AreEqual(true, newForm.ValidName(name2));
            Assert.AreEqual(false, newForm.ValidName(name3));
        }

        [TestMethod]
        public void TestPhoneInput()
        {
            string phone1 = "001-121-5252";
            string phone2 = "121-5252";
            string phone3 = "1-121-5252";

            Assert.AreEqual(true, newForm.ValidPhone(phone1));
            Assert.AreEqual(false, newForm.ValidPhone(phone2));
            Assert.AreEqual(false, newForm.ValidPhone(phone3));
        }

        [TestMethod]
        public void TestEmailInput()
        {
            string email1 = "jane@gmail.com";
            string email2 = "janegmail.com";
            string email3 = "jane@gmailcom";

            Assert.AreEqual(true, newForm.ValidEmail(email1));
            Assert.AreEqual(false, newForm.ValidEmail(email2));
            Assert.AreEqual(false, newForm.ValidEmail(email3));
        }
    }
}
