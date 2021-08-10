using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Application.Aplication.Product.Domain.Read.Repositories;
using Application.Aplication.Product.Domain.Write.Repositories;
using Application.Aplication.Product.Domain.Write.CommandHandlers;
using Application.Aplication.Product.Domain.Read.Model;
using Application.Aplication.Product.Domain.Write.Commands;

namespace ERapi.Controllers
{
  
    [ApiController]
    public class ProductsController : ControllerBase
    {
      private readonly IBaseReadProductRepository readRepository;
      private readonly IBaseWriteProductRepository writeRepository;
      private readonly IProductCommandHandler productCommandHandler;
      

        public ProductsController(IBaseReadProductRepository readRepository,IBaseWriteProductRepository writeRepository,IProductCommandHandler productCommandHandler)
      {
         this.readRepository = readRepository;
         this.writeRepository = writeRepository;
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

      [HttpPost]
      [Route("Products/Update")]
      public void Update(UpdateProduct cmd)
      {
          productCommandHandler.Handle(cmd);
      }

      [HttpPost]
      [Route("Products/Delete")]
      public void Delete(DeleteProduct cmd)
      {
          productCommandHandler.Handle(cmd);
      }

        [HttpPost]
        [Route("Products/DeleteByList")]
        public void DeleteByList(DeleteProductList cmd)
        {
           /* productCommandHandler.Handle(cmd);*/
        }

        #endregion

    }
}