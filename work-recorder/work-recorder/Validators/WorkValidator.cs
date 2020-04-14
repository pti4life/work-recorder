using System;
using System.Collections.Generic;
using System.Text;
using work_recorder.Modells;

namespace work_recorder.Validators
{
    public static class WorkValidator
    {


        public static string ValidateWork(string NameOfCustomer, string CarLicensePlate, string TypeOfCar, string DetailOfIssues) {

            if (string.IsNullOrEmpty(NameOfCustomer))
            {
                return "EMPTY_NAMEOFCUSTOMER";
            }

            if (string.IsNullOrEmpty(CarLicensePlate))
            {
                return "EMPTY_CARLICENSEPLATE";
            }

            if (string.IsNullOrEmpty(TypeOfCar))
            {
                return "EMPTY_TYPEOFCAR";
            }

            if (string.IsNullOrEmpty(DetailOfIssues) || DetailOfIssues.Length <= 3)
            {
                return "TOO_SHORT_DETAILOFISSUES";
            }

            return "";
        }
    }
}
