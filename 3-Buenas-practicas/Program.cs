using System;
using System.Collections.Generic;
List<string> TaskList =  new List<string>();

namespace ToDo
{
    internal class Program
    {
        // *inicializamos aqui para ahorrar 1 linea de codigo
        public static List<string> TaskList { get; set; } = new List<string>();

        static void Main(string[] args)
        {
            int manuSelected = 0;
            do
            {
                manuSelected = ShowMainMenu();
                if ((Menu)manuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)manuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)manuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)manuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                ShowMenuTaskList();
                string taskNumberToDelete = Console.ReadLine();
                //remove one position because the array starts in 0
                int indexToRemove = Convert.ToInt32(taskNumberToDelete) - 1;
                if(indexToRemove > (TaskList.Count -1) || indexToRemove <0) 
                    Console.WriteLine("Numero de tarea selecionado no es valido");
                else
                {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                            string taskToRemove = TaskList[indexToRemove];
                            TaskList.RemoveAt(indexToRemove);
                            Console.WriteLine("Tarea " + taskToRemove + " eliminada");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList?.Count > 0)
            {
                Console.WriteLine("----------------------------------------");
                var indexTask=1;
                TaskList.ForEach(p=> Console.WriteLine($"{indexTask++} . {p}"));
                
                Console.WriteLine("----------------------------------------");
            } 
            else
            {
                Console.WriteLine("No hay tareas por realizar");
            }
        }
    }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
}
