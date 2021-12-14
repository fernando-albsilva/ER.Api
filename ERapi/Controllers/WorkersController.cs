using Application.Worker.Domain.Read.Model;
using Application.Worker.Domain.Read.Repositories;
using Application.Worker.Domain.Write.CommandHandlers;
using Application.Worker.Domain.Write.Commands;
using Application.Worker.Domain.Write.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ERapi.Controllers 
{

[ApiController]
public class WorkersController : ControllerBase
{

        private readonly IBaseReadWorkerRepository WorkerReadRepository;
        private readonly IBaseWriteWorkerRepository WorkerWriteRepository;
        private readonly IWorkerCommandHandler WorkerCommandHandler;


        public WorkersController(IBaseReadWorkerRepository workerReadRepository, IBaseWriteWorkerRepository workerWriteRepository, IWorkerCommandHandler workerCommandHandler)
        {
            this.WorkerReadRepository = workerReadRepository;
            this.WorkerWriteRepository = workerWriteRepository;
            this.WorkerCommandHandler = workerCommandHandler;

        }

        #region Querys

        [HttpGet]
        [Route("Worker/GetAll")]
        public IEnumerable<WorkerModel> GetAll()
        {
            var WorkertModelList = WorkerReadRepository.GetAll();
            return WorkertModelList;

        }  

        [HttpGet]
        [Route("Worker/WorkerById")]
        public WorkerModel GetById(Guid id)
        {
            var workerModel = WorkerReadRepository.GetById(id);
            return workerModel;
        }

        #endregion 

        #region Commands
        
        [HttpPost]
        [Route("Worker/Create")]
        public void Create(CreateWorker cmd)
        {
            WorkerCommandHandler.Handle(cmd);
        }
        
        [HttpPut]
        [Route("Worker/Update")]
        public void Update(UpdateWorker cmd)
        {
            WorkerCommandHandler.Handle(cmd);
        }

        [HttpDelete]
        [Route("Worker/Delete")]
        public void Delete(Guid Id)
        {
            WorkerCommandHandler.Handle(Id);
        }
       

        [HttpPost]
        [Route("Worker/DeleteByList")]
        public void DeleteByList(List<Guid> IdList)
        {
            WorkerCommandHandler.Handle(IdList);
        }

        #endregion
    }

}