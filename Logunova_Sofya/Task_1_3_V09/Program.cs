using System.Globalization;
using System.Text;

namespace Task_1_3_V09;

internal static class Program
{
    private static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        try
        {
            Console.WriteLine("Задание 1.3, вариант 9. Последовательное соединение резисторов.");
            double r1 = ReadResistance("Введите сопротивление R1 в омах: ");
            double r2 = ReadResistance("Введите сопротивление R2 в омах: ");
            double r3 = ReadResistance("Введите сопротивление R3 в омах: ");
            double totalResistance = CalculateTotalResistance(r1, r2, r3);
            PrintResult(totalResistance);
        }
        catch (Exception error) when (error is EndOfStreamException or ArithmeticException)
        {
            Console.Error.WriteLine(error.Message);
            Environment.ExitCode = 1;
        }
    }

    private static double ReadResistance(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()
                ?? throw new EndOfStreamException("Ввод завершён до получения всех сопротивлений.");

            if (double.TryParse(input.Replace(',', '.'), NumberStyles.Float,
                    CultureInfo.InvariantCulture, out double value)
                && double.IsFinite(value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Ошибка: введите конечное положительное сопротивление.");
        }
    }

    private static double CalculateTotalResistance(double r1, double r2, double r3)
    {
        double totalResistance = r1 + r2 + r3;

        if (!double.IsFinite(totalResistance))
        {
            throw new ArithmeticException("Ошибка: слишком большие значения для вычисления сопротивления.");
        }

        return totalResistance;
    }

    private static void PrintResult(double totalResistance)
    {
        Console.WriteLine($"Общее сопротивление: {totalResistance.ToString("G17", CultureInfo.InvariantCulture)} Ом");
    }
}
