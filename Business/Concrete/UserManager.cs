using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Dtos.UserDtos;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaim(User user)
        {
            return _userDal.GetClaims(user);
        }

        [SecuredOperation(Priority = 1, role = "User")]
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByEmail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return _userDal.Get(u => u.Id == id);
        }

        [SecuredOperation(Priority = 1, role = "User")]
        public IDataResult<List<UserListDto>> GetListUser()
        {
            var result = new List<UserListDto>();
            var userList = _userDal.GetList(x => x.Type == Core.Entities.EnmUserType.Ogrenci);

            foreach (var user in userList)
            {
                var userListDto = new UserListDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Iban = user.Iban
                };
                result.Add(userListDto);
            }

            return new SuccessDataResult<List<UserListDto>>(result);
        }

        [SecuredOperation(Priority = 1, role = "User")]
        public IDataResult<UserListDto> GetRandomUser()
        {
            var userList = _userDal.GetList(x => x.Type == Core.Entities.EnmUserType.Ogrenci);
            var rnd = new Random();

            var sayi = rnd.Next(0, userList.Count);
            var userDto = new UserListDto
            {
                Id = userList[sayi].Id,
                FirstName = userList[sayi].FirstName,
                Iban = userList[sayi].Iban,
                LastName = userList[sayi].LastName
            };

            return new SuccessDataResult<UserListDto>(userDto);
        }
    }
}
