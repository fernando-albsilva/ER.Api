using Application.Aplication.Home.Domain.Read.Model;
using Application.Aplication.Home.Domain.Read.Repositories;
using Application.Aplication.Product.Domain.Read.Model;
using Application.Aplication.Product.Domain.Read.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ERapi.Controllers 
{

[ApiController]
public class HomeController : ControllerBase
{

        private readonly IBaseReadHomeRepository HomeReadRepository;
        private readonly IBaseReadProductRepository ProductReadRepository;



        public HomeController(IBaseReadHomeRepository homeReadRepository,
                              IBaseReadProductRepository productReadRepository)
        {
            this.HomeReadRepository = homeReadRepository;
            this.ProductReadRepository = productReadRepository;
            
        }

        #region Querys

        [HttpGet]
        [Route("Home/GetAllWaiters")]
        public IEnumerable<WaiterModel> GetAllWaiters()
        {
            var waiterModellList = HomeReadRepository.GetAllWaiter();
            return waiterModellList;
        }

        [HttpGet]
        [Route("Home/GetAllProducts")]
        public IEnumerable<ProductModel> GetAllProducts()
        {
            var ProductModelList = ProductReadRepository.GetAll();
            return ProductModelList;

        }
        #endregion

        #region Commands



        #endregion
    }

}