using ERapi.Aplication.Function.Domain.Read.Model;
using ERapi.Aplication.Function.Domain.Read.Repositories;
using ERapi.Aplication.Function.Domain.Write.CommandHandllers;
using ERapi.Aplication.Function.Domain.Write.Commands;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ER.Controllers
{

    [ApiController]
    public class FunctionController : ControllerBase
    {

        private readonly IFunctionCommandHandler functionCommandHandler;
        private readonly IBaseReadFunctionRepository readFunctionRepository;

        public FunctionController(IFunctionCommandHandler functionCommandHandler, IBaseReadFunctionRepository readFunctionRepository)
        {
            this.functionCommandHandler = functionCommandHandler;
            this.readFunctionRepository = readFunctionRepository;
        }



        #region Querys


        [HttpGet]
        [Route("Function/GetById")]
        public FunctionModel GetById(int id)
        {
            var functionModel = readFunctionRepository.GetById(id);
            return functionModel;
        }

        #endregion


        #region Commands


        [HttpPost]
        [Route("Function/Create")]
        public void Create(CreateFunction cmd)
        {

            functionCommandHandler.Handle(cmd);

        }

        #endregion

    }

} 