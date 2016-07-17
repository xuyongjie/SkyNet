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
        protected DbSet<T> DbSet { get;private set; }
        private readonly ApplicationDbContext _dbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = dbContext.Set<T>();
        }

        public T Add(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public bool DeleteById(int id)
        {
            var entity = FindById(id);
            if(entity!=null)
            {
                DbSet.Remove(entity);
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
            return DbSet.ToList();
        }

        public T FindById(int id)
        {
            return DbSet.Single(t => t.Id == id);
        }

        public void SavaChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
