using System.Collections.Generic;
using ER.Repositories;
using Microsoft.AspNetCore.Mvc;
using ER.Entities;
using System;
using ER.Interfaces;

namespace ER.Controllers
{
    //GET  /Products

    [ApiController]
    
    public class ProductsController : ControllerBase
    {
      private readonly IBaseProductRepository repository;

      public ProductsController(IBaseProductRepository repository)
      {
         this.repository = repository;
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