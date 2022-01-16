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
        public CheckManagementController(
            IBaseReadWorkerRepository workerReadRepository,
            IBaseReadProductRepository productReadRepository
        )
        {
            this.WorkerReadRepository = workerReadRepository;
            this.ProductReadRepository = productReadRepository;
        }

        [HttpGet]
        /*[Authorize(Roles = "admin")]*/
        [Route("CheckManagement/Workers")]
        public List<WorkerFlatModel> GetWorkersByFunctionWaiter()
        {
            return WorkerReadRepository.GetWorkersByFunctionWaiter();
        }
        
        [Route("CheckManagement/Products")]
        public List<ProductModel> GetAvailableProducts()
        {
            return ProductReadRepository.GetAll().ToList();
        }

    }
}
