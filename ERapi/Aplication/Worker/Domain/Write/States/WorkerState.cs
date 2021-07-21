using ERapi.Aplication.Product.Domain.Write.Entities;

namespace ERapi.Aplication.Worker.Domain.Write.States
{

    public class WorkerState : BaseEntity
    {

        public int FunctionIdFk {get; set;}
        public string Name {get; set;}
        public string Cpf {get; set;}
        public string PhoneNumber {get; set;}
        public string Address {get; set;}
        public string Email {get; set;}
    }

}