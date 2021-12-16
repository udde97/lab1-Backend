using lab1.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1.Repository
{
    public class AnimalRep : IAnimalRep
    {
        private List<Animal> _animals = new()
        {
            new Animal
            {
                Id = 0,
                Name = "fågel",
                Type = "reptil",

            }
        };

        public AnimalRep() { }

        public List<Animal> GetAll()
        {
            return _animals;
        }

        public Animal GetByID(int id)
        {
            IEnumerable<Animal> animal = _animals.Where(item => item.Id == id);

            return animal.SingleOrDefault();
        }

        public Animal CreateAnimal(Animal animal)
        {
            _animals.Add(animal);

            return animal;
        }

        public Animal UpdateAnimal(Animal animal)
        {
            int index = _animals.FindIndex(item => item.Id == animal.Id);

            _animals[index] = animal;

            return animal;
        }

        public void DeleteAnimal(int id)
        {
            int index = _animals.FindIndex(xanimal => xanimal.Id == id);
            _animals.RemoveAt(index);
        }

    }

}