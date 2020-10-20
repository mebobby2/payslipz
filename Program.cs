using System;
using System.IO;
using System.Collections.Generic;
using payslipz.core;

namespace payslipz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating payslips...");
            List<Staff> staffs;
            int month = 0;
            int year = 0;

            while (year == 0)
            {
                Console.Write("\nPlease enter the year; ");
                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.Write("\nPlease enter a valid year; ");
                }
            }

            while (month == 0)
            {
                Console.Write("\nPlease enter the month; ");
                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if (month < 1 || month > 12) {
                        Console.Write("\nPlease enter a month between 1 & 12; ");
                        month = 0;
                    }
                }
                catch (FormatException)
                {
                    Console.Write("\nPlease enter a valid month; ");
                }
            }

            staffs = FileReader.ReadFile();
            for (int i = 0; i < staffs.Count; i++)
            {
                var staff = staffs[i];
                try
                {
                    Console.Write($"Enter hours worked for {staff.NameOfStaff}; ");
                    int hoursWorked = Convert.ToInt32(Console.ReadLine());
                    staff.HoursWorked = hoursWorked;
                    staff.CalculatePay();
                    Console.WriteLine(staff);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error occurred");
                    Console.WriteLine(e);
                    i--;
                }
            }
            Payslip ps = new Payslip(month, year);
            ps.GeneratePaySlip(staffs);
            ps.GenerateSummary(staffs);
            Console.WriteLine("DONE!");
        }
    }
}
