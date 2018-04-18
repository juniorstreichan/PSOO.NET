using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.Domain.Interfaces.Common
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void SetSession(ISession session);
        bool Add(TEntity obj);
        bool Update(TEntity obj);
        bool Remove(TEntity obj);
        bool Remove(Expression<Func<TEntity, bool>> where);
        TEntity GetById(int id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
    }

}
