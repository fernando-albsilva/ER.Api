using System.Collections.Generic;
using ER.Repositories;
using Microsoft.AspNetCore.Mvc;
using ER.Entities;
using System;

namespace ER.Controllers
{
    //GET  /Products

    [ApiController]
    
    public class ProductsController : ControllerBase
    {
      private readonly ProductRepository repository;

      public ProductsController()
      {
         repository = new ProductRepository();
      }

    //   [HttpGet]
    //   [Route("Products")]
    //   public IEnumerable<Product> GetProducts()
    //   {
    //       var products = repository.GetProducts();
    //       return products;
    //   } 

      [HttpGet]
      [Route("Products")]
      public IEnumerable<Product> GetAll()
      {
          var products = repository.GetAll();
          return products;
      } 

      [HttpGet]
      [Route("Product")]
       public Product GetById(Guid id)
      {
          var product = repository.GetById(id);
          return product;
      } 
    }
}