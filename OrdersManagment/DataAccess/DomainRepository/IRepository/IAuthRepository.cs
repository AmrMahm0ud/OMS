using OrdersManagment.DataAccess.DefualtRepository;
using OrdersManagment.Models.Request;
using OrdersManagment.Models.Tables;

namespace OrdersManagment.DataAccess.DomainRepository.IRepository
{
    public interface IAuthRepository : IRepository<Users>
    {
        Task<List<Users>> GetAllUsers(BaseRequest request);
        Task<Users> LoginUser(LoginRequest request);
    }
}
