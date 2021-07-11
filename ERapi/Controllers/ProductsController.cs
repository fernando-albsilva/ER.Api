using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using ER.Repositories;
using ER.Commands;
using ER.Models;
using ER.Interfaces;
using ER.Aggregates;
using ER.CommandHandler;

namespace ER.Controllers
{
    //GET  /Products

    
    [ApiController]
    public class ProductsController : ControllerBase
    {
      private readonly IBaseReadProductRepository readRepository;
      private readonly IBaseWriteProductRepository writeRepository;
      private readonly IProductCommandHandler productCommandHandler;

      private ProductAggregate aggregate;

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
      [Route("Product/Create")]
      public void Create(CreateProduct cmd)
      {
          productCommandHandler.Handle(cmd);
      }

      [HttpPut]
      [Route("Product/Update")]
      public void Update(UpdateProduct cmd)
      {
          productCommandHandler.Handle(cmd);
      }

      [HttpDelete]
      [Route("Product/Delete")]
      public void Delete(Guid Id)
      {
          productCommandHandler.Handle(Id);
      }

    #endregion

    }
}