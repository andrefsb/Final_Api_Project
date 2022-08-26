using Menu.Menu_Console;

namespace Menu
{
    internal class Program
    {
        static void Main()
        {
            MenuItem.SetPrompt();
            Console.Title = "Employee Services:";

            MenuInitialization.InitializeMenu();

        }
    }
}