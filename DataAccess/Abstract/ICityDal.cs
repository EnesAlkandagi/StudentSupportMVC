using Core.Entities.Concrete;
using DataAccess.DataAccess;

namespace DataAccess.Abstract
{

    public interface ICityDal : IEntityRepository<City>
    {
    }
}