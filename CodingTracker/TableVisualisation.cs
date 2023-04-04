using ConsoleTableExt;

namespace CodingTracker
{
    internal class TableVisualisation
    {
        internal static void ShowTable<T>(List<T> tableData) where T : class
        {
            Console.Clear();

            ConsoleTableBuilder
                .From(tableData)
                .WithTitle("Coding Tracker")
                .ExportAndWriteLine();

            Console.ReadKey();
        }
    }
}