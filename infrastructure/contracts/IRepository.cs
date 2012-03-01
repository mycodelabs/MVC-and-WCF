using System.Collections.Generic;
using domain;

namespace infrasrtucture.contracts
{
    public interface IRepository<T> 
        where T: Entity 
    {
        IEnumerable<T> GetAll();
    }
}