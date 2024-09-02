using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

internal class Program
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.Write("Введите арифметическое выражение (или 'exit' для выхода): ");
            string input = Console.ReadLine();

            if (input?.ToLower() == "exit")
                break;

            try
            {
                var options = ScriptOptions.Default.AddReferences(typeof(Math).Assembly).AddImports("System", "System.Math");

                var result = await CSharpScript.EvaluateAsync(input, options);
                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}