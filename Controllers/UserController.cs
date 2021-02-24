using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tasks.API.Models;
using Tasks.API.Repositories;
using Tasks.API.ViewModels;

namespace Tasks.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;

        public UserController(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("InsertUser")]
        public async Task<ActionResult<bool>> InsertUser(UserViewModel userViewModel)
        {
            var userModel = _mapper.Map<UserModel>(userViewModel);
            var result = await _userRepo.InsertUser(userModel);
            return result;
        }

        [HttpPost]
        [Route("GetUser")]
        public async Task<ActionResult<UserModel>> GetUser(UserModel user)
        {
            var result = await _userRepo.GetUser(user);
            return result;
        }

        [HttpGet]
        [Route("CheckUserName")]
        public async Task<ActionResult<bool>> CheckUserName(string userName)
        {
            var result = await _userRepo.CheckUserName(userName);
            return result;
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult<bool>> UpdateUser(UserModel user)
        {
            var result = await _userRepo.UpdateUser(user);
            return result;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<ActionResult<List<UserViewModel>>> GetUsers()
        {
            var result = _mapper.Map<List<UserViewModel>>(await _userRepo.GetUsers());
            return result;
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult<bool>> DeleteUser(int userId)
        {
            var result = await _userRepo.DeleteUser(userId);
            return result;
        }



    }
}