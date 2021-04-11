using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getbyid")]
        public ActionResult GetById(int id)
        {
            var result = _userService.Get(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("getbyemaildto")]
        public ActionResult GetByEmailDto(User user)
        {
            var result = _userService.GetByEmailDto(user.Email);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("getbyemail")]
        public ActionResult GetByEmail(User user)
        {
            var result = _userService.GetByEmail(user.Email);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("add")]
        public ActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("update")]
        public ActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
