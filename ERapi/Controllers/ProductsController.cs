using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using ER.Interfaces;
using ERapi.Aplication.Product.Domain.Read.Repositories;
using ERapi.Aplication.Product.Domain.Read.Model;
using ERapi.Aplication.Product.Domain.Write.Commands;
using ERapi.Aplication.Product.Domain.Write.Repositories;

namespace ER.Controllers
{
    //GET  /Products


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