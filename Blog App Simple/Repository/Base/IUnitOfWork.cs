using Blog_App_Simple.Models;

namespace Blog_App_Simple.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Post> post { get; }
        IRepository<category> category { get; }
        int CommitChanges();
    }
}
