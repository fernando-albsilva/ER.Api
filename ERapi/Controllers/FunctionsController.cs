
using Application.Function.Domain.Read.Model;
using Application.Function.Domain.Read.Repositories;
using Application.Function.Domain.Write.CommandHandllers;
using Application.Function.Domain.Write.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ERapi.Controllers
{

    //GET  /Functions

    [ApiController]
    [Authorize]
    public class FunctionsController : ControllerBase
    {

        private readonly IFunctionCommandHandler functionCommandHandler;
        private readonly IBaseReadFunctionRepository readFunctionRepository;

        public FunctionsController(IFunctionCommandHandler functionCommandHandler, IBaseReadFunctionRepository readFunctionRepository)
        {
            this.functionCommandHandler = functionCommandHandler;
            this.readFunctionRepository = readFunctionRepository;
        }



        #region Querys

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("Functions/GetAll")]
        public IEnumerable<FunctionModel> GetAll()
        {
            var functionModelList = readFunctionRepository.GetAll();
            return functionModelList;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("Functions/GetById")]
        public FunctionModel GetById(int id)
        {
            var functionModel = readFunctionRepository.GetById(id);
            return functionModel;
        }

        #endregion


        #region Commands


        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("Functions/Create")]
        public void Create(CreateFunction cmd)
        {

            functionCommandHandler.Handle(cmd);

        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("Functions/Update")]

        public void Update(UpdateFunction cmd)
        {

            functionCommandHandler.Handle(cmd);

        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("Functions/Delete")]
        
        public void Delete(int id)
        {
            functionCommandHandler.Handle(id);
        }


        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("Functions/DeleteByList")]
        public void DeleteByList(List<int> IdList)
        {
            functionCommandHandler.Handle(IdList);
        }

        #endregion

    }

} 