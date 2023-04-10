using Microsoft.EntityFrameworkCore;
using OrdersManagment.DataAccess.DefualtRepository;
using OrdersManagment.DataAccess.DomainRepository.IRepository;
using OrdersManagment.Models.Request;
using OrdersManagment.Models.Tables;
using System.Threading.Tasks;

namespace OrdersManagment.DataAccess.DomainRepository.Repository
{
    public class AuthRepository : Repository<Users>, IAuthRepository
    {
        private readonly ApplicationDbContext db;
        public AuthRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
        public async Task<List<Users>> GetAllUsers(BaseRequest request)
        {
            var Users = GetAll(x => x.id == request.userId || request.userId == 0).Result.ToList();
            return Users;

        }

        public async Task<Users> LoginUser(LoginRequest request)
        {
            var User = await GetFirstOrDefault(x =>
            x.userName.ToLower() == request.data.userName.ToLower()
            && x.userPassword.ToLower() == request.data.Password.ToLower()
            );
            if (User != null)
            {
                if (request.Token != User.deviceToken)
                {
                    User.deviceToken = request.Token;
                    db.Entry(User).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            return User;
        }
    }
}
