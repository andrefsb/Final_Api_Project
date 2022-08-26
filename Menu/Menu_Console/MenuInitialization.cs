using Menu.Entities;


namespace Menu.Menu_Console
{
    internal class MenuInitialization
    {
        public static void InitializeMenu()
        {
            var menu = new MenuItem("Main Menu");

            var employees = new MenuItem("Employees");
            employees.Add(new MenuItem("Find employee", InitializeSubMenu));
            employees.Add(new MenuItem("List all employees", Employee.ListAllEmployees));
            employees.Add(new MenuItem("Create new employee", Employee.AddEmployee));
            employees.Add(new MenuItem("Edit employee", Employee.EditEmployee));
            employees.Add(new MenuItem("Remove employee", Employee.DeleteEmployee));

            menu.Add(employees);

            menu.Add(new MenuItem("Exit", () => Environment.Exit(0)));

            menu.Execute();
        }
        public static void InitializeSubMenu()
        {
            var menu = new MenuItem("Employee Search Menu");

            menu.Add(new MenuItem("Find employee by Id", Employee.GetEmployee));
            menu.Add(new MenuItem("Find Employee by Name", Employee.GetEmployeeByName));
            menu.Add(new MenuItem("Find employee by Gender", null));
            menu.Add(new MenuItem("Find employee by Ip Adress", null));

            menu.Execute();
        }
    }
}
