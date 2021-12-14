using System;
using Application.Function.Domain.Read.Model;
using Application.Worker.Domain.Read.WorkerBaseModel;

namespace Application.Worker.Domain.Read.Model
{
      public class WorkerModel : WorkerBaseReadModel
      {
            public virtual string Name { get; set; }
            public virtual string Cpf { get; set; }
            public virtual string PhoneNumber { get; set; }
            public virtual string Address { get; set; }
            public virtual string Email { get; set; }
            public virtual string Type { get; set; }

        //TODO tirar o type do wokerModel e trazer o functionModel com type e id

      }
}