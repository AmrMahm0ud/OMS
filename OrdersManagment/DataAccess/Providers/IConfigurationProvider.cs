using OrdersManagment.DataAccess.DomainRepository.IRepository;

namespace OrdersManagment.DataAccess.Providers
{
    public interface IConfigurationProvider
    {
        IAuthRepository Auth { get; }
        ITasksRepository Tasks { get; }
    }
}
