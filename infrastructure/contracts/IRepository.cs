using System.Collections.Generic;
using domain;

namespace infrasrtucture.contracts
{
    public interface IRepository<out T> 
        where T: Entity 
    {
        Meeting GetAll();
    }
}