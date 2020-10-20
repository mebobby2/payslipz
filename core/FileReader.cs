using System;
using System.IO;
using System.Collections.Generic;

namespace payslipz.core
{
    static class FileReader
    {
        public static List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "/Users/developer/Documents/learn/payslipz/staff.txt";
            string[] separator = {", "};

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] staffInfo = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if (staffInfo[1] == "Manager")
                        {
                            myStaff.Add(new Manager(staffInfo[0]));
                        } else if (staffInfo[1] == "Admin"){
                            myStaff.Add(new Admin(staffInfo[0]));
                        }
                    }
                }
            } else {
                Console.WriteLine("The file does not exist!");
            }
            return myStaff;
        }
    }
}
