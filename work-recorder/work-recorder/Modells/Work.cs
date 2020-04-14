using System;
using System.Collections.Generic;
using System.Text;

namespace work_recorder.Modells
{
    public class Work
    {
        public long Id { get; set; }

        public string NameOfCustomer { get; set; }

        public string CarLicensePlate { get; set; }

        public string TypeOfCar { get; set; }

        public string DetailOfIssues { get; set; }

        public DateTime RecordingDate { get; set; }

        public string StateOfWork { get; set; }

        public override string ToString()
        {
            return "Work: " + Id;
        }
    }
}
