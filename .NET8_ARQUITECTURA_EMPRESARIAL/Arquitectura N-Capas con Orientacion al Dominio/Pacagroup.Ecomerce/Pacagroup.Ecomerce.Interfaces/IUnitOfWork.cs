

using Pacagroup.Ecomerce.Interfaces;

namespace Pacagroup.Ecomerce.Infra.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomersRepository Customers { get; }
    }
}
