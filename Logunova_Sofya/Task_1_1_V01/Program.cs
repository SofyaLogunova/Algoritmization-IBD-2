using System.Globalization;
using System.Text;

namespace Task_1_1_V01;

internal class Program
{
    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        try
        {
            const double a = 2;
            const double b = 3;
            const double c = 4;

            double x = ReadNumber("Введите x: ");
            double y = CalculateY(x, a, b, c);
            PrintResult(x, y);
        }
        catch (Exception error) when (error is EndOfStreamException or ArithmeticException)
        {
            Console.Error.WriteLine(error.Message);
            Environment.ExitCode = 1;
        }
    }

    static double ReadNumber(string prompt, bool positive = false)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()
                ?? throw new EndOfStreamException("Ввод завершён до получения всех данных.");

            if (double.TryParse(input.Replace(',', '.'), NumberStyles.Float,
                CultureInfo.InvariantCulture, out double value)
                && double.IsFinite(value) && (!positive || value > 0))
                return value;

            Console.WriteLine(positive
                ? "Введите положительное число."
                : "Введите конечное число.");
        }
    }

    static double CalculateY(double x, double a, double b, double c)
    {
        return a * Math.Abs(Math.Pow(x, 3) - b) / Math.Sqrt(x * x + c)
            + 3.0 / 4.0 * Math.Pow(Math.Sin(x), 2);
    }

    static void PrintResult(double x, double y)
    {
        if (!double.IsFinite(y))
            throw new ArithmeticException("Результат слишком велик для вычисления.");

        Console.WriteLine($"x = {x}");
        Console.WriteLine($"y = {y:F10}");
    }
}
