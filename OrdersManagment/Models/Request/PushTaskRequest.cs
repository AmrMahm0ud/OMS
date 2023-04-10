namespace OrdersManagment.Models.Request
{
    public class PushTaskRequest : BaseRequest
    {
        public TaskData data { get; set; }
    }
    public class TaskData
    {
        public int orderId { get; set; }
        public double orderAmount { get; set; }
        public double cod { get; set; }
        public int orderStatus { get; set; }
        public int assinedTo { get; set; }
    }
}
