namespace ERapi.Aplication.Function.Domain.Write.Commands
{

    public class SaveFunctionCommand
    {

        public int Id { get; set; }
        public string Type { get; set; }
    }

    public class CreateFunction : SaveFunctionCommand
    {

        

    }

    public class UpdateFunction : SaveFunctionCommand
    {

    }



}