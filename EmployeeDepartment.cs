using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Configuration;
using System.Text;
using System.Threading;
namespace EmployeeManagementSystem
{
    class EmployeeDepartment
    {
        public static MySqlConnection mySqlConnection;
        private int _choice;
        private int _count;
        private int _option;
        public static ArrayList EmployeeList = new ArrayList();
        public int ChoiceValue { get => _choice; set => _choice = value; }
        public int EmployeeCount { get => _count; set => _count = value; }
        public int OptionValue { get => _option; set => _option = value; }
        public void Getmenu()
        {
            Console.WriteLine("\n!!!Welcome to Aspire Systems!!!");
            Console.WriteLine("1. Create Employee details");
            Console.WriteLine("2. Read Employees details");
            Console.WriteLine("3. Update Employee details");
            Console.WriteLine("4. Delete Employee details");
            Console.WriteLine("5. Exit");
        }
        public void ChooseOperation()
        {
            try
            {
                using (mySqlConnection = new MySqlConnection())
                {
                    mySqlConnection.ConnectionString=ConfigurationManager.ConnectionStrings["EmployeeManagementSystemDatabase"].ConnectionString;
                    mySqlConnection.Open();
                    Console.WriteLine("\nEnter your choice between 1 to 5");
                    ChoiceValue = int.Parse(Console.ReadLine());
                    while (ChoiceValue != 5)
                    {
                        switch (ChoiceValue)
                        {
                            case 1:
                                CreateEmployees();
                                Getmenu();
                                break;
                            case 2:
                                ReadEmployee();
                                Getmenu();
                                break;
                            case 3:
                                UpdateEmployee();
                                Getmenu();
                                break;
                            case 4:
                                DeleteEmployee();
                                Getmenu();
                                break;
                            default:
                                Console.WriteLine("\nEnter valid input between 1 to 5");
                                Getmenu();
                                break;
                        }
                        Console.WriteLine("\nEnter your choice between 1 to 5");
                        ChoiceValue = int.Parse(Console.ReadLine());
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nEntered input is not valid. Enter valid input");
                ChooseOperation();
            }
        }
        public void CreateEmployees()
        {
            try
            {
                Console.WriteLine("\nEnter how many employees want to add.(Maximum limit is 10)");
                EmployeeCount = int.Parse(Console.ReadLine());
                for (int Index = 0; Index < EmployeeCount; Index++)
                {
                    Console.WriteLine("\nEnter your Designation shown below");
                    Console.WriteLine("1. Developer");
                    Console.WriteLine("2. Tester");
                    OptionValue = int.Parse(Console.ReadLine());
                    switch (OptionValue)
                    {
                        case 1:
                            Developer developer = new Developer();
                            developer.GetDeveloperInput();
                            EmployeeList.Add(developer);
                            break;
                        case 2:
                            Tester tester = new Tester();
                            tester.GetTesterInput();
                            EmployeeList.Add(tester);
                            break;
                        default:
                            Console.WriteLine("\nEntered input is not valid. Input should be 1 or 2");
                            CreateEmployees();
                            break;
                    }
                }
                Console.WriteLine("\nCongrats!! You have successfully added the employee details\n");
            }
            catch (Exception)
            {
                Console.WriteLine("\nEntered input is not valid. Enter valid input\n");
                CreateEmployees();
            }
        }
        public void ReadEmployee()
        {
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.CommandText = "SELECT count(*) FROM employee_management_system.employee_details";
            mySqlCommand.Connection = mySqlConnection;
            if (Convert.ToInt32(mySqlCommand.ExecuteScalar()) == 0)
            {
                Console.WriteLine("\nPlease create a employee details first..!!!!\n");
            }
            else
            {
                mySqlCommand.CommandText = "SELECT * FROM employee_management_system.employee_details";
                mySqlCommand.Connection = mySqlConnection;
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Console.WriteLine("Employee ID : " + mySqlDataReader["employeeid"]);
                    Console.WriteLine("Employee Name : " + mySqlDataReader["employeename"]);
                    Console.WriteLine("Employee Date of Birth : " + mySqlDataReader.GetDateTime("dateofbirth").ToShortDateString());
                    Console.WriteLine("Employee Date of Joining : " + mySqlDataReader.GetDateTime("dateofjoining").ToShortDateString());
                    Console.WriteLine("Employee Email Address : " + mySqlDataReader["emailid"]);
                    Console.WriteLine("Employee Salary : " + mySqlDataReader["salary"] + " LPA");
                    Console.WriteLine("Employee Bonus : " + mySqlDataReader["bonus"]);
                    Console.WriteLine("Employee Work Experience : " + mySqlDataReader["experience"] + "Year(s)\n");
                }
                mySqlDataReader.Close();
            }
        }
        public void UpdateEmployee()
        {
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.CommandText = "SELECT count(*) FROM employee_management_system.employee_details";
            mySqlCommand.Connection = mySqlConnection;
            if (Convert.ToInt32(mySqlCommand.ExecuteScalar()) == 0)
            {
                Console.WriteLine("\nPlease create a employee details first..!!!!\n");
            }
            else
            {
                Console.WriteLine("\nEnter Employee Id which you want to update");
                string employeeId = Console.ReadLine();
                mySqlCommand.CommandText = $"SELECT count(employeeid) FROM employee_management_system.employee_details where employeeid='{employeeId}'";
                //mySqlCommand.Connection = mySqlConnection;
                if (Convert.ToInt32(mySqlCommand.ExecuteScalar()) == 0)
                {
                    Console.WriteLine("\nEmployee not found..!!!");
                }
                else
                {
                    try
                    {
                        Console.WriteLine("1. Employee name");
                        Console.WriteLine("2. Employee DOB");
                        Console.WriteLine("3. Employee DOJ");
                        Console.WriteLine("4. Employee Email");
                        Console.WriteLine("5. Exit update");
                        Console.WriteLine("\nEnter your input");
                        int Choice = int.Parse(Console.ReadLine());
                        Aspiresystem aspireSystem = new Aspiresystem();
                        while (Choice != 5)
                        {
                            switch (Choice)
                            {
                                case 1:

                                    aspireSystem.GetEmployeeName();
                                    mySqlCommand.CommandText = $"UPDATE employee_management_system.employee_details SET employeename = '{aspireSystem.EmplyoeeName}' WHERE employeeid = '{employeeId}'";
                                    mySqlCommand.ExecuteNonQuery();
                                    Console.WriteLine("\nEmployee name updated!!");
                                    break;
                                case 2:
                                    aspireSystem.GetDateOfBirth();
                                    mySqlCommand.CommandText = $"UPDATE employee_management_system.employee_details SET dateofbirth = '{aspireSystem.EmployeeDateOfBirthProperty.ToString("yyyy'-'MM'-'dd")}' WHERE employeeid = '{employeeId}'";
                                    mySqlCommand.ExecuteNonQuery();
                                    Console.WriteLine("\nEmployee Date of birth updated!!");
                                    break;
                                case 3:
                                    aspireSystem.GetDateOfJoining();
                                    mySqlCommand.CommandText = $"UPDATE employee_management_system.employee_details SET dateofjoining = '{aspireSystem.EmployeeDateOfJoiningProperty.ToString("yyyy'-'MM'-'dd")}' WHERE employeeid = '{employeeId}'";
                                    mySqlCommand.ExecuteNonQuery();
                                    CalculateSalaryBasedOnDesignation(aspireSystem, mySqlCommand, employeeId);
                                    Console.WriteLine("\nEmployee Date of joining updated!!");
                                    break;
                                case 4:
                                    aspireSystem.GetEmailAdresss();
                                    mySqlCommand.CommandText = $"UPDATE employee_management_system.employee_details SET emailid = '{aspireSystem.EmployeeEmailID}' WHERE employeeid = '{employeeId}'";
                                    mySqlCommand.ExecuteNonQuery();
                                    Console.WriteLine("\nEmployee Email address updated!!");

                                    break;
                                default:
                                    Console.WriteLine("\nInvalid choice. Enter between 1 to 5");
                                    break;
                            }
                            Console.WriteLine("\nEnter your input");
                            Choice = int.Parse(Console.ReadLine());
                        }
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("\nPlease enter valid input!!!");
                    }

                }

            }            
        }
        private void CalculateSalaryBasedOnDesignation(Aspiresystem aspiresystem,MySqlCommand mySqlCommand,string EmployeeId)
        {
            Console.WriteLine("\nEnter desingnation\n1.Developer\n2.Tester");
            try
            {
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        aspiresystem.CalculateSalary(100000);
                        break;
                    case 2:
                        aspiresystem.CalculateSalary();
                        break;
                    default:
                        Console.WriteLine("Enter 1 or 2");
                        break;
                }
                mySqlCommand.CommandText = $"UPDATE employee_management_system.employee_details SET salary = '{aspiresystem.EmployeeSalary}',bonus='{aspiresystem.DeveloperBonus}',experience='{aspiresystem.EmployeeExperience}' WHERE employeeid = '{EmployeeId}'";
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine("\nEnter 1 or 2");
                CalculateSalaryBasedOnDesignation(aspiresystem, mySqlCommand, EmployeeId);
            }
        }
        public void DeleteEmployee()
        {
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.CommandText = "SELECT count(*) FROM employee_management_system.employee_details";
            mySqlCommand.Connection = mySqlConnection;
            if (Convert.ToInt32(mySqlCommand.ExecuteScalar()) == 0)
            {
                Console.WriteLine("\nPlease create a employee details first..!!!!\n");
            }
            else
            {
                Console.WriteLine("\nEnter Employee Id which you want to delete");
                string employeeId = Console.ReadLine();
                mySqlCommand.CommandText = $"SELECT count(employeeid) FROM employee_management_system.employee_details where employeeid='{employeeId}'";
                //mySqlCommand.Connection = mySqlConnection;
                if (Convert.ToInt32(mySqlCommand.ExecuteScalar()) == 0)
                {
                    Console.WriteLine("\nEmployee not found..!!!");
                }
                else
                {
                    mySqlCommand.CommandText = $"delete from employee_management_system.employee_details where employeeid='{employeeId}'";
                    mySqlCommand.ExecuteNonQuery();
                    Console.WriteLine("\nEmployee deleted.");
                }

            }            
        }
    }
}
