using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos.UserDtos
{
    public class UserListDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Iban { get; set; }
    }
}
