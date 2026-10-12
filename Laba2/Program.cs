using ConsoleApp.ConsoleObject.Menu;
using ConsoleApp.ConsoleObject.Table;
using ConsoleApp.ConsoleObject.Table.TableRows;
using Laba2.ConsoleObject.Table.TableRows;
public class Program
{
    public static Table choiceSortField = new Table("choiceSortField", new List<ITableRow>()
    {
        new TableRow(new List<object>(){ "1", "Название" }),
        new TableRow(new List<object>(){ "2", "Название" }),
        new TableRow(new List<object>(){ "3", "Название" }),
        new TableRow(new List<object>(){ "4", "Название" }),
    });
    public static void Main(string[] args)
    {
        choiceSortField.Print();
    }
}