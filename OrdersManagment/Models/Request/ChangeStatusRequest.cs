namespace OrdersManagment.Models.Request
{
    public class ChangeStatusRequest : BaseRequest
    {
        public TaskStatusData data { get; set; }
    }
    public class TaskStatusData
    {
        public int orderId { get; set; }
        public int orderStatus { get; set; }
    }
}
