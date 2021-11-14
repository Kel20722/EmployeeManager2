using System;
using System.Collections;

namespace EmployeeManager1
{
    class Program
    {
        static string GetName()
        {
            bool condition = true;
            string employeeName = "";
            while (condition == true)
            {
                Console.WriteLine("Employee Name: ");
                employeeName = Console.ReadLine();
                condition = Employee.IsValidName(employeeName);
                if (condition == false)
                {
                    condition = true;
                    Console.WriteLine("Name Should between 1 and 50 characters long");
                }
                else
                {
                    condition = false;
                }
            }
            return employeeName;
        }




        static int GetWage()
        {
            int numberOfHours = 0;
            bool condition = true;
            while (condition == true)
            {
                Console.WriteLine("Hours Worked: ");
                numberOfHours = Convert.ToInt32(Console.ReadLine());
                condition = Employee.IsValidWage(numberOfHours);
                if (condition == false)
                {
                    Console.WriteLine("Enter wage between 1 and 100");
                    condition = true;
                }
                else
                {
                    condition = false;
                }
            }
            return numberOfHours;

        }



        static string GetId()
        {
            string employeeId = "";
            bool condition = true;
            while (condition == true)
            {
                Console.WriteLine("Employee Id: ");
                employeeId = Console.ReadLine();
                condition = Employee.IsValidId(employeeId);
                if (condition == false)
                {
                    Console.WriteLine("Employee Id: must start with a letter and be followed by two digits");
                    condition = true;
                }
                else
                {
                    condition = false;
                }
            }
            return employeeId;

        }

        class Employee
        {
            string EmployeeName;
            string EmployeeId;
            double HoursWorked;
            double HourlyRate;

            public Employee(string EmployeeName, string EmployeeId, double HoursWorked)
            {
                this.EmployeeName = EmployeeName;
                this.EmployeeId = EmployeeId;
                this.HoursWorked = HoursWorked;
                this.HourlyRate = 9.5;
            }

            public string GetEmployeData()
            {
                string Data = this.EmployeeName.ToString() + " (" + this.EmployeeId.ToString() + " )";
                return Data;
            }

            public double CalcWage()
            {
                double wage = 0;
                if (this.HoursWorked > 40)
                {
                    double overtime = this.HoursWorked - 40;
                    wage = 40 * 9.50 + overtime * 14.25;
                }
                else
                {
                    wage = 9.50 * this.HoursWorked;
                }
                return wage;
            }

            public static bool IsValidWage(int wage)
            {
                if (wage >= 1 && wage <= 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static bool IsValidId(string id)
            {

                if (id.Length == 3)
                {
                    bool number1 = Char.IsDigit(id[1]);
                    bool number2 = Char.IsDigit(id[2]);
                    if ((Char.IsUpper(id[0]) || Char.IsLower(id[0])) && number1 == true && number2 == true)
                    {

                        return true;
                    }
                }

                return false;

            }

            public static bool IsValidName(string name)
            {
                if (name.Length >= 1 && name.Length <= 50)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }


        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("\n1.	Add Employee");
            Console.WriteLine("2.	List Employees (with the positon number in the list)");
            Console.WriteLine("3.	Remove Employee (based on a positon number provided by the user)");
            Console.WriteLine("4.	Quit");
            Console.WriteLine("Enter Option No =");
        }


        static void Main(string[] args)
        {

            var EmployeeList = new ArrayList();

            bool condition = true;

            while (condition == true)
            {
                Menu();
                int option_no = Convert.ToInt32(Console.ReadLine());
                if (option_no == 1)
                {
                    string employeName = GetName();
                    string employeeId = GetId();
                    int numberOfHours = GetWage();
                    Employee Employee_object = new Employee(employeName, employeeId, numberOfHours);
                    EmployeeList.Add(Employee_object);
                    double wage = Employee_object.CalcWage();
                    Console.WriteLine("The weekly wage is £" + wage.ToString("0.00"));
                    Console.ReadLine();
                }
                else if (option_no == 2)
                {
                    for (int x = 0; x < EmployeeList.Count; x++)
                    {
                        Employee data = (Employee)EmployeeList[x];
                        Console.WriteLine("Position Number " + x + " =" + data.GetEmployeData());
                    }
                    Console.ReadLine();

                }
                else if (option_no == 3)
                {
                    Console.WriteLine("Enter position number to remove the Employee =");
                    int positionNumber = Convert.ToInt32(Console.ReadLine());
                    EmployeeList.RemoveAt(positionNumber);
                    Console.WriteLine("Employee removed sucessfully");
                    Console.ReadLine();

                }
                else
                {
                    condition = false;
                }
            }
        }
    }
}


