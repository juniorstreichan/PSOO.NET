using Autofac;
using Autofac.Integration.Mvc;
using NHibernate;
using PSOO.Application.Interfaces.Cadastro;
using PSOO.Application.Services.Cadastro;
using PSOO.Domain.Interfaces.Cadastro;
using PSOO.Domain.Interfaces.Common;
using PSOO.Domain.Services.Cadastro;
using PSOO.Infra.Data.Context;
using PSOO.Infra.Data.Repository.Cadastro;
using System.Reflection;
using System.Web.Mvc;

namespace PSOO.UI.Web.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }

        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            #region Application

            #region Cadastro

            builder.RegisterType<ClienteAppService>().As<IClienteAppService>().InstancePerRequest();

            #endregion Cadastro

            #endregion Application

            #region Domain Services

            #region Cadastro

            builder.RegisterType<IClienteService>().As<IClienteService>().InstancePerRequest();

            #endregion Cadastro

            #endregion Domain Services

            #region Data

            #region Context

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<SessionFactory>().As<ISessionFactory>().InstancePerRequest();

            #endregion Context

            #region Repositories

            #region Cadastro

            builder.RegisterType<ClienteRepository>().As<IClienteRepository>().InstancePerRequest();

            #endregion Cadastro

            #endregion Repositories

            #endregion Data

            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}