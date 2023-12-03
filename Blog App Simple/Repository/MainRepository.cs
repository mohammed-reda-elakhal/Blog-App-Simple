using Blog_App_Simple.Data;
using Blog_App_Simple.Models;
using Blog_App_Simple.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Blog_App_Simple.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {
        public MainRepository(AppDbContext context) 
        {
            _context = context;
        }

        protected AppDbContext _context;
        public void addList(IEnumerable<T> MyList)
        {
            _context.Set<T>().AddRange(MyList);
            _context.SaveChanges();
        }

        public void addOne(T MyItem)
        {
            _context.Set<T>().Add(MyItem);
            _context.SaveChanges();
        }

        public IEnumerable<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> FindAll(params string[] agers)
        {
            IQueryable<T> query = _context.Set<T>();
            if (agers.Length > 0)
            {
                foreach (string ager in agers)
                {
                    query = query.Include(ager);
                }
            }
            return query.ToList();
        }

        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void removeList(IEnumerable<T> MyList)
        {
            _context.Set<T>().RemoveRange(MyList);
            _context.SaveChanges();
        }

        public void removeOne(T MyItem)
        {
            _context.Set<T>().Remove(MyItem);
            _context.SaveChanges();
        }

        public void updateList(IEnumerable<T> MyList)
        {
            _context.Set<T>().UpdateRange(MyList);
            _context.SaveChanges();
        }

        public void updateOne(T MyItem)
        {
            _context.Set<T>().Update(MyItem);
            _context.SaveChanges();
        }

        public List<category> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
