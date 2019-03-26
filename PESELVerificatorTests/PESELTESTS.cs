using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PESELVeryficator;

namespace PESELVerificatorTests
{
    [TestClass]
    public class PESELTests
    {
        [TestMethod]
        public void GetBirthDate_ValidDate()
        {
            string peselValue = "95060612122";
            string expected = "06-06-95";

            PESEL p = new PESEL(peselValue);
            string actual = p.GetBirthDate();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void GetBirthDate_InvalidDateFormat()
        {
            string peselValue = "k060612122";

            PESEL p = new PESEL(peselValue);
            p.GetBirthDate();

        }

        [TestMethod]
        public void GetGender_ReturnWoman()
        {
            string peselValue = "95060612122";
            string expected = "K";

            PESEL p = new PESEL(peselValue);
            string actual = p.GetGender();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetGender_ReturnMan()
        {
            string peselValue = "95060612112";
            string expected = "M";

            PESEL p = new PESEL(peselValue);
            string actual = p.GetGender();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void GetGender_InvalidFormat()
        {
            string peselValue = "950606121m2";

            PESEL p = new PESEL(peselValue);
            p.GetGender();

        }

        [TestMethod]
        public void GetPESELLength_Valid11Length()
        {
            string peselValue = "95060612122";
            int expected = 11;

            PESEL p = new PESEL(peselValue);
            int actual = p.GetPESELLength();

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetPESELLength_InvalidLength()
        {
            string peselValue = "9506061212";

            PESEL p = new PESEL(peselValue);
            p.GetPESELLength();

        }

        [TestMethod]
        public void IsOnlyNumeric_ValidNumericValues()
        {
            string peselValue = "95060612122";
            bool expected = true;

            PESEL p = new PESEL(peselValue);
            bool actual = p.IsOnlyNumeric();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void IsOnlyNumeric_NotOnlyNumeric()
        {
            string peselValue = "950;061212;";

            PESEL p = new PESEL(peselValue);
            p.IsOnlyNumeric();

        }

        [TestMethod]
        public void CheckControlNumber_ValidControlNumber()
        {
            string peselValue = "95060612122";
            bool expected = true;

            PESEL p = new PESEL(peselValue);
            bool actual = p.CheckControlNumber();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckControlNumber_InvalidControlNumber()
        {
            string peselValue = "9507061212789";

            PESEL p = new PESEL(peselValue);
            p.CheckControlNumber();

        }
    }
}
