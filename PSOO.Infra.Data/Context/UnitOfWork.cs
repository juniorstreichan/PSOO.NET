using NHibernate;
using PSOO.Domain.Interfaces.Common;

namespace PSOO.Infra.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private ITransaction _transaction = null;
        private readonly ISessionFactory _sessionFactory = null;
        private ISession _session = null;

        public UnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public ISession Session => _session ?? (_session = _sessionFactory.OpenSession());

        public ISession BeginTransaction()
        {
            var session = Session;
            _transaction = session.Transaction;
            if (!_transaction.IsActive)
                _transaction.Begin();
            return session;
        }

        public void Commit()
        {
            if (_transaction.IsActive)
                _transaction.Commit();
        }

        public void RollBack()
        {
            if (_transaction.IsActive)
                _transaction.Rollback();
        }

        System.ServiceModel.Channels.ISession IUnitOfWork.BeginTransaction()
        {
            throw new System.NotImplementedException();
        }
    }
}
