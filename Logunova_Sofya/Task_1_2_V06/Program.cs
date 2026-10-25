using System.Globalization;
using System.Text;

namespace Task_1_2_V06;

internal static class Program
{
    private static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        try
        {
            Console.WriteLine("Задание 1.2, вариант 6. Расстояние между двумя точками.");
            double x1 = ReadCoordinate("Введите x1: ");
            double y1 = ReadCoordinate("Введите y1: ");
            double x2 = ReadCoordinate("Введите x2: ");
            double y2 = ReadCoordinate("Введите y2: ");
            double distance = CalculateDistance(x1, y1, x2, y2);
            PrintResult(distance);
        }
        catch (Exception error) when (error is EndOfStreamException or ArithmeticException)
        {
            Console.Error.WriteLine(error.Message);
            Environment.ExitCode = 1;
        }
    }

    private static double ReadCoordinate(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()
                ?? throw new EndOfStreamException("Ввод завершён до получения всех координат.");

            if (double.TryParse(input.Replace(',', '.'), NumberStyles.Float,
                    CultureInfo.InvariantCulture, out double value) && double.IsFinite(value))
            {
                return value;
            }

            Console.WriteLine("Ошибка: введите конечное число. Можно использовать точку или запятую.");
        }
    }

    private static double CalculateDistance(double x1, double y1, double x2, double y2)
    {
        double dx = x2 - x1;
        double dy = y2 - y1;
        double distance = Math.Sqrt(dx * dx + dy * dy);

        if (!double.IsFinite(distance))
        {
            throw new ArithmeticException("Ошибка: слишком большие значения для вычисления расстояния.");
        }

        return distance;
    }

    private static void PrintResult(double distance)
    {
        Console.WriteLine($"Расстояние между точками: {distance.ToString("G17", CultureInfo.InvariantCulture)}");
    }
}
