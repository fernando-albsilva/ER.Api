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
      private readonly IBaseReadProductRepository readRepository;
      private readonly IBaseProductRepository writeRepository;

      public ProductsController(IBaseReadProductRepository readRepository,IBaseProductRepository writeRepository)
      {
         this.readRepository = readRepository;
         this.writeRepository = writeRepository;
      }

      #region Querys
      
      [HttpGet]
      [Route("Products")]
      public IEnumerable<ProductDto> GetAll()
      {
          var productDtoList = readRepository.GetAll();
          return productDtoList;
      } 

      [HttpGet]
      [Route("Product")]
       public ProductDto GetById(Guid id)
      {
          var productDto = readRepository.GetById(id);
          return productDto;
      }

      #endregion 


    }
}