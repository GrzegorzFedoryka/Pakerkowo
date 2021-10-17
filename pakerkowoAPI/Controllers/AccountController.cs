using Microsoft.AspNetCore.Mvc;
using PakerkowoAPI.Models;
using PakerkowoAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PakerkowoAPI.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm]RegisterUserDto dto)
        {
            var id = await _accountService.RegisterUser(dto);
            return Created(id.ToString(), null);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto dto)
        {
            var token = await _accountService.GenerateJwt(dto);
            return Ok(token);
        }
    }
}
