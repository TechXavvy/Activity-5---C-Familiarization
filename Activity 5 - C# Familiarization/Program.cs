using Activity_5___C__Familiarization.Calculators;

namespace Activity_5___C__Familiarization
{
    internal class Program
    {
        static List<string> calcHistory = new List<string>();
        static void History()
        {
            Console.Clear();
            Console.WriteLine("Piolo PasCal The Calculator's History:\n");
            if (calcHistory.Count == 0)
            {
                Console.WriteLine("No calculations performed.");
            }
            else
            {
                foreach (var record in calcHistory)
                {
                    Console.WriteLine(record);
                }
            }
            Console.WriteLine("\nPress any key to return to the homepage.");
            Console.ReadKey();
        }

        static string calcOperation(string choice)
        {
            string operation;
            switch (choice)
            {
                case "1":
                    operation = "+";
                    break;
                case "2":
                    operation = "-";
                    break;
                case "3":
                    operation = "*";
                    break;
                case "4":
                    operation = "/";
                    break;
                case "5":
                    operation = "%";
                    break;
                case "6":
                    operation = "^";
                    break;
                default:
                    operation = "?";
                    break;
            }
            return operation;
        }

        static Calculator createCalculator(string choice, double temp1, double temp2)
        {
            Calculator calc;
            switch (choice)
            {
                case "1":
                    calc = new Addition();
                    break;
                case "2":
                    calc = new Subtraction();
                    break;
                case "3":
                    calc = new Multiplication();
                    break;
                case "4":
                    if (temp2 == 0)
                    {
                        Console.WriteLine("\nDivision by zero leads to math error!");
                        Console.WriteLine("\nPress any key to return to the homepage.");
                        Console.ReadKey();
                        return null;
                    }
                    calc = new Division();
                    break;
                case "5":
                    if (temp2 == 0)
                    {
                        Console.WriteLine("\nDivision by zero leads to math error!");
                        Console.WriteLine("\nPress any key to return to the homepage.");
                        Console.ReadKey();
                        return null;
                    }
                    calc = new Modulus();
                    break;
                case "6":
                    calc = new Power();
                    break;
                default:
                    calc = null;
                    break;
            }

            if (calc != null)
            {
                calc.N1 = temp1;
                calc.N2 = temp2;
            }

            return calc;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to Piolo PasCal The Calculator! This is the homepage.");
                    Console.WriteLine("\nWhat operation would you like to do?");
                    Console.WriteLine("1. Addition");
                    Console.WriteLine("2. Subtraction");
                    Console.WriteLine("3. Multiplication");
                    Console.WriteLine("4. Division");
                    Console.WriteLine("5. Modulus");
                    Console.WriteLine("6. Power");
                    Console.WriteLine("7. History");
                    Console.WriteLine("8. Exit");
                    Console.Write("\nChoose from 1-8: ");
                    string choice = Console.ReadLine();

                    if (!int.TryParse(choice, out int userChoice) || userChoice <= 0 || userChoice > 8)
                    {
                        Console.WriteLine("\nInvalid number! Press any key to return to the homepage.");
                        Console.ReadKey();
                        continue;
                    }

                    if (choice == "8")
                    {
                        Console.WriteLine("\nThank you for using Piolo PasCal The Calculator! Exiting program now.");
                        break;
                    }

                    if (choice == "7")
                    {
                        History();
                        continue;
                    }

                    Calculator calc = null;

                    Console.Write("\nEnter your first number: ");
                    if (!double.TryParse(Console.ReadLine(), out double temp1))
                    {
                        Console.WriteLine("\nInvalid number! Press any key to return to the homepage.");
                        Console.ReadKey();
                        continue;
                    }

                    Console.Write("Enter your second number: ");
                    if (!double.TryParse(Console.ReadLine(), out double temp2))
                    {
                        Console.WriteLine("\nInvalid number! Press any key to return to the homepage.");
                        Console.ReadKey();
                        continue;
                    }

                    calc = createCalculator(choice, temp1, temp2);

                    if (calc == null)
                    {
                        Console.WriteLine("That is an invalid operation choice!");
                        continue;
                    }

                    calc.DisplayOperation();
                    calcHistory.Add($"{temp1} {calcOperation(choice)} {temp2} = {calc.Calculate()}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter numeric values only.");
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("\nPress any key to return to the homepage.");
                Console.ReadKey();
            }
        }
    }
}
