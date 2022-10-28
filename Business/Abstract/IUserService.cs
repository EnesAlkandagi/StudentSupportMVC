using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.Dtos.UserDtos;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<UserListDto>> GetListUser();
        List<OperationClaim> GetClaim(User user);
        void Add(User user);
        User GetByEmail(string email);
        User GetById(int id);
        IDataResult<UserListDto> GetRandomUser();
    }
}
