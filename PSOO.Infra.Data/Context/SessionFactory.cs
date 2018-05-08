using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Metadata;
using NHibernate.Stat;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Engine;
using System.Data.Common;
using System.Threading;

namespace PSOO.Infra.Data.Context
{
    public class SessionFactory : ISessionFactory
    {
        private static ISessionFactory _sessionFactory = null;

        public ICollection<string> DefinedFilterNames
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsClosed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IStatistics Statistics
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Evict(Type persistentClass)
        {
            throw new NotImplementedException();
        }

        public void Evict(Type persistentClass, object id)
        {
            throw new NotImplementedException();
        }

        public void EvictCollection(string roleName)
        {
            throw new NotImplementedException();
        }

        public void EvictCollection(string roleName, object id)
        {
            throw new NotImplementedException();
        }

        public void EvictEntity(string entityName)
        {
            throw new NotImplementedException();
        }

        public void EvictEntity(string entityName, object id)
        {
            throw new NotImplementedException();
        }

        public void EvictQueries()
        {
            throw new NotImplementedException();
        }

        public void EvictQueries(string cacheRegion)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, IClassMetadata> GetAllClassMetadata()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, ICollectionMetadata> GetAllCollectionMetadata()
        {
            throw new NotImplementedException();
        }

        public IClassMetadata GetClassMetadata(string entityName)
        {
            throw new NotImplementedException();
        }

        public IClassMetadata GetClassMetadata(Type persistentClass)
        {
            throw new NotImplementedException();
        }

        public ICollectionMetadata GetCollectionMetadata(string roleName)
        {
            throw new NotImplementedException();
        }

        public ISession GetCurrentSession()
        {
            throw new NotImplementedException();
        }

        public FluentNHibernate.Mapping.FilterDefinition GetFilterDefinition(string filterName)
        {
            throw new NotImplementedException();
        }

        public ISession OpenSession()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NHibernate.connectionString"].ToString();

            if (_sessionFactory == null)
            {
                IPersistenceConfigurer configuracaoDb = MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql();
                var configMap = Fluently.Configure()
                    .Database(configuracaoDb)
                    .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Config.Cadastro.ClienteMap>());
                _sessionFactory = configMap.BuildSessionFactory();
            }

            return _sessionFactory.OpenSession();
        }

        public ISession OpenSession(IInterceptor sessionLocalInterceptor)
        {
            throw new NotImplementedException();
        }

        public ISession OpenSession(IDbConnection conn)
        {
            throw new NotImplementedException();
        }

        public ISession OpenSession(IDbConnection conn, IInterceptor sessionLocalInterceptor)
        {
            throw new NotImplementedException();
        }

        public IStatelessSession OpenStatelessSession()
        {
            throw new NotImplementedException();
        }

        public IStatelessSession OpenStatelessSession(IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~SessionFactory() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        public Task CloseAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task EvictAsync(Type persistentClass, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task EvictAsync(Type persistentClass, object id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task EvictEntityAsync(string entityName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task EvictEntityAsync(string entityName, object id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task EvictCollectionAsync(string roleName, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task EvictCollectionAsync(string roleName, object id, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task EvictQueriesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task EvictQueriesAsync(string cacheRegion, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public ISessionBuilder WithOptions()
        {
            throw new NotImplementedException();
        }

        public ISession OpenSession(DbConnection connection)
        {
            throw new NotImplementedException();
        }

        public ISession OpenSession(DbConnection conn, IInterceptor sessionLocalInterceptor)
        {
            throw new NotImplementedException();
        }

        public IStatelessSessionBuilder WithStatelessOptions()
        {
            throw new NotImplementedException();
        }

        public IStatelessSession OpenStatelessSession(DbConnection connection)
        {
            throw new NotImplementedException();
        }

        NHibernate.Engine.FilterDefinition ISessionFactory.GetFilterDefinition(string filterName)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
