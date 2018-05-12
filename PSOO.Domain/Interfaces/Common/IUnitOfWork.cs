using System.ServiceModel.Channels;
using NHibernate;

namespace PSOO.Domain.Interfaces.Common
{
    public interface IUnitOfWork
    {
        NHibernate.ISession Begin();
        void Commit();
        void RollBack();
        System.ServiceModel.Channels.ISession BeginTransaction();
    }
}
