using System.Linq;

namespace MovieReviewSPA.web.Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        //To query using Linq
        IQueryable<T> GetAll();

        // Returning Movie or Review By id
        T GetById(int id);

        // Adding Movie or Review
        void Add(T entity);

        // Updating Movie or Review
        void Update(T entity);

        // Deleting Movie or Review
        void Delete(T entity);

        // Deleting Movie or Review by id
        void Delete(int T);
    }
}