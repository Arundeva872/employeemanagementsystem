/*Title : Employee manganement system 
  Description : Prints the salary and experience based on desingnation
  Author name : Devarajan S
  Created at: 29/09/2021
  Updated at: 16/11/2021
  Reviewed by : Akshaya*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
    class AspireSystems
    {
        static void Main(string[] args)
        {
            EmployeeDepartment employeeDepartment = new EmployeeDepartment();
            employeeDepartment.Getmenu();
            employeeDepartment.ChooseOperation();
        }
    }
}
