using System;
using System.Collections.Generic;
using ERapi.Aplication.Function.Domain.Read.Model;
using ERapi.Aplication.Function.Domain.Read.Repositories;
using ERapi.Aplication.Function.Domain.Write.Aggregates;
using ERapi.Aplication.Function.Domain.Write.Commands;
using ERapi.Aplication.Function.Domain.Write.Repositories;
using ERapi.Aplication.Function.Domain.Write.States;

namespace ERapi.Aplication.Function.Domain.Write.CommandHandllers
{

    public class FunctionCommandHandler : IFunctionCommandHandler
    {

        private readonly IBaseWriteFunctionRepository writeFunctionRepository;
        private readonly IBaseReadFunctionRepository readFunctionReposirory;

        public FunctionCommandHandler(IBaseWriteFunctionRepository writeRepository, IBaseReadFunctionRepository readReposirory)
        {
            this.writeFunctionRepository = writeRepository;
            this.readFunctionReposirory = readReposirory;


        }

      
        public void Handle(CreateFunction cmd)
        {

            var aggregate = new FunctionAggregate(cmd);
            writeFunctionRepository.Save(aggregate.State);

        }


        public void Handle(UpdateFunction cmd)
        {
            FunctionModel functionModel = readFunctionReposirory.GetById(cmd.Id);
            ValidateId(functionModel);
            FunctionState state = new FunctionState
            {
                
                Id = functionModel.Id,
                Type = functionModel.Type

            };

            var aggregate = new FunctionAggregate(state);
            aggregate.Change(cmd);
            writeFunctionRepository.Update(aggregate.State);

        }


        public void Handle(int id)
        {
            FunctionModel functionModel = readFunctionReposirory.GetById(id);
            ValidateId(functionModel);
            writeFunctionRepository.Delete(functionModel.Id);
        }


        private void ValidateId(FunctionModel functionModel)
        {

            IEnumerable<FunctionModel> functionsModel = readFunctionReposirory.GetAll();

            List<int> functionsId = new List<int>();

            foreach(var function in functionsModel)
            {
                functionsId.Add(function.Id);
            }

            if(functionModel.Id == 0 || !functionsId.Contains(functionModel.Id))
            {
                throw new Exception("Não existe registro com esse Id.");
            }
        }

    }

}