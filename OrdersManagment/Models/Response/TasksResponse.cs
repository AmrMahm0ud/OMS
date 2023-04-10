
namespace OrdersManagment.Models.Response
{
    public class TasksResponse
    {
        public int orderId { get; set; }
        public double orderAmount { get; set; }
        public double COD { get; set; }
        public int? orderStatus { get; set; }
        public int? assinedTo { get; set; }
        public string statusName { get; set; }
        public string userName { get; set; }
    }
}
