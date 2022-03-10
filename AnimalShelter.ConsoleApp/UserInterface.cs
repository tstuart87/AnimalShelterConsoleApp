using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelter.Repository;

namespace AnimalShelter.ConsoleApp
{
    public class UserInterface
    {
        //bool that the entire UserInterface can see - think of scope.
        bool isRunning = true;
        AnimalRepository _repo = new AnimalRepository();
        CustomConsole _console = new CustomConsole();

        //Run() method.
        public void Run()
        {
            _repo.SeedData();

            while (isRunning)
            {
                _console.PrintMainMenu();
                _console.EnterSelection();
                string input = GetUserInput();

                UserInputSwitchCase(input);
            }
        }

        private string GetUserInput()
        {
            return Console.ReadLine();
        }

        //SwitchCase() method
        private void UserInputSwitchCase(string input)
        {
            switch (input)
            {
                case "1":
                    CreateADog();
                    break;
                case "2":
                    ViewAllDogs();
                    break;
                case "3":
                    ExitApplication();
                    break;
                default:

                    break;
            }
        }

        //CreateADog() method
        public void CreateADog()
        {
            _console.EnterAName();
            string dogName = GetUserInput();

            _console.PrintDietTypes();
            _console.EnterSelection();
            string dietTypeInput = GetUserInput();
            DietType dietType = DietType.Carnivore;

            switch (dietTypeInput)
            {
                case "1":
                    dietType = DietType.Carnivore;
                    break;
                case "2":
                    dietType = DietType.Herbivore;
                    break;
                case "3":
                    dietType = DietType.Omnivore;
                    break;
                default:
                    break;

            }

            _console.EnterAge();
            int age = Convert.ToInt32(GetUserInput());

            _console.IsDogGoodWithKids();
            string goodWithKidsInput = GetUserInput();

            bool isGoodWithKids = false;

            switch (goodWithKidsInput.ToUpper())
            {
                case "YES":
                case "YEA":
                case "YEAH":
                case "YEP":
                case "Y":
                    isGoodWithKids = true;
                    break;
                case "NO":
                case "NAY":
                case "NAH":
                case "YOPE":
                case "N":
                    isGoodWithKids = false;
                    break;
                default:
                    break;
            }

            Dog newDog = new Dog(dogName, dietType, age, isGoodWithKids);

            _repo.AddDogToList(newDog);

            _console.PressAnyKeyToContinue();
        }

        //ViewAllDogs() method
        public void ViewAllDogs()
        {
            List<Dog> dogList = _repo.GetAllDogs();

            foreach (Dog dog in dogList)
            {
                _console.PrintDog(dog);
            }

            _console.PressAnyKeyToContinue();
        }

        //Exit() method
        private void ExitApplication()
        {
            isRunning = false;
            _console.ExitApplicationMessage();
        }
    }


    //NEW CLASS OF CustomConsole BELOW - STILL IN THE SAME NAMESPACE AS OUR CLASS OF UserInterface.

    public class CustomConsole
    {
        public void PrintMainMenu()
        {
            Console.WriteLine("1. Add a DOG.\n" +
                    "2. View all DOGS.\n" +
                    "3. EXIT.");
        }

        public void PrintDog(Dog dog)
        {
            string goodWithKids = $"{dog.AnimalName} is better suited in a home with no small children";

            if (dog.IsGoodWithKids)
            {
                goodWithKids = $"{dog.AnimalName} will be happiest in a home with children.";
            }

            Console.WriteLine($"{dog.AnimalName.ToUpper()} | Age: {dog.Age}\n" +
                        $"{goodWithKids}\n");
        }

        public void EnterSelection()
        {
            Console.Write("Enter Selection: ");
        }

        public void EnterAName()
        {
            Console.Write("Name: ");
        }

        public void PrintDietTypes()
        {
            Console.WriteLine("Diet Type:\n" +
                    "1. Carnivore\n" +
                    "2. Herbivore\n" +
                    "3. Omnivore");
        }

        public void EnterAge()
        {
            Console.Write("Enter Age: ");
        }

        public void IsDogGoodWithKids()
        {
            Console.Write("Is this dog good with kids? (Y/N): ");
        }

        public void PressAnyKeyToContinue()
        {
            Console.Write("\nPress any key to continue....");
            Console.ReadKey();
        }

        public void ExitApplicationMessage()
        {
            Console.Write("Press any key to EXIT.");

            Console.ReadKey();
        }
    }
}