using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using work_recorder.Validators;

namespace work_recorder_test
{
    [TestClass]
    public class WorkValidatorTest
    {
        [TestMethod]
        public void ValidateWork_WithInvalidNameOfCustomer()
        {

            string result = WorkValidator.ValidateWork("", "", "", "");
            Assert.AreEqual("EMPTY_NAMEOFCUSTOMER", result, "Customer name validation not works correctly.");
        }

        [TestMethod]
        public void ValidateWork_WithInvalidCarLicensePlate()
        {

            string result = WorkValidator.ValidateWork("Béla", "", "", "");
            Assert.AreEqual("EMPTY_CARLICENSEPLATE", result, "Car license plate validation not works correctly.");
        }

        [TestMethod]
        public void ValidateWork_WithInvalidTypeOfCar()
        {

            string result = WorkValidator.ValidateWork("Béla", "ABC-1232", "", "");
            Assert.AreEqual("EMPTY_TYPEOFCAR", result, "Car type validation not works correctly.");
        }

        [TestMethod]
        public void ValidateWork_WithInvalidDetailOfIssues()
        {

            string result = WorkValidator.ValidateWork("Béla", "ABC-1232", "Fiat", "ab");
            Assert.AreEqual("TOO_SHORT_DETAILOFISSUES", result, "Detail of issues validation not works correctly.");
        }

        [TestMethod]
        public void ValidateWork_WithValidData()
        {

            string result = WorkValidator.ValidateWork("Béla", "ABC-1232", "Fiat", "brake problems");
            Assert.AreEqual("", result, "Detail of issues validation not works correctly.");
        }

    }
}
