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
        if (menuSelected == 1)
        {
          ShowMenuAdd();
        }
        else if (menuSelected == 2)
        {
          ShowMenuRemove();
        }
        else if (menuSelected == 3)
        {
          ShowMenuTasksLits();
        }
      } while (menuSelected != 4);
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
      string line = Console.ReadLine();
      return Convert.ToInt32(line);
    }

    public static void ShowMenuRemove()
    {
      try
      {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");

        // Show current task
        for (int i = 0; i < TaskList.Count; i++)
        {
          Console.WriteLine(i + 1 + ". " + TaskList[i]);
        }

        PrintConsoleLines(30);

        string inputTask = Console.ReadLine();

        // Remove one position
        int indexToRemove = Convert.ToInt32(inputTask) - 1;
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

    public static void ShowMenuTasksLits()
    {
      if (TaskList == null || TaskList.Count == 0)
      {
        Console.WriteLine("No hay tareas por realizar");
      }
      else
      {
        for (int i = 0; i < TaskList.Count; i++)
        {
          Console.WriteLine(i + 1 + ". " + TaskList[i]);
        }

        PrintConsoleLines(30);
      }
    }

    // Utilities
    public static void PrintConsoleLines(int linesQuantity)
    {
      var sb = new StringBuilder();

      for (int i = 0; i < linesQuantity && i < 30; i++)
      {
        sb.Append('-');
      }

      Console.WriteLine(sb);
    }
  }
}
