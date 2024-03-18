using System;
using System.Collections.Generic;

using static MenuUtils.MenuUtils;

namespace ToDo
{
  internal class Program
  {
    public static List<string> TaskList { get; set; }

    static void Main(string[] args)
    {
      TaskList = new List<string>();
      int menuSelected;

      do
      {
        menuSelected = ShowMainMenu();

        if ((MenuOptions)menuSelected == MenuOptions.Add)
        {
          ShowMenuAdd();
        }
        else if ((MenuOptions)menuSelected == MenuOptions.Remove)
        {
          ShowMenuRemove();
        }
        else if ((MenuOptions)menuSelected == MenuOptions.List)
        {
          ShowMenuTasksList();
        }
      } while ((MenuOptions)menuSelected != MenuOptions.Exit);
    }

    public static int ShowMainMenu()
    {
      PrintConsoleLines(30);

      Console.WriteLine("Ingrese la opción a realizar: ");
      Console.WriteLine("1. Nueva tarea");
      Console.WriteLine("2. Remover tarea");
      Console.WriteLine("3. Tareas pendientes");
      Console.WriteLine("4. Salir");

      // Read line
      string inputOptionSelected = Console.ReadLine();
      return Convert.ToInt32(inputOptionSelected);
    }

    public static void ShowMenuRemove()
    {
      try
      {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");

        PrintConsoleLines(30);
        PrintAllTasks(TaskList);

        string inputOptionSelected = Console.ReadLine();

        // Remove one position
        int indexToRemove = Convert.ToInt32(inputOptionSelected) - 1;
        if (indexToRemove > -1 || TaskList.Count > 0)
        {
          string task = TaskList[indexToRemove];
          TaskList.RemoveAt(indexToRemove);
          Console.WriteLine("Tarea " + task + " eliminada");
        }
      }
      catch (FormatException)
      {
        Console.WriteLine("Error: Ingrese un número válido.");
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: " + ex.Message);
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
      catch (Exception ex)
      {
        Console.WriteLine("Error: " + ex.Message);
      }
    }

    public static void ShowMenuTasksList()
    {
      PrintConsoleLines(30);

      if (TaskList == null || TaskList.Count == 0)
      {
        Console.WriteLine("No hay tareas por realizar");
      }
      else
      {
        PrintAllTasks(TaskList);
      }
    }
  }
}