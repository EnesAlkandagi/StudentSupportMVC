using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.DataAccess.Context;
using DataAccess.DataAccess.Entityframework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAnnouncementDal : EfEntityRepositoryBase<Announcement>, IAnnouncementDal
    {
        private readonly PostgresqlContext _dataContext;
        public EfAnnouncementDal(PostgresqlContext dataContext)
            : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
