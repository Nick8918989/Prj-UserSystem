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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyAPIController : ControllerBase
    {
        private readonly PortfolioContext _context;
        private readonly UserMange _User_Mange;
        private readonly ILogger<MyAPIController> _logger;

        public MyAPIController(ILogger<MyAPIController> logger, PortfolioContext context, UserMange user_manager)
        {
            _logger = logger;
            _context = context;
            _User_Mange = user_manager;
        }

        [HttpGet("[action]/{_userPK}")]
        public async Task<IActionResult> QryAsyncUserBasic(int _userPK)
        {
            var data = await _User_Mange.QryUserBasicAsyncByPK(_userPK);
            return Content(data.ToJson(), "application/json");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> QryAsyncUserBasicList([FromQuery] int _userPK)
        {
            var data = await _User_Mange.QryUserBasicListAsync();
            return Content(data.ToJson(), "application/json");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> InsertUserBasic([FromBody] UserBasic _userBasic)
        {
            ReturnResult returnData = new ReturnResult();
            returnData = await _User_Mange.InsertUserBasicAsync(_userBasic);
            return Content(returnData.ToJson(), "application/json");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateUserBasic([FromBody] UserBasic _updateUser)
        {
            ReturnResult returnData = new ReturnResult();
            returnData = await _User_Mange.UpdateUserBasicAsync(_updateUser);
            return Content(returnData.ToJson(), "application/json");
        }

        [HttpDelete("[action]/{_deleteUserID}")]
        public async Task<IActionResult> DeleteUserBasic(int _deleteUserID, [FromBody] bool _isEntity)
        {
            ReturnResult returnData = new ReturnResult();
            returnData = await _User_Mange.DeleteUserBasicAsync(_deleteUserID, _isEntity: _isEntity);
            return Content(returnData.ToJson(), "application/json");
        }
    }
}