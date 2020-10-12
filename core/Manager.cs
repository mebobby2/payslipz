using System;

namespace payslipz.core
{
    class Manager : Staff
    {
        private const float managerHourlyRate = 50f;
        private const int AllowanceBonusHours = 160;
        public int Allowance { get; private set; }

        public Manager(string name) : base(name, managerHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > AllowanceBonusHours)
            {
                TotalPay += Allowance;
            }
        }

        public override string ToString()
        {
            return $"Name = {NameOfStaff}, Hourly Rate = {managerHourlyRate:C}, Basic Pay = {BasicPay:C}, Total Pay = {TotalPay:C}, Allowance = {Allowance}";
        }

    }
}
