using System;

public class Program
{
    static void Main()
    {
        try
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("===MY FARM===");
                Console.WriteLine();
                Console.WriteLine("1. Plant crop");
                Console.WriteLine("2. Harvest crop");
                Console.WriteLine("3. Buy animal");
                Console.WriteLine("4. Show farm");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.Write("Enter choice (1-5): ");

                string input = Console.ReadLine();
                if (!int.TryParse(input, out int userInput))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    Console.WriteLine();
                    continue;
                }

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("A crop has been planted.");
                        crop.planted++; // increment planted
                        break;
                    case 2 when crop.planted > 0:
                        Console.WriteLine("You have harvested the crop.");
                        crop.harvested++;
                        crop.planted--; // optional: reduce planted when harvested
                        break;
                    case 2:
                        // previously: "throw new Console.Write(...)" which caused CS0426
                        Console.WriteLine("You have no planted crops.");
                        break;
                    case 3:
                        Console.WriteLine("An animal has been bought.");
                        animal.count++;
                        break;
                    case 4:
                        Console.WriteLine("Showing farm status...");
                        Console.WriteLine($"Farm currently has: Planted={crop.planted}, Crops={crop.harvested}, Animals={animal.count}");
                        break;
                    case 5:
                        Console.WriteLine("Exiting program. Goodbye!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select a number between 1 and 5.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}

public class animal
{
    public static int count { get; set; } = 0;
}
public class crop
{
    public static int planted { get; set; } = 0;
    public static int harvested { get; set; } = 0;
}

