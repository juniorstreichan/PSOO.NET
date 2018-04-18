using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.Domain.Interfaces.Common
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void SetSession(ISession _session);
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Remove(Expression<Func<TEntity, bool>> where);
        TEntity GetById(int id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
    }
}

