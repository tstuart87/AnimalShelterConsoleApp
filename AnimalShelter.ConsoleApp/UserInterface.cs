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

        //Run() method.
        public void Run()
        {
            _repo.SeedData();

            while (isRunning)
            {
                PrintMainMenu();
                string input = GetUserInput();

                UserInputSwitchCase(input);
            }
        }

        //PrintMainMenu() method
        //1. Add a dog.
        //2. View all dogs.
        //3. Exit
        private void PrintMainMenu()
        {
            Console.WriteLine("1. Add a DOG.\n" +
                    "2. View all DOGS.\n" +
                    "3. EXIT.");
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
                    //AddDog();
                    break;
                case "2":
                    //ViewAllDogs();
                    break;
                case "3":
                    //ExitApplication();
                    break;
                default:

                    break;
            }
        }

        //CreateADog() method

        //ViewAllDogs() method

        //Exit() method
    }

    public class CustomConsole
    {

    }
}