using ERapi.Aplication.Function.Domain.Write.Aggregates;
using ERapi.Aplication.Function.Domain.Write.Commands;
using ERapi.Aplication.Function.Domain.Write.Repositories;

namespace ERapi.Aplication.Function.Domain.Write.CommandHandllers
{

    public class FunctionCommandHandler : IFunctionCommandHandler
    {

        private readonly IBaseWriteFunctionRepository writeFunctionRepository;

        public FunctionCommandHandler(IBaseWriteFunctionRepository functionRepository)
        {
            writeFunctionRepository = functionRepository;

        }


        public void Handle(CreateFunction cmd)
        {

            var aggregate = new FunctionAggregate(cmd);
            writeFunctionRepository.Save(aggregate.State);

        }
    }

}