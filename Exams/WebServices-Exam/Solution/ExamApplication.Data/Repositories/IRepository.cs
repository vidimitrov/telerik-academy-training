namespace BullsAndCows.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        void Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        T Delete(object id);

        T Find(object id);

        int SaveChanges();
    }
}
