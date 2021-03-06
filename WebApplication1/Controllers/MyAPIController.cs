using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Manage;
using WebApplication1.Models;
using WebApplication1.Models.Entity;
using WebApplication1.Utilities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyAPIController : ControllerBase
    {
        private readonly PortfolioContext _context;
        private readonly UserMange _User_Mange;
        private readonly ILogger<string> _logger;

        public MyAPIController(ILogger<string> logger, PortfolioContext context, UserMange user_manager)
        {
            _logger = logger; 
            _context = context;
            _User_Mange = user_manager;
            //_logger.LogDebug("1.Nog...in controller");
        }

        [HttpGet("[action]/{_userPK}")]
        public async Task<IActionResult> QryAsyncUserBasic(long _userPK)
        {
            var data = await _User_Mange.QryAsyncByPK(_userPK);
            return Content(data.ToJson(), "application/json");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> QryAsyncUserBasicList([FromQuery] long _userPK)
        {
            var data = await _User_Mange.QryListAsync();
            return Content(data.ToJson(), "application/json");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> InsertUserBasic([FromBody] UserBasic _userBasic)
        {
            string fnName = ViewUtility.GetFunctionName(ControllerContext), ip = NetUtility.GetServerIPAddress();
            ReturnResult returnData = new ReturnResult();
            returnData = await _User_Mange.InsertAsync(_userBasic);
            return Content(returnData.ToJson(), "application/json");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUserBasic([FromBody] UserBasic _updateUser)
        {
            string fnName = ViewUtility.GetFunctionName(ControllerContext), ip = NetUtility.GetServerIPAddress();
            ReturnResult returnData = new ReturnResult();
            returnData = await _User_Mange.UpdateAsync(_updateUser);
            return Content(returnData.ToJson(), "application/json");
        }

        [HttpDelete("[action]/{_userPK}")]
        public async Task<IActionResult> DeleteUserBasic(long _userPK, [FromBody] bool _isEntity)
        {
            string fnName = ViewUtility.GetFunctionName(ControllerContext), ip = NetUtility.GetServerIPAddress();
            ReturnResult returnData = new ReturnResult();
            returnData = await _User_Mange.DeleteAsync(_userPK, _isEntity: _isEntity);
            return Content(returnData.ToJson(), "application/json");
        }
    }
}