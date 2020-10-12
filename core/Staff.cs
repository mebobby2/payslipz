using System;

namespace payslipz.core
{
    class Staff
    {
        private float hourlyRate;
        private int hWorked;

        public Staff(string name, float rate)
        {
            hourlyRate = rate;
            NameOfStaff = name;
        }

        public string NameOfStaff { get; private set; }
        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }

        public int HoursWorked
        {
            get { return hWorked; }
            set {
                hWorked = value > 0 ? value : 0;
            }
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return $"Name = {NameOfStaff}, Hourly Rate = {hourlyRate:C}, Basic Pay = {BasicPay:C}, Total Pay = {TotalPay:C}";
        }
    }
}
