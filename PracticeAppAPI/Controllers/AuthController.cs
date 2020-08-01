using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeAppAPI.Data;
using PracticeAppAPI.Dtos;
using PracticeAppAPI.Models;

namespace PracticeAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userDto)
        {
            // === Model Binding ===
            // when [ApiController] is applied, the controller use [FromBody] to parse complex object (userDto here)
            // by default. To force the controller parse values from other source try [FromForm] or [FromQuery] etc

            // === Model Status ===
            // if [ApiController] is not applied to the controller, data validation (userDto here) will not be performed
            // but we can use Model.Staus to check the validation
            // if (!ModelState.IsValid) return BadRequest(ModelState);

            userDto.Username = userDto.Username.ToLower();
            if (await _authRepo.UserExists(userDto.Username))
                return BadRequest("Username Already Exists");

            User newUser = new User() { UserName = userDto.Username };
            await _authRepo.Register(newUser, userDto.Password);

            // 201 = created
            // should be replaced by CreatedAtRoute() later
            return StatusCode(201);
        }
    }
}
