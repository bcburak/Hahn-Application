using Hahn.ApplicatonProcess.July2021.Data.Interfaces;
using Hahn.ApplicatonProcess.July2021.Data.Models;
using Hahn.ApplicatonProcess.July2021.Domain.Constants;
using Hahn.ApplicatonProcess.July2021.Domain.Dto;
using Hahn.ApplicatonProcess.July2021.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IAssetService _assetService;

        public HomeController(
            ILogger<HomeController> logger,
            IUserService userService, IAssetService assetService)
        {
            _logger = logger;
            _userService = userService;
            _assetService = assetService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO user)
        {
            try
            {
                var userName = await _userService.CreateUser(user);
                return CreatedAtAction("User Created : ", new { user.FirstName }, user);
            }
            catch (Exception)
            {
                return new JsonResult("Something wrong") { StatusCode = 500 };
                throw;
            }        
           

        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(int Id)
        {
            try
            {
                var user = await _userService.GetUser(Id);
                return new JsonResult(user);
            }
            catch (Exception)
            {
                return new JsonResult("Something wrong") { StatusCode = 500 };
                throw;
            }

        }

        [HttpPut("EditUser")]
        public async Task<IActionResult> EditUser(int Id)
        {
            try
            {
                var user = await _userService.EditUser(Id);
                return new JsonResult(user);
            }
            catch (Exception)
            {
                return new JsonResult("Something wrong") { StatusCode = 500 };
                throw;
            }

        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int Id)
        {

            try
            {
                var user = await _userService.DeleteUser(Id);
                return new JsonResult(string.Concat(user,"named user deleted"));
            }
            catch (Exception)
            {
                return new JsonResult("Something wrong") { StatusCode = 500 };
                throw;
            }
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("getall")]
        public IActionResult getall()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllAssets()
        {
            var allAssets = _assetService.GetAllAssets();
            return Ok(allAssets);
        }
    }
}
