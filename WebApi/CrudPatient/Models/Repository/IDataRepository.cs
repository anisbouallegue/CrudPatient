using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudPatient.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> getAll();
        TEntity getById(long id);
        void createPatient(TEntity entity);
        void updatePatient(TEntity dbEntity, TEntity entity);
        void delPatient(TEntity entity);
    }
}
