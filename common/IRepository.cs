using System.Collections.Generic;

namespace common 
{
    public interface IRepository<T> 
    {
        IEnumerable<T> GetAll();

        T GetById(string id);
    }
}