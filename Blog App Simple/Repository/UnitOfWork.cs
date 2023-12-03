using Blog_App_Simple.Data;
using Blog_App_Simple.Models;
using Blog_App_Simple.Repository.Base;

namespace Blog_App_Simple.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context) 
        {
            _context = context;
            category = new MainRepository<category>(_context);
            post = new MainRepository<Post>(_context);
        }
        public IRepository<Post> post { get; private set; }

        public IRepository<category> category { get; private set; }

        public int CommitChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
