

namespace Pacagroup.Ecomerce.Apli.Interface
{
    public interface ICustomersApplication
    {
        Task<Response<bool>> InsertAsync(Customer customer);
        Task<Response<bool>> UpdateAsync(Customer customer);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<Customer>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomerDto>>> GetAllAsync();
    }
}
