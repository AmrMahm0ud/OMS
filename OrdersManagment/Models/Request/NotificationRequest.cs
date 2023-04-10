namespace OrdersManagment.Models.Request
{
    public class NotificationRequest
    {
        public string to { get; set; }
        public notification notification { get; set; }
        //public data data { get; set; }
    }
    public class notification
    {
        public string body { get; set; }
        public string title { get; set; }
        public string payload { get; set; }
    }
    public class data
    {
        public string propertyId { get; set; }
        public string viewId { get; set; }
        public string message { get; set; }
    }
}
