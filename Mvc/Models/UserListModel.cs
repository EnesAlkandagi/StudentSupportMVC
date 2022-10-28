using Entity.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Models
{
    public class UserListModel
    {
        public List<UserListDto> userListDto { get; set; }
    }
}
