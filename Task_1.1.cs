using System;

namespace Task_1_1
{
internal static class Program
  {
static void Main(string[] args) {
const double a = 2;
const double b = 1;
const double c = 3;
Console.Write("Введите x = ");
string input = Console.ReadLine();
double x = double.Parse(input);
double y = (a * Math.Abs(x * x * x) + 5.0 / 2.0 * b *
Math.Sqrt(x * x + 1)) /
(c + Math.Sin(x) * Math.Cos(x));
 Console.WriteLine($"x = {x}; y = {y}");
 }
 }
}
