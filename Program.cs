using static MenuUtils.MenuUtils;

namespace ToDo;

internal class Program
{
  public static List<string> TaskList { get; set; } = [];

  static void Main(string[] args)
  {
    int menuSelected;

    do
    {
      menuSelected = ShowMainMenu();

      switch ((MenuOptions)menuSelected)
      {
        case MenuOptions.Add:
          ShowMenuAdd();
          break;
        case MenuOptions.Remove:
          ShowMenuRemove();
          break;
        case MenuOptions.List:
          ShowMenuTasksList();
          break;
        case MenuOptions.Exit:
          Console.WriteLine("Saliendo...");
          break;
        default:
          Console.WriteLine("Opción no válida, por favor selecciona una opción válida");
          break;
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

    if (int.TryParse(Console.ReadLine(), out int inputOptionSelected))
    {
      return inputOptionSelected;
    }
    else
    {
      PrintConsoleLines(30);
      Console.WriteLine("Error: Opción no válida, por favor ingrese un número.");
      return -1;
    }
  }

  public static void ShowMenuRemove()
  {

    {
      Console.WriteLine("Ingrese el número de la tarea a remover: ");

      PrintConsoleLines(30);
      PrintAllTasks(TaskList);

      PrintConsoleLines(30);
      if (int.TryParse(Console.ReadLine(), out int inputOptionSelected))
      {
        int indexToRemove = inputOptionSelected - 1;
        if (indexToRemove >= 0 && indexToRemove < TaskList.Count)
        {
          string task = TaskList[indexToRemove];
          TaskList.RemoveAt(indexToRemove);
          Console.WriteLine($"Tarea {task} eliminada");
        }
        else
        {
          Console.WriteLine("Error: Por favor selecciona una tarea válida");
        }
      }
      else
      {
        Console.WriteLine("Error: Por favor ingrese un número válido.");
      }
    }
  }

  public static void ShowMenuAdd()
  {
    Console.WriteLine("Ingrese el nombre de la tarea: ");
    string task = Console.ReadLine();
    PrintConsoleLines(30);

    if (task != "")
    {
      TaskList.Add(task);
      Console.WriteLine("Tarea registrada");
    }
    else
    {
      Console.WriteLine("Error: Tarea NO registrada");
    }
  }

  public static void ShowMenuTasksList()
  {
    PrintConsoleLines(30);

    if (TaskList?.Count == 0)
    {
      Console.WriteLine("No hay tareas por realizar");
    }
    else
    {
      PrintAllTasks(TaskList);
    }
  }
}
