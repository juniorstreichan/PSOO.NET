using NHibernate;
using PSOO.Domain.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PSOO.Infra.Data.Repository.Common
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected ISession Session;

        protected RepositoryBase()
        {
        }

        public void SetSession(ISession session)
        {
            Session = session;
        }

        public virtual void Add(TEntity entity)
        {
            Session.Save(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            Session.Delete(entity);
        }

        public virtual void Remove(Expression<Func<TEntity, bool>> where)
        {
            var objects = Session.QueryOver<TEntity>().Where(where).List();
            foreach (TEntity obj in objects)
                Remove(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return Session.Get<TEntity>(id);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return Session.QueryOver<TEntity>().Where(where).Take(1).SingleOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Session.QueryOver<TEntity>().List();
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return Session.QueryOver<TEntity>().Where(where).List();
        }
    }
}
