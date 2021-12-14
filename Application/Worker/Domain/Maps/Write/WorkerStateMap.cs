using Application.Invoice.Domain.Write.States;
using Application.Worker.Domain.Write.States;
using FluentNHibernate.Mapping;


namespace Application.Worker.Domain.Maps.Write
{
      public class WorkerStateMap : ClassMap<WorkerState>
      {
            public WorkerStateMap()
            {
               
                Schema("dbo");
                Table("Worker");

                Id(x => x.Id);
            
                Map(x => x.Name);
                Map(x => x.Cpf);
                Map(x => x.PhoneNumber);
                Map(x => x.Address);
                Map(x => x.Email);
                References(x => x.Function,"FunctionId");
                HasMany<InvoiceState>(x => x.InvoiceState).KeyColumn("Id");

        }
      }
}
