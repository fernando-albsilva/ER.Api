using System.Collections.Generic;
using ER.Repositories;
using Microsoft.AspNetCore.Mvc;
using ER.Entities;

namespace ER.Controllers
{
    //GET  /Products

    [ApiController]
    [Route("Products")]
    public class ProductsController : ControllerBase
    {
      private readonly ProductRepository repository;

      public ProductsController()
      {
         repository = new ProductRepository();
      }

      [HttpGet]
      public void GetProducts()
      {
          var  frase = "oi";
      } 
    }
}