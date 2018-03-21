using Antlr.Runtime.Misc;
using System.Linq;

namespace PrismaWEB.Dao
{
    public interface IRepositorio<T> where T : class
    {
        void Adicionar(T item);

        void Deletar(T item);

        void Editar(T item);

        T BuscaPorId(object id);

        IQueryable<T> Tudo();
    }
}