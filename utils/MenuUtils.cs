using System.Text;

namespace MenuUtils;

public class MenuUtils
{
  public static void PrintAllTasks(List<string> TaskList)
  {
    int indexTask = 1;
    TaskList.ForEach(task => Console.WriteLine($"{indexTask++}. {task}"));
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
