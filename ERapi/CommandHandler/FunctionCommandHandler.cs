using ER.Aggregates;
using ER.Commands;
using ER.Interfaces;

namespace ER.CommandHandler 
{

    public class FunctionCommandHandler : IFunctionCommandHandler
    {

        private readonly IBaseWriteFunctionRepository writeFunctionRepository;

        public FunctionCommandHandler(IBaseWriteFunctionRepository functionRepository) 
        {
            this.writeFunctionRepository = functionRepository;

        }


        public void Handle(CreateFunction cmd)
        {

            var aggregate = new FunctionAggregate(cmd); 
            writeFunctionRepository.Save(aggregate.State);
            
        }
    }

}