using System;

namespace FarmlandProject
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                var crop = new Crop();
                var money = new Money();
                var farm = new Farm(crop, money);

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("===MY FARM===");
                    Console.WriteLine();
                    Console.WriteLine("1. Plant crop");
                    Console.WriteLine("2. Harvest crop");
                    Console.WriteLine("3. Buy animal");
                    Console.WriteLine("4. Show farm");
                    Console.WriteLine("5. Sell");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine();
                    Console.Write("Enter choice (1-6): ");

                    string input = Console.ReadLine() ?? string.Empty;
                    if (!int.TryParse(input, out int userInput))
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                        Console.WriteLine();
                        continue;
                    }

                    switch (userInput)
                    {
                        case 1:
                            crop.Plant();
                            break;
                        case 2:
                            crop.Harvest();
                            break;
                        case 3:
                            money.BuyAnimal();
                            break;
                        case 4:
                            farm.ShowStatus();
                            break;
                        case 5:
                            money.SellAnimal();
                            break;
                        case 6:
                            Console.WriteLine("Exiting program. Goodbye!");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a number between 1 and 6.");
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

    public class Farm // the farm class with the showstatus
    {
        private readonly Crop _crop;
        private readonly Money _animal;
        private readonly Money _totalGold;

        public Farm(Crop crop, Money money)
        {
            _crop = crop ?? throw new ArgumentNullException(nameof(crop));
            _animal = money ?? throw new ArgumentNullException(nameof(money));
            _totalGold = money ?? throw new ArgumentNullException(nameof(money));
        }

        public void ShowStatus()
        {
            Console.WriteLine("Showing farm status...");
            Console.WriteLine($"Planted = {_crop.Planted}");
            Console.WriteLine($"Harvested = {_crop.Harvested}");
            Console.WriteLine($"Animals = {_animal.Animals}");
            Console.WriteLine($"Money = {_totalGold.TotalGold} Gold");

        }
    }

    public class Crop // crop class with plant and harvest
    {
        private int _planted = 0;
        private int _harvested = 0;

        public int Planted => _planted;
        public int Harvested => _harvested;

        public void Plant()
        {
            _planted++;
            Console.WriteLine("You have planted a crop.");
        }

        public void Harvest()
        {
            if (_planted < 1)
            {
                Console.WriteLine("You have no planted crops to harvest.");
                return;
            }

            _planted--;
            _harvested++;
            Console.WriteLine("You have harvested a crop.");
        }
    }

    public class Money 
    {
        private int _animals = 0;
        public int Animals => _animals;

        public void BuyAnimal()
        {
            _animals++;
            Console.WriteLine("An animal has been bought.");
        }
        private int _totalGold = 0;

        public int TotalGold => _totalGold;

        public void SellAnimal()
        {
            if (_animals > 0)
            {
                _totalGold++;
                    _animals--;
                Console.WriteLine("An animal has been sold");
            } else
            {
                Console.WriteLine("You have no Animals to sell.");
            }
        }

        
    }
}