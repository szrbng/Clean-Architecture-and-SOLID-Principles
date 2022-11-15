using HR.LeaveManagement.MVC.Models.ApiModel.ResponseModel;
using HR.LeaveManagement.MVC.Operations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HR.LeaveManagement.MVC.Services.Base
{
    public class BaseClient: BaseClientOperations
    {
        public BaseClient(HttpClient client, JsonSerializer serializer, ILogger<BaseClient> logger) : base(client, serializer, logger)
        {

        }
        public async Task<List<LeaveTypesResponseModel>> GetAllLeaveType()
        {
            return await base.Get<List<LeaveTypesResponseModel>>($"/api/LeaveType","");
        }
    }
}
