using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Domain;
using PetShop.Domain.Estruturas;

namespace PetShop.Infrastructure
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly PetShopDbContext _context;

        public AnimalRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public void Adicionar(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal), "O animal não pode ser nulo.");

            try
            {
                _context.Animais.Add(animal);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                throw new InvalidOperationException($"Erro ao adicionar o animal no banco de dados: {innerMessage}", ex);
            }
        }

        public void Atualizar(Animal animal)
        {
            if (animal == null)
                throw new ArgumentNullException(nameof(animal), "O animal não pode ser nulo.");

            var existingAnimal = _context.Animais.Find(animal.Id);
            if (existingAnimal == null)
                throw new KeyNotFoundException($"Animal com ID {animal.Id} não encontrado.");

            try
            {
                _context.Animais.Update(animal);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                throw new InvalidOperationException($"Erro ao atualizar o animal no banco de dados: {innerMessage}", ex);
            }
        }

        public Animal ObterPorId(int id)
        {
            var animal = _context.Animais.Find(id);
            if (animal == null)
                throw new KeyNotFoundException($"Animal com ID {id} não encontrado.");

            return animal;
        }

        public IEnumerable<Animal> ObterTodos()
        {
            return _context.Animais.AsNoTracking().ToList();
        }

        public void Remover(int id)
        {
            var animal = _context.Animais.Find(id);
            if (animal == null)
                throw new KeyNotFoundException($"Animal com ID {id} não encontrado.");

            try
            {
                _context.Animais.Remove(animal);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var innerMessage = ex.InnerException?.Message ?? ex.Message;
                throw new InvalidOperationException($"Erro ao remover o animal do banco de dados: {innerMessage}", ex);
            }
        }
    }
}
