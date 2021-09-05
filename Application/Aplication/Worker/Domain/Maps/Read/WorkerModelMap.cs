using Application.Aplication.Worker.Domain.Read.Model;
using FluentNHibernate.Mapping;


namespace Application.Aplication.Worker.Domain.Maps.Read
{
      public class WorkerModelMap : ClassMap<WorkerModel>
      {
            public WorkerModelMap()
            {
                ReadOnly();

                Schema("dbo");
                Table("WorkersView");

                Id(x => x.Worker_Id);
            
                Map(x => x.Name);
                Map(x => x.Cpf);
                Map(x => x.Phone_Number);
                Map(x => x.Adress);
                Map(x => x.Email);
                Map(x => x.Type); 
            }
      }
}
