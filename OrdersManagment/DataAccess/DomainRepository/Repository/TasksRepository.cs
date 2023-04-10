using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OrdersManagment.DataAccess.DefualtRepository;
using OrdersManagment.DataAccess.DomainRepository.IRepository;
using OrdersManagment.Models.Request;
using OrdersManagment.Models.Tables;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManagment.DataAccess.DomainRepository.Repository
{
    public class TasksRepository : Repository<Tasks>, ITasksRepository
    {
        private readonly ApplicationDbContext db; 
        public TasksRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
        public async Task<List<Tasks>> GetTasks(BaseRequest request)
        {
            var Users = GetAll(filter: x => x.assinedTo == request.userId || request.userId == 0,includeProperties: "status,user").Result.ToList();
            return Users;
        }
        public async Task<List<Status>> GetStatus()
        {
            return db.Status.ToList();
        }
        public  bool ChangeTaskStatus(ChangeStatusRequest request)
        {
            try
            {
                var task = GetFirstOrDefault(filter: x => x.orderId == request.data.orderId, "status,user").Result;
                task.orderStatus = request.data.orderStatus;
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                var status = db.Status.Where(x => x.id == request.data.orderStatus).FirstOrDefault();
                var users = db.Users.Where(x => x.IsAdmin == true && x.id != task.assinedTo).ToList();
                foreach (var user in users) {
                    var Notify = new NotificationRequest();
                    var Msg = "user " + task.user.userName + " take Action: "+ status.name + " On task #" + task.orderId + " .. best regards";
                    Notify.to = user.deviceToken;
                    Notify.notification = new notification();
                    Notify.notification.payload = "payload";
                    Notify.notification.title = "Task Update Status";
                    Notify.notification.body = Msg;
                    var IsNotifiyed = PushNotification(Notify);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<int> AddTask(PushTaskRequest request)
        {
            var Task = new Tasks
            {
                orderId = request.data.orderId,
                orderAmount = request.data.orderAmount,
                COD = request.data.cod,
                orderStatus = request.data.orderStatus,
                assinedTo = request.data.assinedTo,
            };
            var Task_e = await db.Tasks.AddAsync(Task);
            try
            {
                await db.SaveChangesAsync();
                var status = db.Status.Where(x => x.id == request.data.orderStatus).FirstOrDefault();
                var users = db.Users.Where(x => x.id == request.data.assinedTo).ToList();
                foreach (var user in users)
                {
                    var Notify = new NotificationRequest();
                    var Msg = "there is new task #" + Task_e.Entity.orderId + " assined to you .. best regards";
                    Notify.to = user.deviceToken;
                    Notify.notification = new notification();
                    Notify.notification.payload = "payload";
                    Notify.notification.title = "Pushing Task";
                    Notify.notification.body = Msg;
                    var IsNotifiyed = PushNotification(Notify);
                }
                return Task_e.Entity.orderId;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> PushNotification(NotificationRequest request)
        {
            HttpClient client = new HttpClient();
            var result="";
            //client.BaseAddress = new Uri("https://fcm.googleapis.com/fcm/send");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=" + "AAAAuMNt_Ac:APA91bGNFuQhqW9TolncdsrgWqEUjL2hLCeQ6AK_YQGIWOx5oz9feXOD7X7gYTqgTMOmB8Ha3M3VSuBD-ydQC7O8Bt40Q6GA6YZsNU3dGdKdU_Q5YLG_wmzYgY62WjHSYdZ8YL4YxXHh");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage messge = client.PostAsync("https://fcm.googleapis.com/fcm/send", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json")).Result;
            if (messge.IsSuccessStatusCode)
            {
                result = await messge.Content.ReadAsStringAsync();

            }
            else
            {
                result = messge.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            }
            return 1;
        }
    }
}
