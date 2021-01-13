
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LexShop.Core.Contracts;
using LexShop.Core.Models;

namespace LexShop.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity   
    {
        DataContext db;
        string className;
        public SQLRepository(DataContext db)
        {
            className = typeof(T).Name;
            this.db = db;
            
        }
        public IQueryable<T> Collection()
        {
            return db.Set<T>();
        }

        public void Commit()
        {
            db.SaveChanges();
        }

        public void Delete(string Id)
        {
            var EntityToDelete = Find(Id);
            if (EntityToDelete != null)
            {
                db.Set<T>().Remove(EntityToDelete);
            }
            else
            {
                throw new Exception(className + "Not Found");
            }
            
        }

        public T Find(string Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T t)
        {
            throw new NotImplementedException();
        }

        public void Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
