using System;
using Application.Aplication.Function.Domain.Read.Model;
using Application.Aplication.Worker.Domain.Read.WorkerBaseModel;

namespace Application.Aplication.Worker.Domain.Read.Model
{
      public class WorkerModel : WorkerBaseReadModel
      {
            public virtual string Name { get; set; }
            public virtual string Cpf { get; set; }
            public virtual string Phone_Number { get; set; }
            public virtual string Address { get; set; }
            public virtual string Email { get; set; }
            public virtual string Type { get; set; }

      }
}