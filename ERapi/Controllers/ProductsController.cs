using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using Application.Product.Domain.Read.Repositories;
using Application.Product.Domain.Write.CommandHandlers;
using Application.Product.Domain.Read.Model;
using Application.Product.Domain.Write.Commands;

namespace ERapi.Controllers
{
  
    [ApiController]
    public class ProductsController : ControllerBase
    {
      private readonly IBaseReadProductRepository readRepository;
      private readonly IProductCommandHandler productCommandHandler;
      

        public ProductsController(IBaseReadProductRepository readRepository,IProductCommandHandler productCommandHandler)
        {
             this.readRepository = readRepository;
             this.productCommandHandler = productCommandHandler;
        }

        #region Querys
      
        [HttpGet]
        [Route("Products/GetAll")]
        public IEnumerable<ProductModel> GetAll()
        {
            var ProductModelList = readRepository.GetAll();
            return ProductModelList;
        
        } 

        [HttpGet]
        [Route("Products/GetById")]
        public ProductModel GetById(Guid id)
        {
            var productModel = readRepository.GetById(id);
            return productModel;
        }

        #endregion 

        #region Commands

        [HttpPost]
        [Route("Products/Create")] 
        public void Create(CreateProduct cmd)
        {
            productCommandHandler.Handle(cmd);
        }

        [HttpPut]
        [Route("Products/Update")]
        public void Update(UpdateProduct cmd)
        {
            productCommandHandler.Handle(cmd);
        }

        [HttpDelete]
        [Route("Products/Delete")]
        public void Delete(Guid Id)
        {
            productCommandHandler.Handle(Id);
        }

        [HttpPost]
        [Route("Products/DeleteByList")]
        public void DeleteByList(List<Guid> IdList)
        {
            productCommandHandler.Handle(IdList);
        }

        #endregion

        #region testes

        [HttpPost]
        [Route("Products/CreateProductsTest")]
        public void CreateTest(CreateProduct cmd)
        {
            for(var i=0; i<10; i++)
            {
                cmd.Id = Guid.NewGuid();
                cmd.Name = "Product" + i.ToString();
                productCommandHandler.Handle(cmd);
            }   
        }

        #endregion

    }
}