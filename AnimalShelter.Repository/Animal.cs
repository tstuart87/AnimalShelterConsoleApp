using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Repository
{
    public enum DietType { Carnivore, Herbivore, Omnivore }

    //INHERITANCE
    //ANIMAL is our BASE CLASS.
    public class Animal
    {
        public string AnimalName { get; set; }
        public DietType TypeOfDiet { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }

        public Animal()
        {
            //EMPTY Constructor
        }

        //FULL Constructor
        public Animal(string animalName, DietType typeOfDiet, int age, string species)
        {
            AnimalName = animalName;
            TypeOfDiet = typeOfDiet;
            Age = age;
            Species = species;
        }

        //Need to add virtual to the method signature.
        public virtual void MakeNoise()
        {
            Console.WriteLine("grrr.");
        }
    }

    //Dog is a derived class from the base class of Animal
    public class Dog : Animal
    {
        public bool IsGoodWithKids { get; set; }

        public Dog(string animalName, DietType typeOfDiet, int age, bool isGoodWithKids)
        {
            AnimalName = animalName;
            TypeOfDiet = typeOfDiet;
            Age = age;
            IsGoodWithKids = isGoodWithKids;
            Species = "Dog";
        }

        //OVERRIDE METHOD in our derived class of Dog from our Base class of Animal.
        //Make sure to correct this and add override to the method signature.
        public override void MakeNoise()
        {
            Console.WriteLine("woof woof.");
        }
    }

    //Cat is also a derived class from the base class of Animal
    public class Cat : Animal
    {
        public bool IsGoodWithDogs { get; set; }

        public Cat(string animalName, DietType typeOfDiet, int age, bool isGoodWithDogs)
        {
            AnimalName = animalName;
            TypeOfDiet = typeOfDiet;
            Age = age;
            IsGoodWithDogs = isGoodWithDogs;
            Species = "Cat";
        }

        //OVERRIDE METHOD
        //Make sure to correct this and add override to the method signature.
        public override void MakeNoise()
        {
            Console.WriteLine("meow.");
        }
    }
}