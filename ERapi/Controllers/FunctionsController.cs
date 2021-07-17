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

        public FunctionController(IFunctionCommandHandler functionCommandHandler)
        {
            this.functionCommandHandler = functionCommandHandler;
        }



        #region Querys


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