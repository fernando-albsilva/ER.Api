namespace ER.Interfaces
{
    public interface IBaseRepository
    {
        void save();
        void Update();
        void Delete();
        void GetById();
        void GetAll();
    }
}