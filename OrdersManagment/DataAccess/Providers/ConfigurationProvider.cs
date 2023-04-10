using OrdersManagment.DataAccess.DomainRepository.IRepository;
using OrdersManagment.DataAccess.DomainRepository.Repository;
using System.Reflection;

namespace OrdersManagment.DataAccess.Providers
{
    public class ConfigurationProvider : IConfigurationProvider
    {

        private readonly ApplicationDbContext db;

        public ConfigurationProvider(ApplicationDbContext db)
        {
            this.db = db;
            Auth = new AuthRepository(db);
            Tasks = new TasksRepository(db);
        }
        public IAuthRepository Auth { get; private set; }
        public ITasksRepository Tasks { get; private set; }
    }
}
