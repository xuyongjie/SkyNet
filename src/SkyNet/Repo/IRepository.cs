using SkyNet.Models.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyNet.Repo
{
    public interface IRepository<T> where T:class,IBaseId
    {
        T Add(T entity);
        bool DeleteById(int id);
        T ModifyById(int id, T entity);
        IEnumerable<T> GetAll();
        T FindById(int id);
        void SavaChanges();
    }
}
