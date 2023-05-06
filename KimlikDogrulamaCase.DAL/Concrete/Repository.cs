using KimlikDogrulamaCase.DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KimlikDogrulamaCase.DAL.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private static AppDbContext _db;
        private static DbSet<T> _dbSet;

        public Repository(AppDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }


        public void Create(T entity)
        {
            if (!_dbSet.Contains(entity))
            {
                _dbSet.Add(entity);
                _db.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity).State = EntityState.Deleted;
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Veri Silinemedi");
            }
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Veri göncellenemedi");
            }
        }
    }
}
