using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Dtos.AnnouncementDtos
{
    public class AnnouncementUserListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CityName { get; set; }
        public int UserId { get; set; }

    }
}
