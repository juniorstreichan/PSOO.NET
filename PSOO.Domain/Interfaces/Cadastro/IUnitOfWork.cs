using System.ServiceModel.Channels;

namespace PSOO.Domain.Interfaces.Common
{
    public interface IUnitOfWork
    {
        ISession BeginTransaction();
        void Commit();
        void RollBack();
    }
}
