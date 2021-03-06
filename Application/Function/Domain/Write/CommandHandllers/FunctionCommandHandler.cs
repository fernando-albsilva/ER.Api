using System;
using System.Collections.Generic;
using Application.Function.Domain.Read.Model;
using Application.Function.Domain.Read.Repositories;
using Application.Function.Domain.Write.Aggregates;
using Application.Function.Domain.Write.Commands;
using Application.Function.Domain.Write.Repositories;
using Application.Function.Domain.Write.States;


namespace Application.Function.Domain.Write.CommandHandllers
{

      public class FunctionCommandHandler : IFunctionCommandHandler
      {

            private readonly IBaseWriteFunctionRepository writeFunctionRepository;
            private readonly IBaseReadFunctionRepository readFunctionReposirory;

            public FunctionCommandHandler(IBaseWriteFunctionRepository writeRepository, IBaseReadFunctionRepository readReposirory)
            {
                  writeFunctionRepository = writeRepository;
                  readFunctionReposirory = readReposirory;


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
                  FunctionState state = new FunctionState
                  {
                        Id = functionModel.Id,
                        Type = functionModel.Type
                  };




                  writeFunctionRepository.Delete(state);
            }

            public void Handle(List<int> idList)
            {
                foreach (int element in idList)
                {
                    FunctionState productState = writeFunctionRepository.GetById(element);
                    if (productState.Id != 0)
                    {
                        writeFunctionRepository.Delete(productState);
                    }
                    
                }
            }


        private void ValidateId(FunctionModel functionModel)
            {

                  IEnumerable<FunctionModel> functionsModel = readFunctionReposirory.GetAll();

                  List<int> functionsId = new List<int>();

                  foreach (var function in functionsModel)
                  {
                        functionsId.Add(function.Id);
                  }

                  if (functionModel.Id == 0 || !functionsId.Contains(functionModel.Id))
                  {
                        throw new Exception("N??o existe registro com esse Id.");
                  }
            }

      }



}