using Application.Aplication.Function.Domain.Read.Repositories;
using Application.Aplication.Home.Domain.Read.Model;
using Application.Aplication.Home.Domain.Read.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ERapi.Controllers 
{

[ApiController]
public class HomeController : ControllerBase
{

        private readonly IBaseReadHomeRepository HomeReadRepository;
        


        public HomeController(IBaseReadHomeRepository homeReadRepository)
        {
            this.HomeReadRepository = homeReadRepository;
            
        }

        #region Querys

        [HttpGet]
        [Route("Home/GetAllWaiters")]
        public IEnumerable<WaiterModel> GetAll()
        {
            var waiterModellList = HomeReadRepository.GetAllWaiter();
            return waiterModellList;
        }

        #endregion 

        #region Commands
        
   

        #endregion
    }

}