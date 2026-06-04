using Pacagroup.Ecomerce.Domain.Entity;

namespace Pacagroup.Ecomerce.Domain.Interface
{
    public interface ICustomersDomain
    {
        Task<bool> InsertAsync(Customer customer);
        Task<bool> UpdateAsync(Customer customer);
        Task<bool> DeleteAsync(string customerId);
        Task<Customer> GetAsync(string customerId);
        Task<IEnumerable<Customer>> GetAllAsync();
    }
}
