using Application.ActiveInvoice.Domain.Read.Model;
using Application.ActiveInvoice.Domain.Read.Repositories;
using Application.ActiveInvoice.Domain.Write.CommandHandlers;
using Application.ActiveInvoice.Domain.Write.Commands;
using Application.Invoice.Domain.Read.Model;
using Application.Invoice.Domain.Read.Repositories;
using Application.Invoice.Domain.Write.CommandHandlers;
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
using Application.CheckManagement.Domain.Read.Model;
using Application.CheckManagement.Domain.Read.Repositories;

namespace ERapi.Controllers
{

    [ApiController]
   // [Authorize]

    public class CheckManagementController : ControllerBase
    {
        private readonly IBaseReadWorkerRepository WorkerReadRepository;
        private readonly IBaseReadProductRepository ProductReadRepository;
        private readonly IBaseReadActiveInvoiceRepository ActiveInvoiceReadRepository;
        private readonly IBaseReadInvoiceRepository InvoiceReadRepository;
        private readonly IBaseReadCheckManagementRepository CheckManagementRepository;
        private readonly IActiveInvoiceCommandHandler ActiveInvoiceCommandHandler;
        private readonly IInvoiceCommandHandler InvoiceCommandHandler;
        public CheckManagementController(
            IBaseReadWorkerRepository workerReadRepository,
            IBaseReadProductRepository productReadRepository,
            IBaseReadActiveInvoiceRepository activeInvoiceReadRepository,
            IBaseReadInvoiceRepository invoiceReadRepository,
            IBaseReadCheckManagementRepository checkManagementRepository,
            IActiveInvoiceCommandHandler activeInvoiceCommandHandler,
            IInvoiceCommandHandler invoiceCommandHandler
        )
        {
            WorkerReadRepository = workerReadRepository;
            ProductReadRepository = productReadRepository;
            ActiveInvoiceReadRepository = activeInvoiceReadRepository;
            InvoiceReadRepository = invoiceReadRepository;
            CheckManagementRepository = checkManagementRepository;
            ActiveInvoiceCommandHandler = activeInvoiceCommandHandler;
            InvoiceCommandHandler = invoiceCommandHandler;
        }

        [HttpGet]
        //[Authorize(Roles = "admin")]
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

        [HttpGet]
        [Route("CheckManagement/GetActiveInvoice")]
        public ActiveInvoiceModel GetActiveInvoice(Guid id)
        {
            return ActiveInvoiceReadRepository.GetById(id);
        }

        [HttpGet]
        [Route("CheckManagement/GetAllActiveInvoice")]
        public IList<ActiveInvoiceModel> GetAllActiveInvoice()
        {
            return ActiveInvoiceReadRepository.GetAll();
        }

        [HttpGet]
        [Route("CheckManagement/GetActiveTablesAndIndividualChecks")]
        public IList<ActiveTablesAndIndividualChecksModel> GetActiveTablesAndIndividualChecks()
        {
            return ActiveInvoiceReadRepository.GetActiveTablesAndIndividualChecks();
        }
        
        [HttpGet]
        [Route("CheckManagement/GetInvoiceById")]
        public InvoiceModel GetInvoiceById(Guid id)
        {
            var invoiceModel = InvoiceReadRepository.GetById(id);
            return invoiceModel;
        } 
        
        [HttpGet]
        [Route("CheckManagement/GetAllInvoice")]
        public IList<InvoiceFlatModel> GetAllInvoice()
        {
            var list = InvoiceReadRepository.GetAllInvoices();
            return list;
        } 
        
        [HttpGet]
        [Route("CheckManagement/GetCheckManagementSettings")]
        public CheckManagemantSettingsModel GetCheckManagementConfig(Guid id)
        {
            var checkManagementSettings  = CheckManagementRepository.GetSettingsByUserId(id);
            return checkManagementSettings;
        }

        [HttpPost]
        [Route("CheckManagement/CrateActiveTable")]
        public IActionResult CrateActiveTable(CreateActiveInvoiceCommand cmd)
        { 
            ActiveInvoiceCommandHandler.Handle(cmd);
            return Ok();
        }

        [HttpPut]
        [Route("CheckManagement/UpdateActiveTable")]
        public IActionResult UpdateActiveTable(UpdateActiveInvoiceCommand cmd)
        { 
            ActiveInvoiceCommandHandler.Handle(cmd);
            return Ok();
        }

        [HttpPost]
        [Route("CheckManagement/AddItemInInvoice")]
        public IActionResult AddItemInInvoice(CreateActiveInvoiceItemCommand cmd)
        {
            ActiveInvoiceCommandHandler.Handle(cmd);
            return Ok();
        }  
        
        [HttpPost]
        [Route("CheckManagement/CloseCheck")]
        public IActionResult CloseCheck([FromForm] Guid activeInvoiceId)
        {
            var activeInvoice = ActiveInvoiceReadRepository.GetById(activeInvoiceId);
            InvoiceCommandHandler.Handle(activeInvoice);
            ActiveInvoiceCommandHandler.CloseCheck(activeInvoiceId);
            return Ok();
        } 
        
        [HttpDelete]
        [Route("CheckManagement/RemoveActiveInvoiceItem")]
        public IActionResult RemoveActiveInvoiceItem(Guid id)
        {
            ActiveInvoiceCommandHandler.RemoveActiveInvoiceItem(id);
            return Ok();
        }

    }
}
