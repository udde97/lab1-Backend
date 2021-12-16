using lab1.DTO;
using lab1.Entity;
using System.Collections.Generic;

namespace lab1.Repository
{
    public interface IAnimalRep
    {
        List<Animal> GetAll();
        Animal GetByID(int id);
        Animal CreateAnimal(Animal animal);
        Animal UpdateAnimal(int id , AnimalDTO animalDTO);
        void DeleteAnimal(int id);
    }
}