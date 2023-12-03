using Blog_App_Simple.Models;

namespace Blog_App_Simple.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);
        IEnumerable<T> FindAll();

        IEnumerable<T> FindAll(params string[] agers);

        void addOne(T MyItem);
        void updateOne(T MyItem);
        void removeOne(T MyItem);

        void addList(IEnumerable<T> MyList);
        void updateList(IEnumerable<T> MyList);
        void removeList(IEnumerable<T> MyList);
        List<category> ToList();
    }
}
