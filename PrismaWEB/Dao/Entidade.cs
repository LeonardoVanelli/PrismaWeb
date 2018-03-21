using PrismaWEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrismaWEB.Dao
{
    public class Entidade<T> : IDisposable, IRepositorio<T> where T : class
    {
        PrismaDBEntities contexto = new PrismaDBEntities();
        public void Adicionar(T item)
        {
            contexto.Set<T>().Add(item);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

        public void Editar(T item)
        {
            contexto.Entry(item).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public T BuscaPorId(object id)
        {
            return contexto.Set<T>().Find(id);
        }

        public void Deletar(T item)
        {
            contexto.Set<T>().Remove(item);

            contexto.SaveChanges();
        }

        public IQueryable<T> Tudo()
        {
            return contexto.Set<T>();
        }
    }
}