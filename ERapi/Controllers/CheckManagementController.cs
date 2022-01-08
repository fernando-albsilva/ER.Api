using Application.Worker.Domain.Read.Model;
using Application.Worker.Domain.Read.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERapi.Controllers
{

    [ApiController]
    /*[Authorize]*/
    
    public class CheckManagementController : ControllerBase
    {
        private readonly IBaseReadWorkerRepository WorkerReadRepository;
        public CheckManagementController(IBaseReadWorkerRepository workerReadRepository)
        {
            this.WorkerReadRepository = workerReadRepository;
        }

        [HttpGet]
        /*[Authorize(Roles = "admin")]*/
        [Route("CheckManagement/Workers")]
        public List<WorkerFlatModel> GetWorkersByFunctionWaiter()
        {
            return WorkerReadRepository.GetWorkersByFunctionWaiter();
        }

    }
}
