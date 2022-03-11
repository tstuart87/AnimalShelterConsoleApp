using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Repository
{
    public class AnimalRepository
    {
        //FAKE DATABASE TABLE(S)
        //THREE SEPARATE TABLES
        //STORES MY ANIMALS
        List<Animal> _animalList = new List<Animal>();
        //STORES MY DOGS
        List<Dog> _dogList = new List<Dog>();
        //STORES MY CATS
        List<Cat> _catList = new List<Cat>();

        //CRUD Methods

        //CREATE A DOG
        public void AddDogToList(Dog dog)
        {
            _dogList.Add(dog);
        }

        //READ - RETURN ALL THE DOGS
        public List<Dog> GetAllDogs()
        {
            return _dogList;
        }

        //READ METHOD that takes in inputs from the user, based off of whether or not they have children AND they want/don't want a puppy - and returns a list of dogs.
        public List<Dog> GetDogs(bool isPuppy, bool isGoodWithKids)
        {
            List<Dog> filteredDogList = new List<Dog>();

            foreach (Dog dog in _dogList)
            {
                if (dog.IsPuppy == isPuppy && dog.IsGoodWithKids == isGoodWithKids)
                {
                    filteredDogList.Add(dog);
                }
            }

            return filteredDogList;
        }

        //SEED DATA METHOD
        public void SeedData()
        {
            Dog airBud = new Dog("Air Bud", DietType.Carnivore, 6, true);
            Dog lassie = new Dog("Lassie", DietType.Carnivore, 3, true);
            Dog hank = new Dog("Hank", DietType.Carnivore, 9, false);
            Dog chance = new Dog("Chance", DietType.Carnivore, 1, true);
            Dog shadow = new Dog("Shadow", DietType.Carnivore, 11, true);

            Dog rosco = new Dog("Rosco", DietType.Carnivore, 1, true);
            Dog dyogi = new Dog("Dyogi", DietType.Carnivore, 2, true);
            Dog rocket = new Dog("Rocket", DietType.Carnivore, 2, true);
            Dog milo = new Dog("Milo", DietType.Carnivore, 4, true);
            Dog debo = new Dog("Debo", DietType.Carnivore, 11, false);

            Dog[] dogArr = { airBud, lassie, hank, chance, shadow, rocket, rosco, dyogi, milo, debo };

            foreach (Dog dog in dogArr)
            {
                AddDogToList(dog);
            }
        }
    }
}