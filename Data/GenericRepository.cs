using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MovieReviewSPA.web.Data.Contracts;

namespace MovieReviewSPA.web.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly MovieReviewDbContext _dbContext;
        protected DbSet<T> DbSet { get; set; }
        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }
        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            EntityEntry<T> dbEntityEntry = _dbContext.Entry(entity);
            if (dbEntityEntry.State != (EntityState) EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            EntityEntry<T> dbEntityEntry = _dbContext.Entry(entity);
            if (dbEntityEntry.State != (EntityState) EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            EntityEntry<T> dbEntityEntry = _dbContext.Entry(entity);

            if (dbEntityEntry.State != (EntityState.Deleted))
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public GenericRepository(MovieReviewDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DBContext cannot be null");
            }
            _dbContext = dbContext;
            DbSet = _dbContext.Set<T>();
        }
    }
}