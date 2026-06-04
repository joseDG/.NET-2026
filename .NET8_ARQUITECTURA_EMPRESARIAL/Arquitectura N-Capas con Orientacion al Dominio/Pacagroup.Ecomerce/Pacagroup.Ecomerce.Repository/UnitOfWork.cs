

namespace Pacagroup.Ecomerce.Infra.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomersRepsitory Customers { get; }

        public UnitOfWork(ICustomersRepository customers)
        {
            Customers = customers;
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
