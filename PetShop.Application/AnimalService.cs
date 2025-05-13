using PetShop.Domain;
using PetShop.Domain.Estruturas;
using System.Collections.Generic;

namespace PetShop.Application
{
    public class AnimalService
    {
        private readonly IAnimalRepository _repository;

        public AnimalService(IAnimalRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Animal> ObterTodos() => _repository.ObterTodos();
        public Animal ObterPorId(int id) => _repository.ObterPorId(id);
        public void Adicionar(Animal animal) => _repository.Adicionar(animal);
        public void Atualizar(Animal animal) => _repository.Atualizar(animal);
        public void Remover(int id) => _repository.Remover(id);
    }
}
