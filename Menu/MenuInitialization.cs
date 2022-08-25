using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    internal class MenuInitialization
    {
        public static void InitializeMenu()
        {
            var menu = new MenuItem("Menu Principal");

            var employees = new MenuItem("Funcionários");
            employees.Add(new MenuItem("Encontrar Funcionário", Employee.GetEmployee));
            employees.Add(new MenuItem("Listar Funcionários", Employee.ListAllEmployees));
            employees.Add(new MenuItem("Cadastrar Funcionário", Employee.AddEmployee));
            employees.Add(new MenuItem("Editar Funcionário", Employee.EditEmployee));
            employees.Add(new MenuItem("Remover Funcionário", Employee.DeleteEmployee));

            menu.Add(employees);

            menu.Add(new MenuItem("Sair", () => Environment.Exit(0)));

            menu.Execute();
        }
    }
}
