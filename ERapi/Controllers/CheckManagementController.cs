﻿using Application.ActiveInvoice.Domain.Read.Model;
using Application.ActiveInvoice.Domain.Read.Repositories;
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
        private readonly IBaseReadActiveInvoiceRepository ActiveInvoiceReadRepository;
        private readonly IActiveInvoiceCommandHandler ActiveInvoiceCommandHandler;
        public CheckManagementController(
            IBaseReadWorkerRepository workerReadRepository,
            IBaseReadProductRepository productReadRepository,
            IBaseReadActiveInvoiceRepository activeInvoiceReadRepository,
            IActiveInvoiceCommandHandler activeInvoiceCommandHandler
        )
        {
            WorkerReadRepository = workerReadRepository;
            ProductReadRepository = productReadRepository;
            ActiveInvoiceReadRepository = activeInvoiceReadRepository;
            ActiveInvoiceCommandHandler = activeInvoiceCommandHandler;
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

        [HttpPost]
        [Route("CheckManagement/CrateActiveTable")]
        public IActionResult CrateActiveTable(CreateActiveInvoiceCommand cmd)
        { 
            ActiveInvoiceCommandHandler.handle(cmd);
            return Ok();
        }

        [HttpPut]
        [Route("CheckManagement/UpdateActiveTable")]
        public IActionResult UpdateActiveTable(UpdateActiveInvoiceCommand cmd)
        { 
            ActiveInvoiceCommandHandler.handle(cmd);
            return Ok();
        }

        [HttpPost]
        [Route("CheckManagement/AddItemInInvoice")]
        public IActionResult AddItemInInvoice(CreateActiveInvoiceItemCommand cmd)
        {
            ActiveInvoiceCommandHandler.handle(cmd);
            return Ok();
        }

    }
}
