using Application.Home.Domain.Read.Model;
using Application.Home.Domain.Read.Repositories;
using Application.Invoice.Domain.Write.CommandHandlers;
using Application.Invoice.Domain.Write.Commands;
using Application.Product.Domain.Read.Model;
using Application.Product.Domain.Read.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ERapi.Controllers 
{

[ApiController]
public class HomeController : ControllerBase
{

        private readonly IBaseReadHomeRepository HomeReadRepository;
        private readonly IBaseReadProductRepository ProductReadRepository;
        private IInvoiceCommandHandler InvoiceCommandhandler;



        public HomeController(IBaseReadHomeRepository homeReadRepository,
                              IBaseReadProductRepository productReadRepository,
                              IInvoiceCommandHandler invoiceCommandhandler)
        {
            this.HomeReadRepository = homeReadRepository;
            this.ProductReadRepository = productReadRepository;
            this.InvoiceCommandhandler = invoiceCommandhandler;
            
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
        [HttpPost]
        [Route("Home/CreateInvoice")]
        public void createInvoice(CreateInvoice cmd)
        {
            InvoiceCommandhandler.Handle(cmd);
        }

        #endregion
    }

}