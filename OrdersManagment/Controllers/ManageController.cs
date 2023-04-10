using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersManagment.Models.Request;
using OrdersManagment.Models.Response;
using OrdersManagment.Models.Tables;
using System.Net;
using System.Xml;
using IConfigurationProvider = OrdersManagment.DataAccess.Providers.IConfigurationProvider;

namespace OrdersManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageController : ControllerBase
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IMapper _mapper;
        public ManageController(IMapper mapper, IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
            _mapper = mapper;
        }
        #region Users
        [HttpPost]
        [Route("Users/GetAll")]
        public async Task<BaseResponse> GetAllUsers(BaseRequest request)
        {
            BaseResponse Response = BaseResponse.Create(HttpStatusCode.OK, new { status = true }, null);
            try
            {
                var Users = await _configurationProvider.Auth.GetAllUsers(request);
                if (Users != null)
                    Response = BaseResponse.Create(HttpStatusCode.OK, _mapper.Map<List<UsersResponse>>(Users), "");
                else
                    Response = BaseResponse.Create(HttpStatusCode.InternalServerError, null, "");

                return Response;
            }
            catch (Exception ex)
            {
                Response = BaseResponse.Create(HttpStatusCode.InternalServerError, null, ex.Message.ToString());
                return Response;
            }
        }
        [HttpPost]
        [Route("Users/Login")]
        public async Task<BaseResponse> Login(LoginRequest request)
        {
            BaseResponse Response = BaseResponse.Create(HttpStatusCode.OK, new { status = true }, null);
            try
            {
                var Users = await _configurationProvider.Auth.LoginUser(request);
                if (Users != null)
                    Response = BaseResponse.Create(HttpStatusCode.OK, _mapper.Map<LoginResponse>(Users), "");
                else
                    Response = BaseResponse.Create(HttpStatusCode.InternalServerError, new LoginResponse(), "");

                return Response;
            }
            catch (Exception ex)
            {
                Response = BaseResponse.Create(HttpStatusCode.InternalServerError, null, ex.Message.ToString());
                return Response;
            }
        }
        #endregion

        #region Tasks
        [HttpPost]
        [Route("Tasks/GetStatus")]
        public async Task<BaseResponse> GetStatus(BaseRequest request)
        {
            BaseResponse Response = BaseResponse.Create(HttpStatusCode.OK, null, null);
            try
            {
                var Status = await _configurationProvider.Tasks.GetStatus();
                if (Status != null)
                    Response = BaseResponse.Create(HttpStatusCode.OK, Status, "");
                else
                    Response = BaseResponse.Create(HttpStatusCode.InternalServerError, null, "");

                return Response;
            }
            catch (Exception ex)
            {
                Response = BaseResponse.Create(HttpStatusCode.InternalServerError, null, ex.Message.ToString());
                return Response;
            }
        }
        [HttpPost]
        [Route("Tasks/GetTasks")]
        public async Task<BaseResponse> GetTasks(BaseRequest request)
        {
            BaseResponse Response = BaseResponse.Create(HttpStatusCode.OK, new { status = true }, null);
            try
            {
                var tasks = await _configurationProvider.Tasks.GetTasks(request);
                if (tasks != null)
                    Response = BaseResponse.Create(HttpStatusCode.OK, _mapper.Map<List<TasksResponse>>(tasks), "");
                else
                    Response = BaseResponse.Create(HttpStatusCode.InternalServerError, null, "");

                return Response;
            }
            catch (Exception ex)
            {
                Response = BaseResponse.Create(HttpStatusCode.InternalServerError, null, ex.Message.ToString());
                return Response;
            }
        }
        [HttpPost]
        [Route("Tasks/changeStatus")]
        public async Task<BaseResponse> changeStatus(ChangeStatusRequest request)
        {
            BaseResponse Response = BaseResponse.Create(HttpStatusCode.OK, new { status = true }, null);
            try
            {
                var IsChanged = _configurationProvider.Tasks.ChangeTaskStatus(request);
                if (IsChanged != null && IsChanged == true)
                    Response = BaseResponse.Create(HttpStatusCode.OK, null, "");
                else
                    Response = BaseResponse.Create(HttpStatusCode.InternalServerError, null, "");

                return Response;
            }
            catch (Exception ex)
            {
                Response = BaseResponse.Create(HttpStatusCode.InternalServerError, null, ex.Message.ToString());
                return Response;
            }
        }
        [HttpPost]
        [Route("Tasks/AddTask")]
        public async Task<BaseResponse> AddTask(PushTaskRequest request)
        {
            BaseResponse Response = BaseResponse.Create(HttpStatusCode.OK, new { status = true }, null);
            try
            {
                var IsSaved = _configurationProvider.Tasks.AddTask(request).Result;
                if (IsSaved != null && IsSaved > 0)
                    Response = BaseResponse.Create(HttpStatusCode.OK, null, "");
                else
                    Response = BaseResponse.Create(HttpStatusCode.InternalServerError, null, "");

                return Response;
            }
            catch (Exception ex)
            {
                Response = BaseResponse.Create(HttpStatusCode.InternalServerError, null, ex.Message.ToString());
                return Response;
            }
        }
        #endregion
    }
}
