using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace PetShop.Domain.Estruturas
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> ObterTodos();
        Animal ObterPorId(int id);
        void Adicionar(Animal animal);
        void Atualizar(Animal animal);
        void Remover(int id);
    }
}