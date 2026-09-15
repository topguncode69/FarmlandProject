using System;

namespace FarmlandProject
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                var time = new Time();
                var crop = new Crop(time);
                var money = new Money();
                var farm = new Farm(crop, money, time);
                

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("===MY FARM===");
                    Console.WriteLine();
                    Console.WriteLine("1. Plant crop");
                    Console.WriteLine("2. Harvest crop");
                    Console.WriteLine("3. Buy animal");
                    Console.WriteLine("4. Sell");
                    Console.WriteLine("5. Show status");
                    Console.WriteLine("6. Exit");
                    Console.WriteLine("7. Sleep");
                    Console.WriteLine();
                    Console.Write("Enter choice (1-6): ");

                    string input = Console.ReadLine() ?? string.Empty;
                    if (!int.TryParse(input, out int userInput))
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 7.");
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
                            money.SellAnimal();
                            break;
                        case 5:
                            farm.ShowStatus();
                            break;
                        case 6:
                            Console.WriteLine("Exiting program. Goodbye!");
                            exit = true;
                            break;
                        case 7:
                            time.Tick();
                            Console.WriteLine("Good night, sweet dreams..");
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
    public class Time // also sleep
    { 
        private int _day = 0;
        public int Day => _day;
        public void Tick()
        {
            _day += 1;
        }
    }
    public class Farm // the farm class with the showstatus
    {
        private readonly Crop _crop;
        private readonly Money _animal;
        private readonly Money _totalGold;
        private readonly Time _time1;
        public Farm(Crop crop, Money money, Time time2)
        {
            _crop = crop ?? throw new ArgumentNullException(nameof(crop));
            _animal = money ?? throw new ArgumentNullException(nameof(money));
            _totalGold = money ?? throw new ArgumentNullException(nameof(money));
            _time1 = time2 ?? throw new ArgumentNullException(nameof(time2));
        }

        public void ShowStatus()
        {
            Console.WriteLine("Showing farm status...");
            Console.WriteLine($"Planted = {_crop.Planted}");
            Console.WriteLine($"Harvested = {_crop.Harvested}");
            Console.WriteLine($"Animals = {_animal.Animals}");
            Console.WriteLine($"Money = {_totalGold.TotalGold} Gold");
            Console.WriteLine($"Day = {_time1.Day}");

        }
    }

    public class Crop // crop class with plant and harvest
    {
        private int _planted = 0;
        private int _harvested = 0;
        private bool _grown = false;


        public int _dayPlanted;
        public int Planted => _planted;
        public int Harvested => _harvested;
        public bool Grown => _grown;
        
        
        
        private readonly Time _time;
        public Crop(Time time)
        {
            _time = time ?? throw new ArgumentNullException(nameof(time));
        }  // TIME SYSTEM

        public void Plant()
        {
            _planted++;
            Console.WriteLine("You have planted a crop.");
            _dayPlanted = _time.Day; // assigning to a global day so the game remembers
            _grown = false;

        }

        public void Harvest()
        {
            if (_planted < 1) 
            {
                Console.WriteLine("You have no planted crops to harvest.");
                return;
            }
            if (_time.Day <= _dayPlanted + 3)
            {
                Console.WriteLine("The plant has not grown yet.");
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
                _totalGold+= 150;
                    _animals--;
                Console.WriteLine("An animal has been sold");
            } else
            {
                Console.WriteLine("You have no Animals to sell.");
            }
        }

        
    }
}

//nova test commit poruka