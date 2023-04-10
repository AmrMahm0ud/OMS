namespace OrdersManagment.Models.Request
{
    public class LoginRequest : BaseRequest
    {
        public LoginData data { get; set; }
    }
    public class LoginData
    {
        public string userName { get; set; }
        public string Password { get; set; }
    }
}
