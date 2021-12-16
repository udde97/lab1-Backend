using lab1.DTO;
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

            },
            new Animal
            {
                Id = 1,
                Name = "koala",
                Type = "däggdjur",

            },

            new Animal
            {
                Id = 3,
                Name = "giraff",
                Type = "däggdjur",

            },

            new Animal
            {
                Id = 4,
                Name = "krokodil",
                Type = "reptil",

            },
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
            animal.Id = _animals.Max(a => a.Id) + 1;
            _animals.Add(animal);

            return animal;
        }

        public Animal UpdateAnimal(int id, AnimalDTO animalDTO )
        {
            Animal updatedAnimal = new()
            {
                Type = animalDTO.Type,
                Id = id,
                Name = animalDTO.Name

            };

            int index = _animals.FindIndex(a => a.Id == id);
            _animals[index] = updatedAnimal;

            return updatedAnimal;
        }

        public void DeleteAnimal(int id)
        {
            int index = _animals.FindIndex(xanimal => xanimal.Id == id);
            _animals.RemoveAt(index);
        }

    }

}