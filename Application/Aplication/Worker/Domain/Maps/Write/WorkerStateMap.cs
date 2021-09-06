using Application.Aplication.Worker.Domain.Write.States;
using FluentNHibernate.Mapping;


namespace Application.Aplication.Worker.Domain.Maps.Write
{
      public class WorkerStateMap : ClassMap<WorkerState>
      {
            public WorkerStateMap()
            {
               
                Schema("dbo");
                Table("Worker");

                Id(x => x.Worker_Id);
            
                Map(x => x.Name);
                Map(x => x.Cpf);
                Map(x => x.Phone_Number);
                Map(x => x.Address);
                Map(x => x.Email);
                References(x => x.Function,"Function_Id");

        }
      }
}
