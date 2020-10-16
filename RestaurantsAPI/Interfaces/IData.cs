namespace RestaurantsAPI.Interfaces
{
    public interface IData<TEntity>
    {
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
