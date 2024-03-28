
namespace collage_ki_coffie.Backend
{
    public interface IMainEngine
    {
        Task Add<T>(T model, string procedure);
        void AddScrript<T>(string sql);
        Task<List<T>> GetData<T>(string proceduer);
    }
}