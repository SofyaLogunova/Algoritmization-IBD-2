using System.Globalization;
using System.Text;

namespace Task_1_2_V01;

internal class Program
{
    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

        try
        {
            double a = ReadNumber("Введите сторону a: ", true);
            double b = ReadNumber("Введите сторону b: ", true);
            double area = CalculateArea(a, b);
            double perimeter = CalculatePerimeter(a, b);
            PrintResult(area, perimeter);
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

    static double CalculateArea(double a, double b)
    {
        return a * b;
    }

    static double CalculatePerimeter(double a, double b)
    {
        return 2 * (a + b);
    }

    static void PrintResult(double area, double perimeter)
    {
        if (!double.IsFinite(area) || !double.IsFinite(perimeter))
            throw new ArithmeticException("Результат слишком велик для вычисления.");

        Console.WriteLine($"Площадь = {area:G17}");
        Console.WriteLine($"Периметр = {perimeter:G17}");
    }
}
