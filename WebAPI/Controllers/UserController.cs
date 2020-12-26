using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer;
using DTOs;
using EntityFrameWorkDataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poco;

namespace WebAPI.Controllers
{
    [Route("api/DAC/USER/v1")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserLogic _logic;
        public UserController()
        {
            var repo = new EFGenericRepository<User>();
            _logic = new UserLogic(repo);
        }

        [HttpGet]
        [Route("User")]
        public ActionResult GetAllUser()
        {
            var users = _logic.GetAll();
            if (users == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(users);
            }

        }


        [HttpGet]
        [Route("Get/{id}")]
        public ActionResult Get(Guid id)
        {
              User poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(poco);
            }

        }


        [HttpPost]
        [Route("CreateUser")]
        public ActionResult CreateUser([FromBody] UserDto[] dtos)
        {
            _logic.Add(dtos);
            return Ok();

        }

        [HttpPut]
        [Route("UpdateUser")]
        public ActionResult UpdateUser([FromBody] UserDto[] dtos)
        {
            _logic.Update(dtos);
            return Ok();

        }

        [HttpDelete]
        [Route("DeleteUser")]
        public ActionResult DeleteUser([FromBody] User[] user)
        {
           
            _logic.Delete(user);
            return Ok();

        }
    }
}
