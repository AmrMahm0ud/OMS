using System.Net;

namespace OrdersManagment.Models.Response
{
    public class BaseResponse
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public object data { get; set; }
        protected BaseResponse(HttpStatusCode statusCode, object result = null, string responseMsg = null)
        {
            this.resultCode = ((int)statusCode) == 200 ? 1 : 0;
            this.data = result != null ? result : new string[] { };
            this.resultMessage = responseMsg;
        }
        public static BaseResponse Create(HttpStatusCode statusCode, object result = null, string responseMsg = null)
        {
            return new BaseResponse(statusCode, result, responseMsg);
        }

    }
}
