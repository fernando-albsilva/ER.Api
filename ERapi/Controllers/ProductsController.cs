using System.Collections.Generic;
using ER.Repositories;
using Microsoft.AspNetCore.Mvc;
using ER.Entities;
using ER.Dtos;
using System;
using ER.Interfaces;
using System.Linq;


namespace ER.Controllers
{
    //GET  /Products

    [ApiController]
    
    public class ProductsController : ControllerBase
    {
      private readonly IBaseReadProductRepository repository;

      public ProductsController(IBaseReadProductRepository repository)
      {
         this.repository = repository;
      }

      #region Querys
      
      [HttpGet]
      [Route("Products")]
      public IEnumerable<ProductDto> GetAll()
      {
          var products = repository.GetAll().Select( product => new ProductDto{
             Id = product.Id,
             Name = product.Name,
             UnitValue = product.UnitValue,
             Cost = product.Cost
          });
          return products;
      } 

      [HttpGet]
      [Route("Product")]
       public ProductDto GetById(Guid id)
      {
          var product = repository.GetById(id);
          var productDto = new ProductDto{
             Id = product.Id,
             Name = product.Name,
             UnitValue = product.UnitValue,
             Cost = product.Cost
          };
          return productDto;
      }

      #endregion 


    }
}