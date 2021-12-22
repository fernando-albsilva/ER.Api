using Aplication.Auth.User.Domain.Write.Commands;
using Application.Auth.Domain.Read.Repositories;
using Application.Auth.User.Domain.Read.Model;
using Application.Auth.User.Domain.Write.CommandHandlers;
using Application.Auth.User.Domain.Write.Repositories;
using AuthenticationPlugin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERapi.Controllers
{
    [ApiController]
    [Authorize]

    public class UserController : ControllerBase
    {
        private IUserCommandHandler userCommandHandler;
        private IBaseReadUserRepository userReadRepository;

        public UserController(IUserCommandHandler userCommandHandler, IBaseReadUserRepository userReadRepository)
        {
            this.userCommandHandler = userCommandHandler;
            this.userReadRepository = userReadRepository;
        }
       
        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("User/GetAll")]
        public IEnumerable<UserFlatModel> GetAll()
        {
            var functionModelList = userReadRepository.GetAll();
            return functionModelList;
        }

        [HttpPost]
        [Route("User/Create")]
        public void Create(CreateUser cmd)
        {
            cmd.Password = SecurePasswordHasherHelper.Hash(cmd.Password);
            this.userCommandHandler.Handle(cmd);
        }

    }
}
