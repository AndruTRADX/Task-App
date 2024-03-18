using System;
using System.Collections.Generic;
using System.Text;

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
        else
        {
          OptionNoValid();
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
        PrintConsoleLines(30);

        string inputOptionSelected = Console.ReadLine();

        // Remove one position
        int indexToRemove = Convert.ToInt32(inputOptionSelected) - 1;
        if (indexToRemove > -1)
        {
          if (TaskList.Count > 0)
          {
            string task = TaskList[indexToRemove];
            TaskList.RemoveAt(indexToRemove);
            Console.WriteLine("Tarea " + task + " eliminada");
          }
        }
      }
      catch (Exception)
      {
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

    public static void ShowMenuTasksList()
    {
      if (TaskList == null || TaskList.Count == 0)
      {
        Console.WriteLine("No hay tareas por realizar");
      }
      else
      {
        PrintConsoleLines(30);
        PrintAllTasks(TaskList);
        PrintConsoleLines(30);
      }
    }

    // Utilities
    public static void PrintAllTasks(List<string> TaskList)
    {
      for (int i = 0; i < TaskList.Count; i++)
      {
        Console.WriteLine(i + 1 + ". " + TaskList[i]);
      }
    }

    public static void PrintConsoleLines(int linesQuantity)
    {
      var sb = new StringBuilder();

      for (int i = 0; i < linesQuantity && i < 30; i++)
      {
        sb.Append('-');
      }

      Console.WriteLine(sb.ToString());
    }

    public static void OptionNoValid()
    {
      PrintConsoleLines(30);
      Console.WriteLine("Opción no válida, por favor selecciona una opción válida");
    }

    public enum MenuOptions
    {
      Add = 1,
      Remove = 2,
      List = 3,
      Exit = 4
    }
  }
}
