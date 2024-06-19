using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Text.Json;
using Entities;
using Repository;
using Service;
using AutoMapper;
using DTO;

namespace webAPI_projectBYsteps.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    

    public class UserController: ControllerBase
    {
        IUserService _userService;
        IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService service, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = service;
            _mapper = mapper;
            _logger = logger;
            
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<User>> Login([FromBody] UserLoginDTO userLgn)
        {
            _logger.LogInformation($"Login attempted with username {userLgn.Email} and password {userLgn.Password}");
            User user = _mapper.Map<UserLoginDTO, User>(userLgn);
            User newUser = await _userService.Login(user);
            if (newUser!=null)
            {
                return Ok(user);
            }
            return Unauthorized();

        }

        [HttpGet("{id}")]
        public async  Task<ActionResult<User>> GetById(int id)
        {
            User user = await _userService.GetUserById(id);
                if (user != null)
                return Ok(user);
            return NoContent();
        }

        [HttpPost]
       
        public async Task<ActionResult<User>> Register([FromBody] User user)
        {
            User newUser = await _userService.Register(user);
            if (newUser != null)
                return Ok(newUser);
            return NoContent();

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User UpdatedUserDetails)
        {

            return await _userService.UpdateUser(id, UpdatedUserDetails);
       

        }
    }

}
