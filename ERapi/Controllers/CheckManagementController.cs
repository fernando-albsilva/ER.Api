using Application.ActiveInvoice.Domain.Write.CommandHandlers;
using Application.ActiveInvoice.Domain.Write.Commands;
using Application.Product.Domain.Read.Model;
using Application.Product.Domain.Read.Repositories;
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
        private readonly IBaseReadProductRepository ProductReadRepository;
        private readonly IActiveInvoiceCommandHandler ActiveInvoiceCommandHandler;
        public CheckManagementController(
            IBaseReadWorkerRepository workerReadRepository,
            IBaseReadProductRepository productReadRepository,
            IActiveInvoiceCommandHandler activeInvoiceCommandHandler
        )
        {
            this.WorkerReadRepository = workerReadRepository;
            this.ProductReadRepository = productReadRepository;
            this.ActiveInvoiceCommandHandler = activeInvoiceCommandHandler;
        }

        [HttpGet]
        /*[Authorize(Roles = "admin")]*/
        [Route("CheckManagement/Workers")]
        public List<WorkerFlatModel> GetWorkersByFunctionWaiter()
        {
            return WorkerReadRepository.GetWorkersByFunctionWaiter();
        }

        [HttpGet]
        [Route("CheckManagement/Products")]
        public List<ProductModel> GetAvailableProducts()
        {
            return ProductReadRepository.GetAll().ToList();
        }


        [HttpPost]
        [Route("CheckManagement/CrateActiveTable")]
        public IActionResult CrateActiveTable(CreateActiveInvoiceCommand cmd)
        {
            var teste = cmd;
            ActiveInvoiceCommandHandler.handle(cmd);
            return Ok();
        }

    }
}
