using System.Globalization;
using System.Text;

namespace Task_1_3_V01;

internal static class Program
{
    private static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        try
        {
            Console.WriteLine("Задание 1.3, вариант 1. Кинетическая энергия пули.");
            double mass = ReadNumber("Введите массу пули в килограммах: ", false);
            double speed = ReadNumber("Введите скорость пули в метрах в секунду: ", true);
            double energy = CalculateKineticEnergy(mass, speed);
            PrintResult(energy);
        }
        catch (Exception error) when (error is EndOfStreamException or ArithmeticException)
        {
            Console.Error.WriteLine(error.Message);
            Environment.ExitCode = 1;
        }
    }

    private static double ReadNumber(string prompt, bool allowZero)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()
                ?? throw new EndOfStreamException("Ввод завершён до получения всех данных.");

            if (double.TryParse(input.Replace(',', '.'), NumberStyles.Float,
                    CultureInfo.InvariantCulture, out double value)
                && double.IsFinite(value) && (allowZero ? value >= 0 : value > 0))
            {
                return value;
            }

            Console.WriteLine(allowZero
                ? "Ошибка: введите конечное неотрицательное число."
                : "Ошибка: введите конечное положительное число.");
        }
    }

    private static double CalculateKineticEnergy(double mass, double speed)
    {
        double energy = mass * speed * speed / 2.0;

        if (!double.IsFinite(energy))
        {
            throw new ArithmeticException("Ошибка: слишком большие значения для вычисления энергии.");
        }

        return energy;
    }

    private static void PrintResult(double energy)
    {
        Console.WriteLine($"Кинетическая энергия: {energy.ToString("G17", CultureInfo.InvariantCulture)} Дж");
    }
}
