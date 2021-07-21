using ERapi.Aplication.Worker.Domain.Commands;
using ERapi.Aplication.Worker.Domain.Write.CommandHandlers;
using Microsoft.AspNetCore.Mvc;

namespace ER.Controllers 
{

[ApiController]
public class WorkersController : ControllerBase
{

    private readonly IWorkerCommandHandler workerCommandHandler;
    public WorkersController(IWorkerCommandHandler workerCommandHandler)
    {
        this.workerCommandHandler = workerCommandHandler;
    }


    #region Querys

        

    #endregion


    #region 

    [HttpPost]
    [Route("Workers/Create")]
    public void Create(CreateWorker cmd)
    {
        
        workerCommandHandler.Handle(cmd);

    }

    #endregion
}

}