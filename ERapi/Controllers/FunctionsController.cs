
using Application.Aplication.Function.Domain.Read.Model;
using Application.Aplication.Function.Domain.Read.Repositories;
using Application.Aplication.Function.Domain.Write.CommandHandllers;
using Application.Aplication.Function.Domain.Write.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ERapi.Controllers
{

    //GET  /Functions

    [ApiController]
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
        [Route("Functions/GetAll")]
        public IEnumerable<FunctionModel> GetAll()
        {
            var functionModelList = readFunctionRepository.GetAll();
            return functionModelList;
        }

        [HttpGet]
        [Route("Functions/GetById")]
        public FunctionModel GetById(int id)
        {
            var functionModel = readFunctionRepository.GetById(id);
            return functionModel;
        }

        #endregion


        #region Commands


        [HttpPost]
        [Route("Functions/Create")]
        public void Create(CreateFunction cmd)
        {

            functionCommandHandler.Handle(cmd);

        }

        [HttpPut]
        [Route("Functions/Update")]

        public void Update(UpdateFunction cmd)
        {

            functionCommandHandler.Handle(cmd);

        }

        [HttpDelete]
        [Route("Functions/Delete")]
        
        public void Delete(int id)
        {
            functionCommandHandler.Handle(id);
        }

        #endregion

    }

} 