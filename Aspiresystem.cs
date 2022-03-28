using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    class Aspiresystem
    {
        private string _emplyoeeName;
        private string _employeeId;
        private DateTime _employeeDateOfBirth;
        private DateTime _employeeDateOfJoining;
        private string _employeeEmailId;
        private double _salary;
        private double _bonus;
        private static int _count;
        private int _experience;
        public double EmployeeSalary { get => _salary; set => _salary = value; }
        public DateTime EmployeeDateOfJoiningProperty { get => _employeeDateOfJoining; set => _employeeDateOfJoining = value; }
        public double DeveloperBonus { get => _bonus; set => _bonus = value; }
        public string EmployeeID { get => _employeeId; set => _employeeId = value; }
        public int EmployeeExperience { get => _experience; set => _experience = value; }
        public static int EmployeeCount { get => _count; set => _count = value; }
        public string EmployeeEmailID { get => _employeeEmailId; set => _employeeEmailId = value; }
        public string EmplyoeeName { get => _emplyoeeName; set => _emplyoeeName = value; }
        public DateTime EmployeeDateOfBirthProperty { get => _employeeDateOfBirth; set => _employeeDateOfBirth = value; }

        public Hashtable EmployeeTable = new Hashtable();
        public void GetEmployeeName()
        {
            try
            {
                Console.WriteLine("\nEnter your Name");
                EmplyoeeName = Console.ReadLine();
                for (int Count = 0; Count < EmplyoeeName.Length; Count++)
                {
                    if (char.IsLetter(EmplyoeeName[Count]) == false)
                    {
                        Console.WriteLine("\nEntered name is not valid. Employee name should not contain any speacial characters or numbers\n");
                        GetEmployeeName();
                    }
                }
                if (EmplyoeeName.Length <= 2)
                {
                    Console.WriteLine("\nYour name is too short\n");
                    GetEmployeeName();
                }
                for (int Count = 0; Count < EmplyoeeName.Length - 2; Count++)
                {
                    if ((EmplyoeeName[Count] == EmplyoeeName[Count + 1]) && (EmplyoeeName[Count] == EmplyoeeName[Count + 2]))
                    {
                        Console.WriteLine("\nEntered name is not valid. Employee name should not contain same repetitive letters more than 2 times\n");
                        GetEmployeeName();
                    }
                }
                if (EmployeeTable.ContainsKey(1))
                    EmployeeTable[1] = EmplyoeeName;
                else
                    EmployeeTable.Add(1, EmplyoeeName);
            }
            catch (Exception)
            {
                Console.WriteLine("\nEntered name is not valid. Please enter a valid name\n");
                GetEmployeeName();
            }

        }
        public void GetEmployeeId()
        {

            try
            {
                Console.WriteLine("\nEnter your Employee Id");
                EmployeeID = Console.ReadLine();
                //EmployeeHashtable.Add(2, Console.ReadLine());
                if (EmployeeID.Contains("0000"))
                {
                    Console.WriteLine("\nEntered Employee Id is not valid. Employee cannot have ID as 0000. Please enter valid Employee Id\n");
                    GetEmployeeId();
                }
                if (EmployeeID == " " || EmployeeID == "")
                {
                    Console.WriteLine("\nEmployee ID cannot be empty\n");
                    GetEmployeeId();
                }
                if (EmployeeID.Length != 7 || EmployeeID.Substring(0, 3) != "ACE")
                {
                    Console.WriteLine("\nEntered Employee ID is not valid!!!. It should contain 'ACE' followed by 4 digits. Provide correct format like ACE1234\n");
                    GetEmployeeId();
                }
                else
                {
                    for (int Count = 3; Count <= EmployeeID.Length - 1; Count++)
                    {
                        if (char.IsDigit(EmployeeID[Count]) == false)
                        {
                            Console.WriteLine("\nEntered Employee ID is not valid. It should contain 'ACE' followed by 4 digits. Provide correct format like ACE1234\n");
                            GetEmployeeId();
                        }
                    }
                }
                if (EmployeeTable.ContainsKey(2))
                    EmployeeTable[2] = EmployeeID;
                else
                    EmployeeTable.Add(2, EmployeeID);
            }
            catch (Exception)
            {
                Console.WriteLine("\nEntered Employee ID is not valid. It should contain 'ACE' followed by 4 digits. Provide correct format like ACE1234\n");
                GetEmployeeId();
            }

        }
        public void GetDateOfBirth()
        {
            try
            {
                Console.WriteLine("\nEnter your Date of Birth (dd/mm/yyyy)");
                EmployeeDateOfBirthProperty = DateTime.Parse(Console.ReadLine());
                // EmployeeHashtable.Add(3, DateTime.Parse(Console.ReadLine()));
                if (DateTime.Now.Year - EmployeeDateOfBirthProperty.Year <= 18 || DateTime.Now.Year - EmployeeDateOfBirthProperty.Year >= 60)
                {
                    Console.WriteLine("\nEntered date of birth is not valid.Employee age must be between 18 to 60\n");
                    GetDateOfBirth();
                }
                if (EmployeeTable.ContainsKey(3))
                    EmployeeTable[3] = EmployeeDateOfBirthProperty;
                else
                    EmployeeTable.Add(3, EmployeeDateOfBirthProperty);
            }
            catch (Exception)
            {
                Console.WriteLine("\nEntered date of birth is not valid. Please enter valid date\n");
                GetDateOfBirth();
            }

        }
        public void GetDateOfJoining()
        {

            try
            {
                Console.WriteLine("\nEnter your Date of Joining (dd/mm/yyyy)");
                EmployeeDateOfJoiningProperty = DateTime.Parse(Console.ReadLine());
                //EmployeeHashtable.Add(4, DateTime.Parse(Console.ReadLine()));

                if (DateTime.Now.Year - EmployeeDateOfJoiningProperty.Year > DateTime.Now.Year - EmployeeDateOfBirthProperty.Year - 18)
                {
                    Console.WriteLine("\nYou cannot have any experience for your age!!!\n");
                    GetDateOfJoining();
                }
                if (EmployeeDateOfJoiningProperty > DateTime.Now)
                {
                    Console.WriteLine("\nJoining date cannot be a future date\n");
                    GetDateOfJoining();
                }
                if (EmployeeTable.ContainsKey(4))
                    EmployeeTable[4] = EmployeeDateOfJoiningProperty;
                else
                    EmployeeTable.Add(4, EmployeeDateOfJoiningProperty);
            }
            catch (Exception)
            {
                Console.WriteLine("\nEntered Date of joining is not valid. Please enter valid date\n");
                GetDateOfJoining();
            }

        }
        public void GetEmailAdresss()
        {
            try
            {
                Console.WriteLine("\nEnter your Email Address");
                EmployeeEmailID = Console.ReadLine();
                //EmployeeHashtable.Add(5, Console.ReadLine());
                if (EmployeeEmailID.Contains(' '))
                {
                    Console.WriteLine("\nEntered email address is not valid. Please enter email like 'sample@gmail.com'\n");
                    GetEmailAdresss();
                }
                if (EmployeeEmailID.Contains('@') == false)
                {
                    Console.WriteLine("\nEmail address must have '@' symbol. Provide email address like 'sample@gmail.com' \n");
                    GetEmailAdresss();
                }
                else if (EmployeeEmailID.Contains('.') == false)
                {
                    Console.WriteLine("\nEmail address must have '.' symbol. Provide email address like 'sample@gmail.com' \n");
                    GetEmailAdresss();
                }
                else if (EmployeeEmailID.Length < 8 || EmployeeEmailID.IndexOf('@') != EmployeeEmailID.LastIndexOf('@'))
                {
                    Console.WriteLine("\nEntered email address is not valid. Provide a valid email address like 'sample@gmail.com'\n");
                    GetEmailAdresss();
                }
                else
                {
                    String UsernamePart = EmployeeEmailID.Substring(0, EmployeeEmailID.LastIndexOf('@'));
                    //Console.WriteLine(UsernamePart);
                    String DomainPart = EmployeeEmailID.Substring(EmployeeEmailID.LastIndexOf('@') + 1, EmployeeEmailID.LastIndexOf('.') - EmployeeEmailID.LastIndexOf('@') - 1);
                    //Console.WriteLine(DomainPart);
                    String TopLevelDomainPart = EmployeeEmailID.Substring(EmployeeEmailID.LastIndexOf('.') + 1);
                    //Console.WriteLine(TopLevelDomainPart);
                    if (UsernamePart.Length < 1)
                    {
                        Console.WriteLine("\nEntered email address is not valid. Username should not be empty. Provide email address like 'sample@gmail.com'\n");
                        GetEmailAdresss();
                    }
                    if (DomainPart.Length <= 2)
                    {
                        Console.WriteLine("\nEntered email address is not valid. Provide a valid email address like 'sample@gmail.com\n");
                        GetEmailAdresss();
                    }
                    if (TopLevelDomainPart.Length < 2)
                    {
                        Console.WriteLine("\nEntered email address is not valid. Provide a valid email address like 'sample@gmail.com\n");
                        GetEmailAdresss();
                    }
                    for (int Count = 0; Count < UsernamePart.Length; Count++)
                    {
                        if (Char.IsLetterOrDigit(UsernamePart[Count]) == false && UsernamePart[Count] != '.')
                        {
                            Console.WriteLine("\nEntered email address is not valid. Username should not contain any special characters. Provide email address like 'sample@gmail.com'\n");
                            GetEmailAdresss();
                            goto Validated;
                        }
                    }
                    for (int Count = 0; Count < DomainPart.Length; Count++)
                    {
                        if (Char.IsLetter(DomainPart[Count]) == false)
                        {
                            Console.WriteLine("\nEntered email address is not valid. Domain name should not contain numbers and special characters. Provide email address like 'sample@gmail.com'\n");
                            GetEmailAdresss();
                            goto Validated;
                        }
                    }
                    for (int Count = 0; Count < TopLevelDomainPart.Length; Count++)
                    {
                        if (Char.IsLetter(TopLevelDomainPart[Count]) == false)
                        {
                            Console.WriteLine("\nEntered email address is not valid. Top level Domain name should not contain numbers and special characters. Provide email address like 'sample@gmail.com'\n");
                            GetEmailAdresss();
                            goto Validated;
                        }
                    }
                }
            Validated:
                if (EmployeeTable.ContainsKey(5))
                    EmployeeTable[5] = EmployeeEmailID;
                else
                    EmployeeTable.Add(5, EmployeeEmailID);
            }
            catch (Exception)
            {
                Console.WriteLine("\nEnter email address is not valid. Please enter valid email address like 'sample@gmail.com'\n");
                GetEmailAdresss();
            }

        }        
        public void CalculateSalary(double developerBonus)
        {
            EmployeeExperience = DateTime.Now.Year - EmployeeDateOfJoiningProperty.Year;
            DeveloperBonus = developerBonus;
            if (EmployeeExperience <= 2)
            {
                EmployeeSalary = 5;
            }
            else if (EmployeeExperience > 2 && EmployeeExperience <= 10)
            {
                EmployeeSalary = 8;
            }
            else
            {
                EmployeeSalary = 15;
            }
        }
        public void CalculateSalary()
        {
            EmployeeExperience = DateTime.Now.Year - EmployeeDateOfJoiningProperty.Year;
            if (EmployeeExperience <= 2)
            {
                EmployeeSalary = 3;
            }
            else if (EmployeeExperience > 2 && EmployeeExperience <= 10)
            {
                EmployeeSalary = 5;
            }
            else
            {
                EmployeeSalary = 8;
            }
        }
        public void InsertingEmployee()
        {         
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand();
                mySqlCommand.CommandText = $"insert into  employee_management_system.employee_details values('{EmployeeID}','{EmplyoeeName}', '{EmployeeDateOfBirthProperty.ToString("yyyy'-'MM'-'dd")}','{EmployeeDateOfJoiningProperty.ToString("yyyy'-'MM'-'dd")}', '{EmployeeEmailID}',{_salary},{_bonus},'{EmployeeExperience}')";
                mySqlCommand.Connection = EmployeeDepartment.mySqlConnection;
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                EmployeeDepartment employeeDepartment = new EmployeeDepartment();
                employeeDepartment.CreateEmployees();
            }
        }
    }
    class Developer : Aspiresystem, Salary
    {
        public void GetDeveloperInput()
        {
            GetEmployeeId();
            GetEmployeeName();
            GetDateOfBirth();
            GetDateOfJoining();
            GetEmailAdresss();
            DeveloperBonus = 100000;
            CalculateSalary(DeveloperBonus);
            InsertingEmployee();
        }
    }
    class Tester : Aspiresystem, Salary
    {
        public void GetTesterInput()
        {
            GetEmployeeId();
            GetEmployeeName();
            GetDateOfBirth();
            GetDateOfJoining();
            GetEmailAdresss();
            DeveloperBonus = 0;
            CalculateSalary();
            InsertingEmployee();
        }
    }
}
