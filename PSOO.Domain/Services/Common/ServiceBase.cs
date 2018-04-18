using FluentValidation;
using NHibernate;
using PSOO.Domain.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PSOO.Domain.Services.Common
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        protected ISession _session;
        protected readonly IRepositoryBase<TEntity> _repository;
        protected readonly IValidator<TEntity> _validator;

        public ServiceBase(IRepositoryBase<TEntity> repository, IValidator<TEntity> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public void SetSession(ISession session)
        {
            _session = session;
            _repository.SetSession(_session);
        }

        public virtual bool Add(TEntity obj)
        {
            (obj as BaseClass).Validate(_validator);
            if ((obj as BaseClass).IsValid)
            {
                _repository.Add(obj);
                return true;
            }
            return false;
        }

        public virtual bool Update(TEntity obj)
        {
            (obj as BaseClass).Validate(_validator);
            if ((obj as BaseClass).IsValid)
            {
                _repository.Update(obj);
                return true;
            }
            return false;
        }

        public virtual bool Remove(TEntity obj)
        {
            try
            {
                _repository.Remove(obj);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual bool Remove(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                _repository.Remove(where);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return _repository.Get(where);
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return _repository.GetMany(where);
        }
    }
}

