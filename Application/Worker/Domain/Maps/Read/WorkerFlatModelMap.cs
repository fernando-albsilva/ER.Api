using Application.Worker.Domain.Read.Model;
using FluentNHibernate.Mapping;


namespace Application.Worker.Domain.Maps.Read
{
      public class WorkerFlatModelViewModelMap : ClassMap<WorkerFlatModel>
      {
            public WorkerFlatModelViewModelMap()
            {
                ReadOnly();

                Schema("dbo");
                Table("WorkersView");

                Id(x => x.Id);
            
                Map(x => x.Name);
                Map(x => x.Cpf);
                Map(x => x.PhoneNumber);
                Map(x => x.Address);
                Map(x => x.Email);
                Map(x => x.Type);
            }
      }
}
