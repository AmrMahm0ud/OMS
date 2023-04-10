using OrdersManagment.DataAccess.DefualtRepository;
using OrdersManagment.Models.Request;
using OrdersManagment.Models.Tables;

namespace OrdersManagment.DataAccess.DomainRepository.IRepository
{
    public interface ITasksRepository : IRepository<Tasks>
    {
        Task<List<Tasks>> GetTasks(BaseRequest request);
        Task<List<Status>> GetStatus();
        bool ChangeTaskStatus(ChangeStatusRequest request);
        Task<int> AddTask(PushTaskRequest request);
    }
}
