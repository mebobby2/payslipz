  using System;

  namespace payslipz.core
  {
      class Admin : Staff
      {
          private const float overtimeRate = 15.5f;
          private const float adminHourlyRate = 30f;

          public float Overtime { get; private set; }

          public Admin(string name) : base(name, adminHourlyRate) { }

          public override void CalculatePay()
          {
              base.CalculatePay();
              if (HoursWorked > 160)
              {
                  Overtime = overtimeRate * (HoursWorked - 160);
                  TotalPay += Overtime;
              }
          }

          public override string ToString()
          {
              return $"Name = {NameOfStaff}, Hourly Rate = {adminHourlyRate:C}, Basic Pay = {BasicPay:C}, Total Pay = {TotalPay:C}, Overtime = {Overtime}";
          }

      }
  }
