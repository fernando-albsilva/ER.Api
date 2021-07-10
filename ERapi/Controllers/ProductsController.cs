using System.Collections.Generic;
using ER.Repositories;
using Microsoft.AspNetCore.Mvc;
using ER.Commands;
using ER.Models;
using System;
using ER.Interfaces;
using System.Linq;
using ER.Aggregates;

namespace ER.Controllers
{
    //GET  /Products

    
    [ApiController]
    public class ProductsController : ControllerBase
    {
      private readonly IBaseReadProductRepository readRepository;
      private readonly IBaseProductRepository writeRepository;

      private ProductAggregate aggregate;

      public ProductsController(IBaseReadProductRepository readRepository,IBaseProductRepository writeRepository)
      {
         this.readRepository = readRepository;
         this.writeRepository = writeRepository;
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
          aggregate = new ProductAggregate(cmd);
          writeRepository.Save(aggregate.State);
      }

      [HttpPut]
      [Route("Product/Update")]
       public void Update(string objeto)
      {
          Console.WriteLine(objeto);
      }

      [HttpDelete]
      [Route("Product/Delete")]
       public void Delete(string objeto)
      {
          Console.WriteLine(objeto);
      }

    #endregion

    }
}