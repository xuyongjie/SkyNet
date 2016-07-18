using Microsoft.EntityFrameworkCore;
using SkyNet.Data;
using SkyNet.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Repo
{
    public class Repository<T> : IRepository<T> where T :class, IBaseId
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly ApplicationDbContext _dbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public T Add(T entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public bool DeleteById(int id)
        {
            var entity = FindById(id);
            if(entity!=null)
            {
                _dbSet.Remove(entity);
                return true;
            }
            return false;
        }

        public T ModifyById(int id, T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T FindById(int id)
        {
            return _dbSet.Single(t => t.Id == id);
        }

        public void SavaChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
