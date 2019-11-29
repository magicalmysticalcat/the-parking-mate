using System;
using System.Collections;
using System.Collections.Generic;

namespace TheParkingMate.DAL.Repositories
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        TEntity Read(Guid id);
        IEnumerable<TEntity> ReadAll();
        void Update(TEntity entity);
        void Delete(Guid id);
    }
}