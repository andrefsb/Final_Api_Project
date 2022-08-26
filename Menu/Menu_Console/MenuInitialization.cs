using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Menu_Console
{
    internal class MenuInitialization
    {
        public static void InitializeMenu()
        {
            var menu = new MenuItem("Main Menu");

            var employees = new MenuItem("Employees");
            employees.Add(new MenuItem("Find employee", Employee.GetEmployee));
            employees.Add(new MenuItem("List all employees", Employee.ListAllEmployees));
            employees.Add(new MenuItem("Create new employee", Employee.AddEmployee));
            employees.Add(new MenuItem("Edit employee", Employee.EditEmployee));
            employees.Add(new MenuItem("Remove employee", Employee.DeleteEmployee));

            menu.Add(employees);

            menu.Add(new MenuItem("Exit", () => Environment.Exit(0)));

            menu.Execute();
        }
    }
}
